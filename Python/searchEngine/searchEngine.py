from abc import ABCMeta, abstractmethod
import re
from functools import reduce
import pylru


class SearchEngineBase(object, metaclass=ABCMeta):
    '''
    abstrac base search engine class

    1. metaclass=ABCMeta: 抽象基类不可实例化
    2. @abstractmethod: sub class must implement abstractmethod
    '''

    def __init__(self):
        pass

    def add_corpus(self, file_path):
        '''
        函数负责读取文件内容，将文件路径作为 ID，连同内容一起送到 process_corpus
        '''
        with open(file_path, 'r') as fin:
            text = fin.read()
            self.process_corpus(file_path, text)

    @abstractmethod
    def process_corpus(self, id, text):
        '''
        需要对内容进行处理，然后文件路径为 ID ，将处理后的内容存下来。处理后的内容，就叫做索引（index）
        '''
        raise NotImplementedError

    @abstractmethod
    def search(self, query):
        '''
        则给定一个询问，处理询问，再通过索引检索，然后返回
        '''
        raise NotImplementedError


class SimpleEngine(SearchEngineBase):
    '''
    search single words
    '''

    def __init__(self):
        super().__init__()
        self.__id_to_text = {}

    def process_corpus(self, id, text):
        self.__id_to_text[id] = text

    def search(self, query):
        results = []
        for i, s in self.__id_to_text.items():
            if query in s:
                results.append(i)
        return results


class BOWEngine(SearchEngineBase):
    '''
    Bag of Words: 词袋模型
    '''

    def __init__(self):
        super().__init__()
        self.__id_to_words = {}

    def process_corpus(self, id, text):
        self.__id_to_words[id] = self.parse_text_to_words(text)

    def search(self, query):
        results = []
        query_words = self.parse_text_to_words(query)

        for i, words in self.__id_to_words.items():
            if self.query_match(query_words, words):
                results.append(i)
        return results

    @staticmethod
    def query_match(q_words, words):
        for qw in q_words:
            if qw not in words:
                return False
        return True

    @staticmethod
    def parse_text_to_words(text):
        text = re.sub(r'[^\w]', ' ', text)
        text = text.lower()
        words = text.split(' ')
        words = filter(None, words)
        return set(words)


class BOWIIEngine(SearchEngineBase):
    '''
    Bag of Words Inverted Index
    单词按顺序出现，或者希望搜索的单词在文中离得近一些
    '''

    def __init__(self):
        super().__init__()
        self.inverted_index = {}

    def process_corpus(self, id, text):
        words = self.parse_text_to_words(text)
        for w in words:
            if w not in self.inverted_index:
                self.inverted_index[w] = set()
            self.inverted_index[w].add(id)

    def search(self, query):
        qws = list(self.parse_text_to_words(query))
        for qw in qws:
            if qw not in self.inverted_index:
                return []
        results = []
        for qw in qws:
            results.append(self.inverted_index[qw])

        return reduce(lambda x, y: x.intersection(y), results)

    @staticmethod
    def parse_text_to_words(text):
        text = re.sub(r'[^\w]', ' ', text)
        text = text.lower()
        words = text.split(' ')
        words = filter(None, words)
        return set(words)


class BOWInvertedIndexEngine(SearchEngineBase):
    '''

    '''

    def __init__(self):
        super(BOWInvertedIndexEngine, self).__init__()
        self.inverted_index = {}

    def process_corpus(self, id, text):
        words = self.parse_text_to_words(text)
        for word in words:
            if word not in self.inverted_index:
                self.inverted_index[word] = []
            self.inverted_index[word].append(id)

    def search(self, query):
        query_words = list(self.parse_text_to_words(query))
        # 存放一组单词对应的文档的组合
        query_words_index = list()
        for query_word in query_words:
            query_words_index.append(0)

        # 如果某一个查询单词的倒序索引为空，我们就立刻返回
        for query_word in query_words:
            if query_word not in self.inverted_index:
                return []
        result = []
        while True:
            # 首先，获得当前状态下所有倒序索引的 index
            # 输入的单词语料对应的文本id
            current_ids = []
            print(1, query_words, query_words_index, result)

            for idx, query_word in enumerate(query_words):
                current_index = query_words_index[idx]
                current_inverted_list = self.inverted_index[query_word]

                # 已经遍历到了某一个倒序索引的末尾，结束 search
                if current_index >= len(current_inverted_list):
                    return result

                current_ids.append(current_inverted_list[current_index])
                print(2, current_index, current_ids, current_inverted_list)

            # 然后，如果 current_ids 的所有元素都一样，所有的单词都在这个文本中存在, 直接查找下一个文档
            if all(x == current_ids[0] for x in current_ids):
                result.append(current_ids[0])
                query_words_index = [x + 1 for x in query_words_index]
                continue

            # 当前的文档没有包含所有单词, 顺序遍历文档编号
            min_val = min(current_ids)
            min_val_pos = current_ids.index(min_val)
            query_words_index[min_val_pos] += 1

    @staticmethod
    def parse_text_to_words(text):
        # 使用正则表达式去除标点符号和换行符
        text = re.sub(r'[^\w ]', ' ', text)
        # 转为小写
        text = text.lower()
        # 生成所有单词的列表
        word_list = text.split(' ')
        # 去除空白单词
        word_list = filter(None, word_list)
        # 返回单词的 set
        return set(word_list)


class LRUCache(object):
    def __init__(self, size=32):
        self.cache = pylru.lrucache(size)

    def has(self, key):
        return key in self.cache

    def get(self, key):
        return self.cache[key]

    def set(self, key, val):
        self.cache[key] = val


class BOWInvertedIndexEngineCache(BOWInvertedIndexEngine, LRUCache):
    def __init__(self):
        super().__init__()
        LRUCache.__init__(self)

    def search(self, query):
        if self.has(query):
            print('lrucache')
            return self.get(query)
        result = super().search(query)
        self.set(query, result)

        return result


def main(search_engine):
    '''
    test
    '''
    for file_path in ['1.txt', '2.txt', '3.txt', '4.txt', '5.txt']:
        search_engine.add_corpus(file_path)

    try:
        while True:
            query = input("please input words(quit to quit ):")
            if query == 'quit':
                break
            rtns = search_engine.search('one day')
            print('found {} result(s)'.format(len(rtns)))
            for r in rtns:
                print(r)
    except Exception as _:
        print('Oops, error...')


if __name__ == "__main__":
    print("__main__")
    # TypeError: Can't instantiate abstract class SearchEngineBase with
    # abstract methods process_corpus, search
    # base = SearchEngineBase()
    # print('search single word: little')
    # sengine = SimpleEngine()
    # main(sengine)
    # print('search multiple words: one day')
    # sengine = BOWEngine()
    # main(sengine)
    # print('search multiple words: one day')
    # sengine = BOWIIEngine()
    # main(sengine)
    # search_engine = BOWInvertedIndexEngine()
    # main(search_engine)
    search_engine = BOWInvertedIndexEngineCache()
    main(search_engine)
