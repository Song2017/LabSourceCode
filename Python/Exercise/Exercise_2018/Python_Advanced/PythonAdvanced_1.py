# Python 进阶

# 1 可选参数
# 使用:函数装饰器,猴子补丁(程序运行时(runtime)修改某些代码)
# *name 必须在 **name 之前出现
# 可选参数打印出来的参数的顺序是未定义
# 可选参数应该是是参数列表中的最后一个，因为它们将把所有的剩余输入参数传递给函数


def cheeseshop(kind, *arguments, **keywords):
    print("-- Do you have any", kind, "?")
    print("-- I'm sorry, we're all out of", kind)
    for arg in arguments:
        print(arg)
    print("-" * 40)
    keys = sorted(keywords.keys())
    for kw in keys:
        print(kw, ":", keywords[kw])


cheeseshop("Limburger", "It's very runny, sir.",
           "It's really very, VERY runny, sir.",
           shopkeeper="Michael Palin",
           client="John Cleese",
           sketch="Cheese Shop Sketch")
# 元组参数 *args


def test_asterisk(f_arg, *arg_vars):
    print('f_arg', f_arg)
    for arg in arg_vars:
        print('arg in arg_vars', arg)


test_asterisk('yasoob', 'python', 'eggs', 'test')
# 字典参数 **dargs


def test_kvps(**arg_vars):
    for (key, v) in arg_vars.items():
        print("{0} == {1}".format(key, v))


test_kvps(**{'name': 'yasoob'})
# 使用时的顺序不能改变


def test_args(arg1, *arg2, **arg3):
    print('f_arg', arg1)
    for arg in arg2:
        print('arg in arg_vars', arg)
    for (key, v) in arg3.items():
        print("{0} == {1}".format(key, v))


test_args('yasoob', 'python', 'eggs', 'test', 123123, name='yasoob')
# * 操作符来自动把参数列表拆开
# ** 操作符分拆关键字参数为字典
args = [3, 6]
list(range(*args))  # 等价于list(range(3,6))


def parrot(voltage, state='a stiff', action='voom'):
    print('voltage, state, action: ', voltage, state, action, end=' ')


d = {"voltage": "four million", "state": "bleedin' demised"}
parrot(**d)  # voltage, state, action:  four million bleedin' demised voom
"""
parrot()                     # required argument missing
parrot(voltage=5.0, 'dead')  # non-keyword argument after a keyword argument
parrot(110, voltage=220)     # duplicate value for the same argument
parrot(actor='John Cleese')  # unknown keyword argument
"""


#　2 Debugging
'''
    python -m pdb my_script.py
    c:continue 继续执行
    w:where 显示当前正在执行的代码行的上下文信息
    a:args 打印当前函数的参数列表
    s:step 执行当前代码行,并停在第一个能停的地方(相当于单步进入)
    n:next 继续执行到当前函数的下一行,或者当前行直接返回(单步跳过)
    p:print  p expression
'''


# 3 生成器(Generators)
'''
迭代(Iteration):当我们使用一个循环来遍历某个东西的过程
迭代器(Iterator): 遍历一个容器(特别是列表)的对象,
    定义了next(Python2) 或者__next__方法的对象
可迭代对象(Iterable): 能提供迭代器的任意对象,
    定义了可以返回一个迭代器的__iter__方法,或者可以支持下标索引的__getitem__方法
生成器(Generators): 生成器是只迭代一次的迭代器.这是因为它们并没有把所有的值存在内存中,而是在运行时生成值.
    通过yield每次返回一个单次运行的值, 而不是直接返回占用大量空间的一个值
    调用:用for循环,或可进行迭代的函数或结构
    next(): 它允许我们获取一个序列的下一个元素. yield所有值后会触发 StopIteration exception
    生成器是数据的生产者 协程则是数据的消费者. yield可获得一个协程.协程会消费掉发送给它的值,
    生成器在 Python 的写法是用小括号括起来，(i for i in range(100000000))，即初始化了一个生成器
    详见 学习二:协程(Coroutines)
'''


def fibon(n):
    a = b = 1
    for i in range(n):
        yield a
        (a, b) = (b, a+b)


