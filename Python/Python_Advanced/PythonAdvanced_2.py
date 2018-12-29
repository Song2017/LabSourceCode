# Python 进阶
from __future__ import print_function

# 8 Global和Return
# Return 返回结果,变量,函数,类...
# 返回多个值可以用 元组(常用),列表,字典
def profile():
    name = 'benji'
    age = 30
    return name, age  # 等价于(name,age) 元组的括号可以省略
p_data = profile()
print(p_data[0], p_data[1])
# global 变量意味着我们可以在函数以外的区域都能访问这个变量
# 尽量不要使用尽量不要使用尽量不要使用


# 9 Mutation和Immutation
# python中的所有东西都是一个object,所以每个变量都包含对象实例.
# 启动对象时,会为其分配一个唯一的object id,可以通过id(object)获得. is 运算符判断object的id是否相等
# 对象的类型在运行时定义,一旦设置永远不会改变,但可以重新定义,可以通过type(object)获得
# 但对象的状态(值)有的是可以改变的,这就是可变对象,反之,为不可变对象
# 对某种数据类型可变性的具体定义,应该看变量的具体使用情况,而不是通过id方法获取的内存地址.
#   内存地址体现的是底层实现, 使用的结果才是我们应该关心的
asfd = '...asd'
print('\nid(asfd)', id(asfd), "\nid('...asd')", id('...asd'))
'''
>>> asd = '...asd'
>>> id(asd)
11405856
>>> id('...asd')
11406144
'''
# 可变对象： list,dict,set,byte array
# 不可变对象：int,float,complex,string,tuple,frozen set [注意：set的不可变版本],bytes
a = 'asd'
print("a='asd'\na is 'asd' ", a is 'asd',
      '\nid(a)', id(a), "\nid('asd')", id('asd'))
b = [1]
print("b=[1]\nb is [1] ", b is [1], '\nid(b)', id(b), "\nid([1])", id([1]))
# 不可变对象的不可变性是指对象本身不可变,其组成元素可能可变
# 例如 元组(12,[1,2,3])没有改变自身元素的方法,但其组成元素[1,2,3]是可变的
# 按值传递: 入参是不可变对象,经过函数运算后,入参的值不发生改变
# 按引用传递: 入参是可变对象,经过函数运算后,原入参的值发生改变


# 10 __slots__ 魔法方法
# 在Python中，每个类都有实例属性.Python是动态语言，根据类创建的实例可以任意绑定属性
# 默认情况下Python用一个字典来保存一个对象的实例属性，这允许我们在运行时去设置任意的新属性，
# __slots__来告诉Python不要使用字典，而只给一个固定集合的属性分配空间
# name是类属性，score是实例属性.同名时实例属性会覆盖掉类属性
class Student(object):
    # 使用__slots__后将不能再使用实例属性:AttributeError: 'Student' object has no attribute 'score'
    # 只给一个固定集合的属性分配空间,使用的内存可降低40%-50%
    # ipython_memory_usage: 内存使用检测工具
    # __slots__ = ['name']
    def __init__(self, name):
        self.name = name
s = Student('Bob')
s.score = 90
print(s.name, ' has score ', s.score)


# 11 虚拟环境 virtualenv
# Virtualenv 是一个工具，它能够帮我们创建一个独立(隔离)的Python环境
# Virtualenv会创建在当前路径创建一个文件夹,里面包括Python执行文件,pip类库,我们可以用来安装其他类包
'''
#安装
pip install virtualenv
#创建隔离的virtualenv环境
virtualenv myproject
#使用系统全局模块
virtualenv --system-site-packages mycoolproject
#python 2.7
virtualenv -p /usr/bin/python2.7 my_project
#激活
source bin/activate
#退出
deactivate
'''


# 12 Collections 容器
# Python附带一个模块，它包含许多容器数据类型，名字叫作collections
# defaultdict: 不需要检查key是否存在,是否重复
from collections import defaultdict
colours = (('Yasoob', 'Yellow'), ('Ali', 'Blue'),
           ('Yasoob', 'Red'), ('Ahmed', 'Silver'))
