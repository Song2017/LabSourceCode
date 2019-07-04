class Word():
    def __init__(self, text):
        self.__text = text

    def __eq__(self, word2):
        return self.__text.lower() == word2.__text.lower()

    def __str__(self):
        '''
        call once print(object of Word)
        '''
        return self.__text

    def __repr__(self):
        '''
        return more details
        call when tty(终端), 交互解释器
        '''
        return 'Word("'+self.__text+'")'

first = Word("hi, this is first")
second = Word("hi, this is second")
print('first==second',first==second) #False
#Word("hi, this is first"), or run in tty
print(first.__repr__())
print(first) #first is  hi, this is first