i = 0
for x in fibon(10):
    i += 1
    print('fibon({0})'.format(i), x)
test_string = 'te'
test = iter(test_string)
print(next(test))
print(next(test))
# print(next(test) ) # 因为 'te'只有两个字符, 所以第三次会触发 StopIteration
# iter and next implement


class Reverse:
    """Iterator for looping over a sequence backwards."""

    def __init__(self, data):
        self.data = data
        self.index = len(data)

    def __iter__(self):
        return self

    def __next__(self):
        if self.index == 0:
            raise StopIteration
        self.index = self.index - 1
        return self.data[self.index]


# 4 Map:n个输入源返回n个结果 将函数映射到集合的每个元素,多与lambda连用
# map(function_to_apply, list_of_inputs)
# lambda:匿名函数
# 参数:操作(参数)
items = [1, 2, 3, 4, 5]
squard = list(map(lambda x: x**2, items))
print(squard)
# 将多个函数映射到集合


def multiply(x): return (x**2)


def add(x): return (x*2)


funcs = [multiply, add]
for i in range(5):
    # 函数作为lambda的操作对象
    value = map(lambda x: x(i), funcs)
    print(list(value))

# Filter: 过滤表中的元素, 返回所有符合要求的元素
# filter(function, iterable)
# 可用推导式替换,推导式的可读性更好
pr = filter(lambda x: 1 == 1, range(-5, 5))
print(list(pr))

# Reduce 多个输入源返回一个结果,对一个列表计算返回结果:第一个元素与第二个计算,其结果与第三个元素运算
# reduce(function, iterable[, initializer])
from functools import reduce
pro = reduce(lambda x, y: x*y, range(1, 5))
print(pro)


# 5 数据结构
# strings, list, tuple, dictionary
# number:int float bool
# string 'name' 不可变,不可以对其中的字符赋值; 多用list替代 可切片
# list [1, 2, 3] 可变,key必须是数字,可以对其组成元素进行增删改 可切片
# tuple (0, 1, 2) 不可变,常用于return返回的结果,形参,字典键, 可切片
# dict {'name':'zhangsan', 'age':20} 可变,key可以是string等非数字 {}
# set {1,2,3} 元素不可以重复,不能切片, 运算的单位是集合
# set 集合:不能包含重复的值 不能切片
some_list = ['a', 'b', 'c', 'b', 'd', 'm', 'n', 'n']
dup = set([x for x in some_list if some_list.count(x) > 1])
print(dup)
# set intersection 交集
valid = set(['yellow', 'red', 'blue', 'green', 'black'])
input_set = set(['red', 'brown'])
print(input_set.intersection(valid))
# set difference 差集
print(input_set.difference(valid))


# 6 三元运算符
# 如果条件为真,返回真 否则返回假
# condition_is_true if condition else condition_is_false
is_fat = True
print('fat' if is_fat else 'not fat')
# 结合元组使用 true means 1, 因为元组要先建数据,所以两个表达式都会执行
print(('skinny', 'fat')[is_fat])


# 7 装饰器
# 一切皆对象:对象可以作为赋值给变量或是作为参数传递给函数(类似js)
# 不同语言对对象的定义不同,python中的对象只要有属性或方法就可以,不要求可子类化,
def hi(name='benji'):
    return 'hi '+name


print(hi())
greet = hi  # greet不是调用hi函数,而是分配到新的内存
print(greet())
del hi
# print(hi()) #NameError: name 'hi' is not defined
print(greet())
# 嵌套函数


def hi2(name='benji'):
    print('context is in hi()')

    def greet2():
        print('context is in greet()')
    greet2()
    print('context is in hi() again')


hi2()
# greet2() #NameError: name 'greet2' is not defined

# 返回函数


def hi3(name='benji'):
    def greet3(): return 'greet3 ' + name

    def welcome3(): return 'welcome3'
    if name == 'benji':
        return welcome3
    else:
        return greet3


a = hi3()
print(a)  # <function hi3.<locals>.greet3 at 0x00DAD7C8>
print(a())

# 函数作为参数


def fun_as_var(func):
    print('fun_as_var')
    func()


