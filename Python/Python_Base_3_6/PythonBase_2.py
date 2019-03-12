# 6 模块
# 模块的目的是 更好的复用文件中的函数
# Python 提供了一个方法可以从文件中获取定义,在脚本或者解释器的一个交互式实例中使用.这样的文件被称为 模块
# 模块是包括 Python 定义和声明的文件.文件名就是模块名加上 .py 后缀.
# 模块的模块名(做为一个字符串)可以由全局变量 __name__ 得到
import fibo
print('fibo.fib(10)', end=' ')
fibo.fib(10)
print('fibo.fib_ary(20)', fibo.fib_ary(20))
localfib = fibo.fib
localfib(55)
# 每个模块都有自己私有的符号表,被模块内所有的函数定义作为全局符号表使用.
# 因此,模块的作者可以在模块内部使用全局变量,而无需担心它与某个用户的全局变量意外冲突
# 模块可以导入其他的模块 import 语句的一个变体直接从被导入的模块中导入命名到本模块的语义表
from fibo import fib, fib_ary
fib(56)

# 作为脚本来执行模块
# 通常用来为模块提供一个便于测试的用户接口(将模块作为脚本执行测试需求)
'''
python fibo.py 123
fib. __name__ __main__
1 1 2 3 5 8 13 21 34 55 89
'''
# 模块中的代码会被执行,就像导入它一样,不过此时 __name__ 被设置为 "__main__",
# 通过import导入后调用__name__ 被设置为 模块名称 fibo
'''
# 在脚本的最后加上 
 if __name__ == "__main__":
    import sys
    fib(int(sys.argv[1]))
'''

# 模块的搜索路径
# 导入fibo模块时, 解释器会到sys.path指定的路径下搜索模块
#    解释器会先在当前目录下搜索名为fibo.py的文件
#    没有找到的话,会到环境变量PythonPath的目录列表中搜索
#    仍没有找到的话, 会到Python默认安装路径中搜索
import sys
print('sys.path', sys.path)

# 编译的python文件
# 为了加快加载模块的速度,Python 会在 __pycache__ 目录下以 module.version.pyc 名字缓存每个模块编译后的版本,
# 这里的版本编制了编译后文件的格式,这种命名约定允许由不同发布和不同版本的 Python 编译的模块同时存在.
#   为了减少一个编译模块的大小,你可以在 Python 命令行中使用 -O 或者 -OO.
#   -O 参数删除了断言语句,-OO 参数删除了断言语句和 __doc__ 字符串.
#   "优化的" 模块有一个 .pyo 后缀而不是 .pyc 后缀.未来的版本可能会改变优化的效果.
#   .pyc 文件或 .pyo 文件中的程序不会比来自 .py 文件的运行更快；.pyc 或 .pyo 文件只是在它们加载的时候更快一些.
#   compileall 模块可以为指定目录中的所有模块创建 .pyc 文件
#   https://docs.python.org/3/library/compileall.html#module-compileall
'''
import compileall
compileall.compile_dir('../Python_Base_3_6/', force=True)
# Perform same compilation, excluding files in .svn directories.
import re
compileall.compile_dir('../Python_Base_3_6/', rx=re.compile(r'[/\\][.]svn'), force=True)
# pathlib.Path objects can also be used.
import pathlib
compileall.compile_dir(pathlib.Path('../Python_Base_3_6/'), force=True)
'''
# 标准模块
# Python 带有一个标准模块库,并发布有独立的文档,名为 Python 库参考手册(此后称其为"库参考手册")
# sys ,这个模块内置于所有的 Python 解释器
# 交互模式下定义主提示符sys.ps1 和辅助提示符字符串 sys.ps2

# dir
# 内置函数 dir() 用于按模块名搜索模块定义,它返回一个字符串类型的存储列表
print('dir(fibo)', dir(fibo))
print('dir()', dir())

# Package 包
# 包通常是使用用"圆点模块名"的结构化模块命名空间, 可以避免全局变量之间的相互冲突
# 名为 A.B 的模块表示了名为 A 的包中名为 B 的子模块
# 为了让 Python 将目录当做内容包,目录中必须包含 __init__.py 文件.
# 这是为了避免一个含有烂俗名字的目录无意中隐藏了稍后在模块搜索路径中出现的有效模块,比如 string.
# 最简单的情况下,只需要一个空的 __init__.py 文件即可

