# Python 进阶


# Global和Return
# Return 返回结果,变量,函数,类...
# 返回多个值可以用 元组（常用）,列表,字典
def profile():
    name = 'benji'
    age = 30
    return name,age #等价于(name,age) 元组的括号可以省略
p_data = profile()
print(p_data[0],p_data[1])
# global 变量意味着我们可以在函数以外的区域都能访问这个变量 
# 尽量不要使用


# Mutation和Immutation
# python中的所有东西都是一个object,所以每个变量都包含对象实例。
# 启动对象时,会为其分配一个唯一的object id,可以通过id（object）获得。 is 运算符判断object的id是否相等
# 对象的类型在运行时定义,一旦设置永远不会改变,但可以重新定义,可以通过type（object）获得 
# 但对象的状态（值）有的是可以改变的,这就是可变对象,反之,为不可变对象
# 对某种数据类型可变性的具体定义,应该看变量的具体使用情况,而不是通过id方法获取的内存地址。
#   内存地址体现的是底层实现, 使用的结果才是我们应该关心的 
asfd='...asd'
print('\nid(asfd)', id(asfd),"\nid('...asd')", id('...asd'))
'''
>>> asd = '...asd'
>>> id(asd)
11405856
>>> id('...asd')
11406144
'''
# 可变对象： list,dict,set,byte array
# 不可变对象：int,float,complex,string,tuple,frozen set [注意：set的不可变版本],bytes
a='asd'
print("a='asd'\na is 'asd' ", a is 'asd', '\nid(a)', id(a), "\nid('asd')", id('asd'))
b=[1]
print("b=[1]\nb is [1] ", b is [1], '\nid(b)', id(b), "\nid([1])", id([1]))
# 不可变对象的不可变性是指对象本身不可变,其组成元素可能可变 
# 例如 元组（12,[1,2,3]）没有改变自身元素的方法,但其组成元素[1,2,3]是可变的
# 按值传递: 入参是不可变对象,经过函数运算后,入参的值不发生改变
# 按引用传递: 入参是可变对象,经过函数运算后,原入参的值发生改变


# __slots__ 魔法方法
# 在Python中，每个类都有实例属性。Python是动态语言，根据类创建的实例可以任意绑定属性
# 默认情况下Python用一个字典来保存一个对象的实例属性，这允许我们在运行时去设置任意的新属性，
# __slots__来告诉Python不要使用字典，而只给一个固定集合的属性分配空间
# name是类属性，score是实例属性。同名时实例属性会覆盖掉类属性
class Student(object):
    # 使用__slots__后将不能再使用实例属性:AttributeError: 'Student' object has no attribute 'score'
    # 只给一个固定集合的属性分配空间,使用的内存可降低40%-50%
    # ipython_memory_usage: 内存使用检测工具
    # __slots__ = ['name']
    def __init__(self, name):
        self.name = name 
s = Student('Bob')
s.score = 90
print(s.name, ' has score ',s.score)


# 虚拟环境 virtualenv
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


# Collections 容器
# Python附带一个模块，它包含许多容器数据类型，名字叫作collections
# defaultdict: 不需要检查key是否存在,是否重复
from collections import defaultdict
colours = (('Yasoob', 'Yellow'), ('Ali', 'Blue'),('Yasoob', 'Red'), ('Ahmed', 'Silver'))
favourite_colours = defaultdict(list)
for name, colour in colours:
    favourite_colours[name].append(colour)
print(favourite_colours)
# 字典中对一个键进行嵌套赋值
import collections
tree = lambda: collections.defaultdict(tree)
some_dict = tree()
some_dict['colours']['favourite'] = "yellow"
