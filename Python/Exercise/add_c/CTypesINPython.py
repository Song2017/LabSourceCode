# Python可以轻松调用C代码
# CTypes A foreign function library for Python
# Python中的ctypes模块可能是Python调用C方法中最简单的一种。
# ctypes模块提供了和C语言兼容的数据类型和函数来加载dll/so文件，
# 因此在调用时不需对源文件做任何的修改。 

from ctypes import *

# import c lib
adder = CDLL('./adder.so')

# call c function add_int
res_int = adder.add_int(4,5)
print('4+5= ', res_int)

# call c function add_float
# Python中的十进制值转化为c_float类型，然后才能传送给C函数。有许多限制,例如并不能在C中对对象进行操作
a = c_float(5.5)
b=c_float(4.1)
adder.add_float.restype = c_float
res_float = adder.add_float(a,b)

print('5.5+4.1= ', res_float)


# SWIG 
# 适合多语言, 但是编写一个额外的接口文件来作为SWIG(终端工具)的入口

# Python/C API 简单，而且可以在C代码中操作你的Python对象
#module that talks to the C code
import addList
l = [1,23,4,5,6]
print("sum of List :", str(l), '=', str(addList.add(l))) 