# 包内引用
from subpack import effects
effects.echo()
from subpack.effects_1 import echo
echo()
'''
#　　文件夹被python解释器视作package需要满足两个条件：
#　　1、文件夹中必须有__init__.py文件,该文件可以为空,但必须存在该文件.
#　　2、不能作为顶层模块来执行该文件夹中的py文件(即不能作为主函数的入口).
#       使用相对导入的时候一定要注意包路径和包的查找路径.要在最顶层的目录添加到 sys.path 中,或者 在最顶层运行脚本
#   ValueError: attempted relative import beyond top-level package
from ..Python_Advanced import PythonAdvanced_1
PythonAdvanced_1.test_asterisk('yasoob', 'python', 'eggs', 'test') 
'''
# 多重目录中的包
# 包支持一个更为特殊的特性, __path__: https://docs.python.org/3/reference/import.html#__path__
# 在包的 __init__.py 文件代码执行之前,该变量初始化一个目录名列表.该变量可以修改,它作用于包中的子包和模块的搜索功能


# 字符串
# Python 有办法将任意值转为字符串：将它传入 repr() 或 str() 函数.
# 函数 str() 用于将值转化为适于人阅读的形式,而 repr() 转化为供解释器读取的形式
s = 'Hello, world.'
print('str(s)', str(s))
print('repr(s)', repr(s))
# '!a' (应用 ascii()),'!s' (应用 str() )和 '!r' (应用 repr()
import math
print('The value of PI is approximately {!r}.'.format(math.pi))
print('The value of PI is approximately {0:.3f}.'.format(math.pi))
# 命名来引用被格式化的变量 传入一个字典,用中括号( '[]' )访问它的键
table = {'Sjoerd': 4127, 'Jack': 4098, 'Dcab': 8637678}
print('Jack: {0[Jack]:d}; Sjoerd: {0[Sjoerd]:d}; '
      'Dcab: {0[Dcab]:d}'.format(table))
# ‘**’ 将这个字典转换成关键字参数
print('Jack: {Jack:d}; Sjoerd: {Sjoerd:d}; Dcab: {Dcab:d}'.format(**table))


# Class 类
# 像模块一样,Python 的类并没有在用户和定义之间设立绝对的屏障,而是依赖于用户不去"强行闯入定义"的优雅.
# 另一方面,类的大多数重要特性都被完整的保留下来：
# 类继承机制允许多重继承,派生类可以覆盖(override)基类中的任何方法或类,可以使用相同的方法名称调用基类的方法.
# 对象可以包含任意数量的私有数据
# Python 作用域和命名空间
# 命名空间 是从命名到实例对象的映射. 通过python字典实现
# 不同的命名空间在不同的时刻创建,有不同的生存期:
#   包含内置命名的命名空间在 Python 解释器启动时创建,会一直保留.模块的全局命名空间在模块定义被读入时创建
#   调用函数时,就会为它创建一个局部命名空间,并且在函数返回或抛出一个并没有在函数内部处理的异常时被删除
# 作用域 就是一个 Python 程序可以直接访问命名空间的正文区域
# python引用变量的顺序： 当前作用域局部变量->外层作用域变量->当前模块中的全局变量->python内置变量
# 尽管作用域被静态的定义, 但他们使用时是动态的
#   首先搜索最内层的作用域,它包含局部命名任意函数包含的作用域,
#       是内层嵌套作用域搜索起点,包含非局部,但是也非全局的命名
#   接下来的作用域包含当前模块的全局命名
#   最外层的作用域(最后搜索)是包含内置命名的命名空间
# nolocal, global
# nolocal: https://docs.python.org/3/reference/simple_stmts.html#nonlocal
# 使用当前函数或块级作用域的外层作用域(非全局)中的变量;可以取多次嵌套后的外层变量
# global: https://docs.python.org/3/reference/simple_stmts.html#global
# 全局变量在函数或块级作用域内有读权限没有写权限, global用来赋予写权限
# !!! nolocal只是引用, 不能引用在外层作用域中未声明的变量; global可以直接声明
def scope_test():
    def fun_local():
        # 1 spam作用域只局限于fun_local内部
        spam = 'local spam'

    def fun_nolocal():
        # 2 nonlocal将spam提升到scope_test函数的作用域
        nonlocal spam
        spam = 'nolocal spam'

        def fun_localInlocal():
            nonlocal spam
            spam = 'fun_localInlocal spam'
            print('IN fun_localInlocal', spam)
        fun_localInlocal()

    def fun_global():
        # 3 global将spam提升到scope_test函数所在模块的作用域
        global spam
        spam = 'global spam'
    # 4 spam作用域为scope_test内部
    spam = 'test spam'
    # test spam: fun_local里的spam未被访问, 下方spam实际为#4
    fun_local()
    print('after local assignment:', spam)
    # nolocal spam: fun_nolocal.spam被提升到scope_test作用域, spam从test spam重新赋值为nolocal spam
    fun_nolocal()
    print('after nolocal assignment:', spam)
    # nolocal spam: fun_global.spam被提升出scope_test作用域,等同于#5
    # 所以下方的spam仍然指向#4, fun_global内改变的是#5
    fun_global()
    print('after global assignment:', spam)