favourite_colours = defaultdict(list)
for name, colour in colours:
    favourite_colours[name].append(colour)
print(favourite_colours)
# 字典中对一个键进行嵌套赋值
import collections
def tree(): return collections.defaultdict(tree)
some_dict = tree()
some_dict['colours']['favourite'] = "yellow"

# Counter: 计数器 对某项数据进行计数
from collections import Counter
colours = (('Yasoob', 'Yellow'), ('Ali', 'Blue'),
           ('Yasoob', 'Red'), ('Ahmed', 'Silver'))
favs = Counter(col1 for col1, item in colours)
print(favs)
# rb:以二进制打开文件的只读模式
with open('readme.md', 'rb') as f:
    line_count = Counter(f)
print(line_count)

# deque：双端队列 可以从头/尾两端添加或删除元素,用法类似list
from collections import deque
d = deque()
d.append('1')
d.append('2')
d.append('3')
print('d, len(d), d[0], d[-1]: ', d, len(d), d[0], d[-1])
print('d.popleft(),d.pop(),d:', d.popleft(), d.pop(), d)
# 一旦设置长度后，数据会从对队列另一端被挤出去(pop)； 也可以从任一端拓展队列的数据
d = deque(maxlen=2)
d.append('1')
d.append('2')
d.append('3')
print('d', d)
d = deque(range(5))
d.extendleft([-2, -1, 0])
d.extend([10, 11, 12])
print('d', d)

# namedtuple 命名元组， 可以字典访问的元组，当然仍然是不可变的
# 有两个必须参数：元组名称和字段名称， 这让命名元组变得自文档了
# 而且，namedtuple的每个实例没有对象字典, 但_asdict()可以转换为字典
from collections import namedtuple
Animal = namedtuple('Animal', 'name age type')
perry = Animal(name='perry', age=31, type='cat')
print('perry, perry.age', perry, perry.age)
# AttributeError: can't set attribute
# perry.age=42
print(perry._asdict())

# enum.Enum(Python 3.4+)
# Enums(枚举类型)基本上是一种组织各种东西的方式
from enum import Enum
class Species(Enum):
    cat = 1
    dog = 2
    horse = 3
    owl = 4
    platypus = 5
    aardvark = 6
    kitten = 7
    puppy = 8
    dragon = 9
print('Species.cat, Species.dragon, type(Species.cat)',
      Species.cat, Species.dragon, type(Species.cat))
perry = Animal(name='perry', age=31, type=Species.cat)
print('perry.type', perry.type)
perry.type


# 13 枚举 enumerate 
# 遍历数据并自动计数
# 返回一个迭代器对象, 详见 学习一: 3 生成器(Generators)
mylist = ['apple', 'banana', 'grapes', 'pear']
# 定制从哪个数字开始枚举 2 apple 3 banana 4 grapes 5 pear
for c, val in enumerate(mylist, 2):
    print(c, val)
#　创建包含索引的元组列表
counterlist = list(enumerate(mylist, 1))
print(counterlist)


# 14 对象自省 introspection
# 自省 在计算机编程领域里，是指在运行时来判断一个对象的类型的能力
# Python中所有一切都是一个对象， 并且包含许多内置函数和模块
# dir 返回一个列表，列出了一个对象所拥有的属性和方法
mylist = [1, 23, 4]
print('dir(mylist)', dir(mylist))
# type 返回一个对象的类型
# id 返回任意不同种类对象的唯一ID
print('type({})', type({}))
print('id(mylist)', id(mylist))
# inspect模块 提供了许多有用的函数，来获取活跃对象的信息
import inspect
print(inspect.getmembers(mylist))


