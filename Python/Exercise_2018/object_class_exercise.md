### 魔术方法(内置方法)
python解释器预留了一些方法入口, 用来实现具体的功能.
1. 规范: 以双下划线开头, 名称都是固定的: __init__
2. 优势: 可以直接对类做操作, 使自定义的类表现得像内置的类.
    可以进行重写, 自定义要实现的功能
3. 分类: 
    比较相关的, __equal__(self, other): self == other
    数学相关的, __add__(self, other): self + other
4. 常用的几个例子: 
    __eq__(self, other): equal,判断是否相等
    __add__(self, other): add, 数字类型时进行添加, 字符串类型进行拼接
    __mul__(self, other): mul, 数字类型时进行相乘, 字符串类型复制
5. code实现__str__和__repr__
```
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
```     