# 5
spam1 = 'global out'
scope_test()
# global spam: fun_global函数内被重新赋值
print('In global scope:', spam)
# 类定义
'''
class ClassName:
    <statement-1>
    ...
    <statement-N>
'''


class MyClass:
    """A simple example class"""
    i = 123

    def func(self):
        return 'hello world: ' + str(self.i)


# 类对象支持两种操作：属性引用和实例化
# 实例化 使用函数符号() 将类对象看作是一个返回新的类实例的无参数函数
myClass = MyClass()
# 属性引用 obj.name 类对象创建后,类命名空间中所有的命名都是有效属性名
# 123 <function MyClass.func at 0x01EE9618> 123 hello world: 123
print('MyClass.i, MyClass.func, myClass.i, myClass.func(): ',
      MyClass.i, MyClass.func, myClass.i, myClass.func())

# __new__(): 在创建类实例时发生调用. https://docs.python.org/3/reference/datamodel.html#object.__new__
# __init__(self[, ...]): 在类实例创建(__new__())后但还未返回给调用者时调用
# 多用来初始化对象的属性, 视作构造函数; 返回None将抛出TypeError错误


class Complex():
    def __init__(self, real=0, imag=0):
        self.r = real
        self.i = imag


x = Complex(1, 2)
print('x, x.i, x.r', x, x.i, x.r)

# 实例对象
# 实例对象唯一可用的操作是属性引用, 包括数据引用和方法引用
# 数据对象是类实例的属性, Python是动态语言,根据类创建的实例可以任意绑定属性
# 这意味着不仅可以引用类中定义的属性, 实例自身可以再绑定, 但会增加性能成本,
# __slot__可以限制这种任意绑定的行为, 删除属性 del x.counter
x.counter = 1
x.counter = x.counter + 1
print('x.counter, x.i', x.counter, x.i)
del x.counter
del x.i
# AttributeError: 'Complex' object has no attribute 'i'
# print('x, x.i, x.r',x, x.i, x.r)
# 方法对象 myClass.func()
# 工作原理: 引用非数据属性的实例属性时,会搜索它的类.
#   如果这是有效的函数对象类属性,就会将实例对象和函数对象封装进一个抽象对象：这就是方法对象
#   以一个参数列表调用方法对象时,它被重新拆封,
#   用实例对象和原始的参数列表构造一个新的参数列表,然后函数对象调用这个新的参数列表
# myClass.func 是一个方法对象,它可以存储起来以后调用
myFunc = myClass.func()
print('myFunc', myFunc)
# 类实例.fun() = 类.fun(类实例)
print('myClass.func(), MyClass.func(myClass)',
      myClass.func(), MyClass.func(myClass))

# 类变量和实例变量
# 实例变量用于对每一个实例都是唯一的数据,类变量用于类的所有实例共享的属性和方法
# 可变对象, 例如列表和字典, 作为类变量声明时, 即使作为实例变量初始化也会被所有类实例共享
#       可变对象不应该作为类变量, 若不想被共享, 应该作为实例变量被声明


