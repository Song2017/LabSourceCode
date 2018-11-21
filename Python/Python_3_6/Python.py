# Python 简介
# 数字
# 除法(/)永远返回一个浮点数。
# // 整除； % 计算余数; ** 乘幂;  复数 j 或 J 表示虚数部分 3+5j
print(3+5j)


# 字符串
# 字符串可以视作字符数组, 支持切片和索引, 但它是不可变的
# 用单引号 ('...') 或双引号 ("...") 标识。\ 可以用来转义引号
print('"Isn\'t," she said.')  # "Isn't," she said.
# r raw 返回原是字符串
print(r'"Isn\'t," she said.')  # "Isn't," she said.
# 字符串文本能够分成多行。一种方法是使用三引号："""...""" 或者 '''...'''
# 行尾换行符会被自动包含到字符串中，但是可以在行尾加上 \ 来避免这个行为,没有第一行
print("""\
Usage: thingy [OPTIONS]
     -h                        Display this usage message
     -H hostname               Hostname to connect to
""")
# 字符串格式化操作 str.format（* args，** kwargs ）
print('the sum of {} + {} = {}'.format(1, 2, 3))

# 列表
# 中括号之间的一列逗号分隔的值。列表的元素不必是同一类型
# 列表可以被索引和切片, 并且列表是可变的
# 切片操作都会返回一个包含请求的元素的新列表(浅拷贝:传递对象的引用,并非对象里的值)
squares = [1, 4, 9, 16, 25, 36]
print('squares[:], squares[1], squares[-1], squares[-3:], [-1, 0]+squares',
      squares[:], squares[1], squares[-1], squares[-3:], [-1, 0]+squares)


# Python流程控制
# if
#x = int(input("please input an integer: "))
x = 0
if x < 0:
    print('{} is smaller than 0'.format(x))
elif x == 0:
    print('{} is equal to 0'.format(x))
elif x > 0:
    print('{} is bigger than 0'.format(x))
# for
words = ['cat', 'eat', 'fish', 'is so cute']
for w in words[:]:  # [:]: 返回原数组的浅拷贝对象
    if len(w) > 6:
        words.insert(-1, 'insert')
print(words)
# range() 函数
# range: 返回从0开始的可迭代对象, 能够像期望的序列返回连续项的对象
# -1 2: [-1, 5)
for i in range(-1, 5, 3):
    print(i)
# break, for..else
for n in range(2, 10):
    for i in range(2, n):
        if n % i == 0:
            print(n, '=', i, '*', n//i)
            break
    else:
        print(n, 'is a prime number')
# continue
for num in range(2,10):
    if num % 2 == 0:
        print('even number: ', num)
        continue
    print('odd number:', num)
# pass
# pass 可以在创建新代码时用来做函数或控制体的占位符
# pass 可以默默的被忽视
i=0
while i<10:
    print(i, end='... ')
    pass
    i+=1
print()


# 函数 def
# 关键字 def 引入了一个函数 定义。在其后必须跟有函数名和包括形式参数的圆括号。
# 函数体语句从下一行开始，必须是缩进的
def fib(n):
    """print a fibonacci series up to n"""
    a, b = 0,1# tuple
    while a < n:
        print(a, end='... ')
        a,b=b, a+b
    n = n+1
    print()
# 函数 调用 会为函数局部变量生成一个新的符号表。
# 所有函数中的变量赋值都是将值存储在局部符号表。
# 变量引用首先在局部符号表中查找，然后是包含函数的局部符号表，然后是全局符号表，最后是内置名字表。
# 因此，全局变量不能在函数中直接赋值（除非用 global 语句命名），尽管他们可以被引用。
fib(10)
# 函数引用的实际参数在函数调用时引入局部符号表，因此，实参总是 传值调用 
# 这里的 值 总是一个对象 引用 ，而不是该对象的值. 基本值类型传入的是值, 不会影响实参原来的值
class SimpleClass:
    name = 'simpleclass'
def SimpleClassFunction(sc):
    print(sc.name)
    sc.color='red'
simpleClass = SimpleClass()
SimpleClassFunction(simpleClass)
print(simpleClass.color) #red
# 一个函数定义会在当前符号表内引入函数名。
# 函数名指代的值（即函数体）有一个被 Python 解释器认定为 用户自定义函数 的类型。 
# 这个值可以赋予其他的名字（即变量名），然后它也可以被当做函数使用
f = fib
f(5)
# return 语句从函数中返回一个值，不带表达式的 return 返回 None
print(fib(0))
# 默认参数
# 为一个或多个参数指定默认值。这会创建一个可以使用比定义时允许的参数更少的参数调用的函数
# 默认值在函数 定义 作用域被解析, 默认值的赋值发生在函数定义时期.默认值只被赋值一次
# 调用时传入的实参值会覆盖掉默认值。
# 这使得当默认值是可变对象时会有所不同，比如列表、字典或者大多数类的实例
i = 5
def f_default_para(a=i, L=[]):
    L.append(a)
    return L
i = 6
print(f_default_para())# [5]    ! no 6
print(f_default_para())# [5, 5] 
print(f_default_para(i))# [5, 5, 6] # 实参为6
  
# 可选参数
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
test_args('yasoob', 'python', 'eggs', 'test', 123123, name = 'yasoob')
# * 操作符来自动把参数列表拆开
# ** 操作符分拆关键字参数为字典
args = [3, 6]
list(range(*args))  # 等价于list(range(3,6))
# 关键字参数 keyword = value
def parrot(voltage, state='a stiff', action='voom', type='Norwegian Blue'):
    print("action, state, type: ", action, state,type, end=' .. ')
    print("voltage: ", voltage)
parrot(action='VOOOOOM', voltage=1000000)
parrot('a million', 'bereft of life', 'jump')
"""
parrot()                     # required argument missing
parrot(voltage=5.0, 'dead')  # non-keyword argument after a keyword argument
parrot(110, voltage=220)     # duplicate value for the same argument
parrot(actor='John Cleese')  # unknown keyword argument
"""    


# Lambda 匿名函数
# 通过 lambda 关键字，可以创建短小的匿名函数 lambda a, b: a+b
# 语义上讲，它们只是普通函数定义中的一个语法技巧。类似于嵌套函数定义，lambda 形式可以从外部作用域引用变量
