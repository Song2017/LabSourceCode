# 6 模块
# 模块的目的是 更好的复用文件中的函数
# Python 提供了一个方法可以从文件中获取定义，在脚本或者解释器的一个交互式实例中使用。这样的文件被称为 模块
# 模块是包括 Python 定义和声明的文件。文件名就是模块名加上 .py 后缀。
# 模块的模块名（做为一个字符串）可以由全局变量 __name__ 得到 
import fibo
print('fibo.fib(10)', end=' ')
fibo.fib(10)
print('fibo.fib_ary(20)', fibo.fib_ary(20))
localfib = fibo.fib
localfib(55)    
# 每个模块都有自己私有的符号表，被模块内所有的函数定义作为全局符号表使用。
# 因此，模块的作者可以在模块内部使用全局变量，而无需担心它与某个用户的全局变量意外冲突
# 模块可以导入其他的模块 import 语句的一个变体直接从被导入的模块中导入命名到本模块的语义表
from fibo import fib, fib_ary
fib(56)

# 作为脚本来执行模块
# 通常用来为模块提供一个便于测试的用户接口（将模块作为脚本执行测试需求）
'''
python fibo.py 123
fib. __name__ __main__
1 1 2 3 5 8 13 21 34 55 89
'''
# 模块中的代码会被执行，就像导入它一样，不过此时 __name__ 被设置为 "__main__", 
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
print('sys.path',sys.path)

# 编译的python文件
# 为了加快加载模块的速度，Python 会在 __pycache__ 目录下以 module.version.pyc 名字缓存每个模块编译后的版本，
# 这里的版本编制了编译后文件的格式,这种命名约定允许由不同发布和不同版本的 Python 编译的模块同时存在。
#   为了减少一个编译模块的大小，你可以在 Python 命令行中使用 -O 或者 -OO。
#   -O 参数删除了断言语句，-OO 参数删除了断言语句和 __doc__ 字符串。
#   “优化的” 模块有一个 .pyo 后缀而不是 .pyc 后缀。未来的版本可能会改变优化的效果。
#   .pyc 文件或 .pyo 文件中的程序不会比来自 .py 文件的运行更快；.pyc 或 .pyo 文件只是在它们加载的时候更快一些。
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
# Python 带有一个标准模块库，并发布有独立的文档，名为 Python 库参考手册（此后称其为“库参考手册”） 
# sys ，这个模块内置于所有的 Python 解释器
# 交互模式下定义主提示符sys.ps1 和辅助提示符字符串 sys.ps2

# dir
# 内置函数 dir() 用于按模块名搜索模块定义，它返回一个字符串类型的存储列表
print('dir(fibo)',dir(fibo))
print('dir()',dir())

# Package 包
# 包通常是使用用“圆点模块名”的结构化模块命名空间, 可以避免全局变量之间的相互冲突
# 名为 A.B 的模块表示了名为 A 的包中名为 B 的子模块
# 为了让 Python 将目录当做内容包，目录中必须包含 __init__.py 文件。
# 这是为了避免一个含有烂俗名字的目录无意中隐藏了稍后在模块搜索路径中出现的有效模块，比如 string。
# 最简单的情况下，只需要一个空的 __init__.py 文件即可

# 包内引用
from subpack import effects
effects.echo()
from subpack.effects_1 import echo
echo()
'''
#　　文件夹被python解释器视作package需要满足两个条件：
#　　1、文件夹中必须有__init__.py文件，该文件可以为空，但必须存在该文件。
#　　2、不能作为顶层模块来执行该文件夹中的py文件（即不能作为主函数的入口）。
#       使用相对导入的时候一定要注意包路径和包的查找路径。要在最顶层的目录添加到 sys.path 中，或者 在最顶层运行脚本
#   ValueError: attempted relative import beyond top-level package
from ..Python_Advanced import PythonAdvanced_1
PythonAdvanced_1.test_asterisk('yasoob', 'python', 'eggs', 'test') 
''' 
# 多重目录中的包
# 包支持一个更为特殊的特性， __path__: https://docs.python.org/3/reference/import.html#__path__
# 在包的 __init__.py 文件代码执行之前，该变量初始化一个目录名列表。该变量可以修改，它作用于包中的子包和模块的搜索功能



# 字符串 
# Python 有办法将任意值转为字符串：将它传入 repr() 或 str() 函数。
# 函数 str() 用于将值转化为适于人阅读的形式，而 repr() 转化为供解释器读取的形式
s = 'Hello, world.'
print('str(s)',str(s))
print('repr(s)',repr(s))
#'!a' (应用 ascii())，'!s' （应用 str() ）和 '!r' （应用 repr() 
import math
print('The value of PI is approximately {!r}.'.format(math.pi))
print('The value of PI is approximately {0:.3f}.'.format(math.pi))
#命名来引用被格式化的变量 传入一个字典，用中括号( '[]' )访问它的键
table = {'Sjoerd': 4127, 'Jack': 4098, 'Dcab': 8637678}
print('Jack: {0[Jack]:d}; Sjoerd: {0[Sjoerd]:d}; '
          'Dcab: {0[Dcab]:d}'.format(table))
#‘**’ 将这个字典转换成关键字参数
print('Jack: {Jack:d}; Sjoerd: {Sjoerd:d}; Dcab: {Dcab:d}'.format(**table))         



# Class 类 
# 像模块一样，Python 的类并没有在用户和定义之间设立绝对的屏障，而是依赖于用户不去“强行闯入定义”的优雅。
# 另一方面，类的大多数重要特性都被完整的保留下来：
# 类继承机制允许多重继承，派生类可以覆盖（override）基类中的任何方法或类，可以使用相同的方法名称调用基类的方法。
# 对象可以包含任意数量的私有数据