class Dog:
    classList = []

    def __init__(self, name):
        self.name = name
        # 不会被所有类实例共享
        self.insList = []

    def add_classList(self, tricks):
        self.classList.append(tricks)
        self.insList.append(tricks)


d = Dog('Fido')
e = Dog('Buddy')
d.add_classList('roll over')
e.add_classList('play dead')
# d.classList, d.insList:  ['roll over', 'play dead'] ['roll over']
print('d.classList, d.insList: ', d.classList, d.insList)

# Note
# 数据属性会覆盖同名的方法属性.为了避免意外的名称冲突, 做一些约定
#   大写方法名称的首字母,使用一个唯一的小字符串(也许只是一个下划线)作为数据属性名称的前缀,或者方法使用动词而数据属性使用名词
# 数据属性可以被方法引用,也可以由一个对象的普通用户(客户)使用.
#   客户应该谨慎的使用数据属性, 客户可以向一个实例对象添加他们自己的数据属性,而不会影响方法的正确性
# 类不能用来实现纯净的数据类型
# 从方法内部引用数据属性(或其他方法)并没有快捷方式, nolocal, global
# 方法的第一个参数被命名为 self.这仅仅是一个约定：
#   对 Python 而言,名称 self 绝对没有任何特殊含义, 但有些 类查看器 程序也可能是遵循此约定编写
# 类属性的任何函数对象都为那个类的实例定义了一个方法.
#   函数定义代码不一定非得定义在类中：也可以将一个函数对象赋值给类中的一个局部变量


def f1(self, x, y):
    return min(x, y)


class C:
    f = f1

    def g(self):
        return 'hello world'
    # h 严格等于g
    h = g


c = C()
print('c.f(1,-1), c.h()', c.f(1, -1), c.h())
# 通过 self 参数的方法属性,方法可以调用其它的方法


class Bag:
    def __init__(self):
        self.data = []

    def add(self, x):
        self.data.append(x)

    def add2(self, x):
        self.add(x)
        self.add(x)


b = Bag()
b.add2('this is going to be added twice')
print(b.data)
# 每个值都是一个对象,因此每个值都有一个 类( class ) (也称为它的 类型( type ) ),它存储为 object.__class__
# 全局作用域确有很多合法的用途：其一是方法可以调用导入全局作用域的函数和方法,也可以调用定义在其中的类和函数

# 类继承
'''
# 基类与派生类定义在一个作用域内
class DerivedClassName(BaseClassName):
    <statement-1>
    ...
    <statement-N>
# 基类定义在另一个模块
class DerivedClassName(modname.BaseClassName):
    <statement-1>
    ...
    <statement-N>    
'''
# 派生类定义的执行过程和基类是一样的.
#   构造派生类对象时,就记住了基类.这在解析属性引用的时候尤其有用：如果在类中找不到请求调用的属性,就搜索基类.
#   如果基类是由别的类派生而来,这个规则会递归的应用上去.
# 派生类可能会覆盖其基类的方法,Python 中的所有方法本质上都是 虚 方法
# 派生类中的覆盖方法扩充基类中的重名方法, 调用基类方法然后拓展,
#   调用方式：BaseClassName.methodname(self, arguments)
# Python中两个用于继承的函数
#   函数 isinstance() 用于检查实例类型： isinstance(obj, int)
#   函数 issubclass() 用于检查类继承： issubclass(bool, int) 为 True

# 多继承
'''
# 动态的线性化算法,super()调用方法的优先级为从左到右的, 有高到低 
# 父类的父类优先级比父类更低: Base1 > Base2 > Base
class DerivedClassName(Base1, Base2):
    <statement-1>
    ...
    <statement-N>
'''


class Base(object):
    def echo(self):
        print('Base')

    def echoBase(self):
        print('Base')


class Base1(Base):
    def echo(self):
        print('Base--1')


class Base2(Base):
    def echo(self):
        print('Base--2')


class Derived(Base1, Base2):
    def echo(self):
        super().echo()
        print('Derived')


d = Derived()
# Base--1 Derived
d.echo()
# Base
d.echoBase()