# 15 推导式 comprehensions：list dict set
# 推导式的类型决定了推导式返回结果的类型
# 是可以从一个数据序列构建另一个新的数据序列的结构体
# 列表推导式 list  variable = [out_exp for out_exp in input_list if out_exp == 2]
squard = [x**2 for x in range(10) if x > -1]
print(squard)
# 字典推导式 dict variable = { key: value for key, value in some_dict.items() if key > 2}
d = {'a': 10, 'b': 34, 'A': 7, 'Z': 3}
reverse_d = {vk: val for val, vk in d.items() if vk > 10}
print(reverse_d)
# 集合推导式 set variable = {out_exp for out_exp in input_list if out_exp ==2}
squard = {x**2 for x in [1, 2, 33, 1] if x < 10}
print(squard)


# 16 异常 Exception
try:
    file = open('readme.md', 'rb')
    #i = 1/0
# only catch IOError
except IOError as e:
    print('IOError occured. {}'.format(e.args[-1]))
# catch all exception and raise them
except Exception as e:
    print('Exception. {}'.format(e.args[-1]))
    #raise e
else:
    print('without error, else block will be run.')
finally:
    print('without raise, finally block will be run.')


# 17 lambda 匿名函数/行函数
#  lambda 参数:操作(参数)
a = [(1, 2), (4, 1), (9, 10), (13, -3)]
a.sort(key=lambda x: x[1])
print(a)
# zip in Python 3 returns an iterator
data = list(zip([2, 1], [4, 3]))
print(data[:])


# 18 python 行式命令
'''
python -m/-c
python -c command [arg] ...，启动 Python 解释器 这种方法可以在 命令行 执行 Python 语句，类似于 shell 中的 -c 选项.一般将 命令 用单引号包裹起来.
python -m module [arg] ... 将 Python 模块也可以当作脚本使用 命令调用它们，这类似在命令行中键入完整的路径名执行 模块 源文件一样.
# ??? 共享文件
python -m http.server
# 脚本性能分析
python -m cProfile PythonAdvanced.2.py
# csv转换为json
python -c "import csv,json;print(json.dumps(list(csv.reader(open('download.csv')))))"
'''
# 列表碾平
import itertools
a_list = [[1, 2], [3, 4], [5, 6]]
print(list(itertools.chain.from_iterable(a_list)))
# 一行式构造器 避免初始化时的重复赋值语句
class A(object):
    def __init__(self, a, b, c, d, e, f):
        self.__dict__.update(
            {k: v for k, v in locals().items() if k != 'self'})
a = A('aaa', 'b123', 'c12', 'd11', 'e22', 'f321')
print(a.__dict__)


# 19 For - Else
# else从句会在循环正常结束时执行
# 类似的还有 while .. else ..
for n in range(2, 20):
    for i in range(2, n):
        if n % i == 0:
            print(n, 'equals', i, '*', n/i)
            break
    else:
        print(n, 'is a prime')


# 20 使用C拓展
# C语言的运行速度是python的50倍且C有很多传统类库
# ctypes: python类库,直接调用C类库,使用简单,但是不能操作python对象
# SWIG: 适合多语言,但是使用复杂,需要为SWIG入口编写接口文件
# Python/C API: 可以将c源码编译为拓展模块,作为类包引用,可以操作python对象,适合c/c++
# 详见add_c文件夹


# 21 open 打开一个文件,返回一个句柄.
# with: open函数出现异常时不会关闭文件句柄,with可以保证无论是否出现异常,文件都能关闭
# mode: r 只读; r+ 读写; w 覆盖写入; a 追加写入
#       rb 二进制模式只读; rt(默认为文本) 文本模式只读
with open('pythondatastructure.png', 'rb') as f:
    picdata = f.read()
# io 模块可以设置编码类型
import io
with open('pythondatastructure.png', 'rb') as inf:
    picdata = inf.read()
if picdata.startswith(b'\xff\xd8'):
    text = u'this is a JPG file (%d bytes long)\n'
else:
    text = u'this is a no JPG file (%d bytes long)\n'
with io.open('open_summary.txt', 'w', encoding='utf-8') as outf:
    outf.write(text % len(picdata))


# 22 兼容 python2 + python3
# 导入__future__ 模块
# must set at the beginning
# from __future__ import print_function
print('this is from __future__')
# 模块重命名
# import foo as foo_alias
try:
    import urllib.request as urllib_request