fun_as_var(hi2)

# Python 装饰器: 封装一个函数, 围绕函数,做一些操作
# @decorator: 以单个函数作为参数的一个包裹函数
from functools import wraps


def new_decorator(a_func):
    @wraps(a_func)  # 恢复被装饰函数的名字和注释文档
    def wrap_func():
        print('before para function in new_decoration ')
        a_func()
        print('after para function in new_decoration ')
    return wrap_func


def a_func():
    print('in function needed to be decorated')


new_decorator(a_func)()


@new_decorator
def a_func_with_deco():
    print('in a_func_with_deco, function needed to be decorated')


a_func_with_deco()
print(a_func_with_deco.__name__)  # wrap_func restore by functools.wraps

# decorator sample
# 内置的装饰器@functools.wrap，
# 它会帮助保留原函数的元信息（也就是将原函数的元信息，拷贝到对应的装饰器函数里）
from functools import wraps


def decorator_name(f):
    @wraps(f)
    def decorated(*args, **kwargs):
        print('run in decorator_name')
        if not can_run:
            return 'function will not run'
        return f(*args, **kwargs)
    return decorated


@decorator_name
def func(*arg2, **arg3):
    for arg in arg2:
        print('arg in arg_vars', arg)
    for (key, v) in arg3.items():
        print("{0} == {1}".format(key, v))
    return 'function is running'


can_run = True
print(func(12, 'test', 'asdf'))
# 类装饰器
# 前面我们主要讲了函数作为装饰器的用法，实际上，类也可以作为装饰器。
# 类装饰器主要依赖于函数__call_()，每当你调用一个类的示例时，函数__call__()就会被执行一次

# 使用场景
'''# 授权

def require_auth(f):
    @warps(f)
    def decorated(*args, **kwargs):
        auth = request.authorization
        if not auth or not check_auth(auth.username, auth.password):
            authenticate()
        return f(*args, **kwargs)
    return decorated
'''
# 日志


def logit_easy(func):
    @wraps(func)
    def with_logging(*args, **kwargs):
        print(func.__name__ + ' was called')
        return func(*args, **kwargs)
    return with_logging


@logit_easy
def addition_func(x):
    return x+x


print(addition_func(4))
# 带参数的装饰器
# 装饰器方法本身需要接收函数作为入参,为避免形参冲突,再嵌套一层函数用来接收其他入参
from functools import wraps


def logit(logfile='out.log'):
    def logging_decorator(func):
        @wraps(func)
        def warp_function(*args, **kwargs):
            log_string = func.__name__ + ' was called.'
            print(log_string)
            with open(logfile, 'a') as opened_file:
                opened_file.write(log_string+'\n')
            return func(*args, **kwargs)
        return warp_function
    return logging_decorator


@logit()
def myfunc1():
    pass


myfunc1()


@logit(logfile='func2.log')
def myfunc2():
    pass


myfunc2()

# Decorate Class
# 装饰类代码比装饰函数简洁,易于拓展,包裹函数可以通过类属性获取新功能的参数,不需要嵌套函数
# __call__()方法能够让类的实例对象,像函数一样被调用


class logitClass(object):
    def __init__(self, logfile='out2.log'):
        self.logfile = logfile

    def __call__(self, func):
        @wraps(func)
        def warp_function(*args, **kwargs):
            log_string = func.__name__ + ' was called'
            print(log_string, self.logfile)
            with open(self.logfile, 'a') as opened_file:
                opened_file.write(log_string+'\n')
            self.notify()
            return func(*args, **kwargs)
        return warp_function

    def notify(self):
        print('super notify')

# 包裹函数的语法与之前一致


@logitClass()
def myclass1func():
    pass


myclass1func()


class email_logit(logitClass):
    def __init__(self, email='test@test.com', *args, **kwargs):
        self.email = email
        print('email_logit', args)
        for i in args:
            print('email_logit', i)
        logitClass.__init__(self, *args, **kwargs)

    def notify(self):
        print('this is in child class email logit')
# ??? 子类如何设置log文件名称
# invalid @email_logit('email.log')


@email_logit()
def myclassEmail():
    pass


myclassEmail()