# 私有变量
# 只能从对像内部访问的"私有"实例变量,在 Python 中不存在.
# 变通的方法：以一个下划线开头的命名(包括属性和函数),例如 _spam会被处理为 API 的非公开部分


class Mapping:
    __test = 'test'

    def __init__(self, iterable):
        self.items_list = []
        self.__update(iterable)

    def update(self, iterable):
        for item in iterable:
            self.items_list.append(item)
    # __update是基类方法私有的, 不会被子类重写
    __update = update


m = Mapping(['iter1', 'iter2'])
# m.__test # 'Mapping' object has no attribute '__test'
print(m.items_list)


class MappingSub(Mapping):
    # def __init__(self):self.items_list = []
    # 子类重写了基类的update(), 但无法修改__update,
    # 不能重写__init__, 会破坏基类中调用__init__
    def update(self, keys, values):
        for item in zip(keys, values):
            self.items_list.append(item)


msub = MappingSub('BASE')
msub.update('qwe', '1234')
# ['B', 'A', 'S', 'E', ('q', '1'), ('w', '2'), ('e', '3')]
print(msub.items_list)

# 结构体
# 通过创建空的类,作为结构体类型


class Employee:
    __slots__ = ["name", "dept", "salary"]


john = Employee()
# Fill the fields of the record
john.name = 'John Doe'
john.dept = 'computer lab'
john.salary = 1000
print('john.name,john.dept,john.salary', john.name, john.dept, john.salary)

# 用户自定义异常
# 用户自定义异常类要继承Exception或其派生类
# 抛出异常 raise Class/Class()
# raise B # __main__.B: B ErrorInfo
# raise B() #__main__.B: B ErrorInfo


class B(Exception):
    def __init__(self):
        super().__init__(self)  # 初始化父类
        self.errorinfo = 'B ErrorInfo'

    def __str__(self):
        return self.errorinfo


class CC(B):
    pass


class D(CC):
    pass


# 异常的抛出顺序: 抛出第一个相符的异常. 这就是说, 如果将异常的基类放在第一个匹配的位置, 它的子类异常就没有机会匹配
# 如果B在最前会打印: B B B
for cls in [B, CC, D]:
    try:
        raise cls()
    except D:
        print("D", end=' ')
    except CC:
        print("CC", end=' ')
    except B:
        print("B", end=' ')

# 迭代器
# for语句在容器类中会调用__iter__(), 该函数返回一个定义了 __next__() 方法的迭代器对象,它在容器中逐一访问元素.
# 没有后续的元素时, __next__() 抛出一个 StopIteration 异常通知 for 语句循环结束
# 实现迭代器机制: 定义一个返回__next__()方法返回值的__iter__()函数, 如果已经定义了__next__(), 只要返回self


class Reverse:
    def __init__(self, data):
        self.data = data
        self.index = len(data)

    def __next__(self):
        if self.index <= 0:
            raise StopIteration
        self.index -= 1
        return self.data[self.index]

    def __iter__(self):
        return self


# f d s a
for item in Reverse('asdf'):
    print(item, end=' ')
# 生成器
# 生成器(Generators): 生成器是只迭代一次的迭代器.这是因为它们并没有把所有的值存在内存中,而是在运行时生成值.
#    通过yield每次返回一个单次运行的值, 而不是直接返回占用大量空间的一个值
#    调用:用for循环,或可进行迭代的函数或结构
#    next(): 它允许我们获取一个序列的下一个元素. yield所有值后会触发 StopIteration exception
#       next() 被调用时,生成器回复它脱离的位置（它记忆语句最后一次执行的位置和所有的数据值）
#    生成器是数据的生产者 协程则是数据的消费者. yield可获得一个协程.协程会消费掉发送给它的值
# 生成器表达式 range, zip
#set(word  for line in page  for word in line.split())
#max((student.gpa, student.name) for student in graduates)
from math import pi, sin
sine_table = {x: sin(x*pi/180) for x in range(0, 91)}
print('sine_table ', sine_table)
xvec = [10, 20, 30]
yvec = [7, 5, 3]
print(sum(x*y for x, y in zip(xvec, yvec)))