except ImportError:
    import urllib2 as urllib_request
# 禁用python2中的12个废除的内置功能 作用环境python2
# from future.builtins.disabled import *


# 23 协程 Coroutines
# 协同程序和线程差不多，也就是一条执行序列，拥有自己独立的栈、局部变量和指针，
# 同时又与其他协同程序共享全局变量和其他大部分东西.
# 与线程区别:一个具有多个线程的程序可以同时运行几个线程，而协同程序却需要彼此协作地运行
# 就是说一个具有多个协同程序的程序在任意时刻只能和运行一个协同程序
# 生成器是数据的生产者 协程则是数据的消费者. yield可获得一个协程.协程会消费掉发送给它的值
def grep(pattern):
    print("searching for", pattern)
    while True:
        # line 不包含任何初始值，相反要从外部传值给它
        line = (yield)
        if pattern in line:
            print(line)
search = grep('coroutine')
# next() 启动一个协程,send()方法向它传值, close()方法来关闭一个协程
next(search)  # output: searching for coroutine
search.send('I Love bodybuilding')
search.send('I Love coroutine')  # output: I Love coroutine
search.close()
# search.send('I Love coroutine') # error: StopIteration

# 24 函数缓存 Function caching
# 函数缓存允许我们将一个函数对于给定参数的返回值缓存起来
# python 3.2之后使用lru_cache
from functools import lru_cache
@lru_cache(maxsize=32)
def fib(n):
    if n < 2:
        return n
    return fib(n-2)+fib(n-1)
print([fib(x) for x in range(10)])
# 清空缓存
fib.cache_clear()
# python 2 实现缓存机制
from functools import wraps
def memorize(function):
    memo = {}
    @wraps(function)
    def wrapper(*args):
        # print('*args',*args)#*args 6
        # print('args',args)#args (6,)
        # print('memo',memo)#memo {(0,): 0, (1,): 1, (2,): 1, (3,): 2, (4,): 3, (5,): 5, (6,): 8}
        if args in memo:
            return memo[args]
        else:
            rv = function(*args)
            memo[args] = rv
            return rv
    return wrapper
@memorize
def fib2(n):
    if n < 2:
        return n
    return fib2(n-2)+fib2(n-1)
print('fib2(10)', fib2(10))
print('fib2(5)', fib2(5))


# 25 上下文管理器 Context managers
# 上下文管理器允许你在有需要的时候，精确地分配和释放资源,
# 常见的, 资源的加锁和解锁，以及关闭已打开的文件with
with open('download.csv', 'r+') as f:
    picdata = f.read()
# 基于类的实现
# 上下文管理器的类必须要定义方法__enter__和__exit__
class MyFile(object):
    __slots__ = ["file_obj"]
    def __init__(self, file_name, method):
        self.file_obj = open(file_name, method)

    def __enter__(self):
        return self.file_obj

    def __exit__(self, type, value, traceback):
        print('with has handled exception')
        self.file_obj.close()
        return True
# with语句先暂存了MyFile类的__exit__方法
# 然后它调用MyFile类的__enter__方法
# __enter__方法打开文件并返回给with语句
# 打开的文件句柄被传递给f参数
# 我们使用.write()来写文件
# with语句调用之前暂存的__exit__方法
#    异常发生 :type,value和traceback传递给__exit__方法
#             __exit__返回True，异常就被处理了.返回True以外的任何东西，with将抛出异常
# __exit__方法关闭了文件
with MyFile('download.csv', 'r+') as f:
    f.write('this is from with key word')
with MyFile('download.csv', 'r+') as f:
    f.writenodefine('this is from with key word')    
# 基于生成器的实现 
# 装饰器(decorators)和生成器(generators)来实现上下文管理器
# 通过contextlib模块调用contextmanager函数返回一个GeneratorContextManager对象封装过的生成器
from contextlib import contextmanager
@contextmanager
def open_file(name):
    f = open(name, 'a')
    yield f
    f.close()
with open_file('download.csv') as f:
    f.write('write via contextmanager')