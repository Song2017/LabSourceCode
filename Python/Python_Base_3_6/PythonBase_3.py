# 10 Python 标准库概览
# 1. 操作系统接口, os 模块提供与操作系统交互的函数
# OS routines for NT or Posix depending on what system we're on
# 应该使用import os 风格而非 from os import *。
# 这样可以保证随操作系统不同而有所变化的 os.open() 不会覆盖内置函数 open()
import os
path = r"C:\_Git\LabSourceCode\Python\Python_Base_3_6"
todaypath = "C:\\_Git\\LabSourceCode\\Python\\Python_Base_3_6\\today\\"
# get current working directory
print('os.getcwd()', os.getcwd())
# Change current working directory
os.chdir(path)
# Run the command mkdir in the system shell
newfolder = "if not exist " + todaypath + " ( mkdir today )"
os.system(newfolder)
#print('dir(os), help(os)',dir(os), help(os))
# shutil 高层面的文件操作接口
import shutil
print(shutil.copyfile('fibo.py', r'today\fibo_copy.py'))
#shutil.move('/build/executables', 'installdir')

# 2 文件通配符
import glob 
print(glob.glob('*.py'))
print(glob.glob('fibo.*'))

# 3 命令行参数
# 通用工具脚本经常调用命令行参数。这些命令行参数以链表形式存储于 sys 模块的 argv 变量: sys.argv
# python demo.py one two three

# 4 错误输出重定向和程序终止
# sys 还有 stdin， stdout 和 stderr 属性，即使在 stdout 被重定向时，后者也可以用于显示警告和错误信息
# 大多脚本的直接终止都使用 sys.exit()
import sys
sys.stderr.write('Warning, log file not found starting a new one\n')
# sys.exit()
sys.stdout.write('Stdout, log file not found starting a new one\n')

# 5 字符串正则匹配
import re
# *: >=0; +:>=1; ?:0/1
# *?, =?, ?? 非贪婪匹配
# re.findall（pattern，string，flags = 0 ）
# ['foot', 'fell', 'fastest']
print(re.findall(r'\bf[a-z]*', 'which foot or hand fell fastest'))
# re.sub（pattern，repl，string，count = 0，flags = 0 ）
# 返回通过替换repl替换字符串中最左边的非重叠模式而获得的字符串
# ??? \number 匹配相同编号的组的内容 组从1开始编号
# cat in the hat
print(re.sub(r'(\b[a-z]+) \1', r'\1', 'cat cat in the the hat'))

# 6 数学 
import math
#不是0, 非常接近0 6.123233995736766e-17
print('math.cos(math.pi/2)',math.cos(math.pi/2))
#10.0
print(math.log(1024, 2))
import random
# 从非空序列seq返回一个随机元素
print("random.choice('asdfghjkl')",random.choice('asdfghjkl'))
# 返回从序列或集合中选择的k长度的元素列表。用于随机抽样而无需更换
print(random.sample(range(100),10))
print(random.randrange(0,111,11))

# 7 互联网访问
url=r'https://blog.csdn.net/sgs595595/article/details/81747397'
'''
# 简单的 pip install requests
import requests
session = requests.session()
html = session.get(url).content
print('requests', len(html))
# 简单的 pip install urllib3
import urllib3, certifi
http = urllib3.PoolManager()
html = http.request('GET', url)
print(len(html.data))

# 邮件
import smtplib
server = smtplib.SMTP('smtp.live.com') 
server.sendmail('bensong2017@hotmail.com', 'guangshun.song@bhge.com',
" to 'guangshun.song@bhge.com' from 'bensong2017@hotmail.com': send via python smtplib")
'''

# 8 日期和时间 
# https://docs.python.org/3/library/datetime.html#module-datetime 
# https://docs.python.org/3/library/time.html#module-time
# https://docs.python.org/3/library/calendar.html#module-calendar
# 支持日期和时间算法的同时，实现的重点放在更有效的处理和格式化输出。该模块还支持时区处理 
from datetime import date
now = date.today()
print('date.today()', now)
# stringformattime: Return a string representing the date, controlled by an explicit format string
print('now.strftime("%m-%d-%y. %d %b %Y is a %A on the %d day of %B.")', 
    now.strftime("%m-%d-%y. %d %b %Y is a %A on the %d day of %B."))
MyBirthday = date(1992,4,20)
age = now - MyBirthday
print('age.days ',age.days)

# 9. 数据压缩
# https://docs.python.org/3/library/zlib.html#module-zlib 
import zlib
s = b'this is a zlib sample string, this is a zlib sample string2'
print("len(s)",len(s))
t = zlib.compress(s, level=9)
print("len(t) ,t",len(t), t)
print('zlib.decompress(t)', zlib.decompress(t))
# zlib.crc32(data[, value]): computes a CRC (Cyclic Redundancy Check) checksum of data
print("zlib.crc32(s), zlib.crc32(zlib.decompress(t))",zlib.crc32(s), zlib.crc32(zlib.decompress(t)))

# 10 性能度量
# [timeit: small bits of Python code](https://docs.python.org/3/library/timeit.html#module-timeit)
import timeit
from timeit import Timer
print("Timer('t=a; a=b; b=t', 'a=1;b=2').timeit(number=1000000)",
      Timer('t=a; a=b; b=t', 'a=1;b=2').timeit(number=1000000))
print("timeit.timeit('t=a; a=b; b=t', 'a=1;b=2', number=1000000)",
      timeit.timeit('t=a; a=b; b=t', 'a=1;b=2', number=1000000))
print("Timer('a,b = b,a', 'a=1;b=2').timeit(number=1000000)",
      Timer('a,b = b,a', 'a=1;b=2').timeit(number=1000000))
print("timeit.timeit('a,b = b,a', 'a=1;b=2', number=1000000)",
      timeit.timeit('a,b = b,a', 'a=1;b=2', number=1000000))
# 对大代码块的时间度量工具
# [profile](https://docs.python.org/3/library/profile.html#module-profile)
# [pstats](https://docs.python.org/3/library/profile.html#module-pstats)
# calibrate: 该方法直接在分析器下执行参数给出的Python调用次数，测量两者的时间。然后，它计算每个探查器事件的隐藏开销，并将其作为浮点数返回
import profile
pr = profile.Profile()
for i in range(3):
    print('pr.calibrate(int(1e4)) ',pr.calibrate(int(1e4)))

# 11 质量控制
# doctest 模块提供了一个工具，扫描模块并根据程序中内嵌的文档字符串执行测试 
# https://docs.python.org/3/library/doctest.html#module-doctest
# python PythonBase_3.py -v
def factorial(n):
    """Return the factorial of n, an exact integer >= 0.

    >>> [factorial(n) for n in range(6)]
    [1, 1, 2, 6, 24, 120]
    >>> factorial(30)
    265252859812191058636308480000000
    >>> factorial(-1)
    Traceback (most recent call last):
        ...
    ValueError: n must be >= 0

    Factorials of floats are OK, but the float must be an exact integer:
    >>> factorial(30.1)
    Traceback (most recent call last):
        ...
    ValueError: n must be exact integer
    >>> factorial(30.0)
    265252859812191058636308480000000

    It must also not be ridiculously large:
    >>> factorial(1e100)
    Traceback (most recent call last):
        ...
    OverflowError: n too large
    """ 
    import math
    if not n >= 0:
        raise ValueError("n must be >= 0")
    if math.floor(n) != n:
        raise ValueError("n must be exact integer")
    if n+1 == n:  # catch a value like 1e300
        raise OverflowError("n too large")
    result = 1
    factor = 2
    while factor <= n:
        result *= factor
        factor += 1
    return result
if __name__ == "__main__":
    import doctest
    doctest.testmod()

# unittest 模块不像 doctest 模块那么容易使用，不过它可以在一个独立的文件里提供一个更全面的测试集
# https://docs.python.org/3/library/unittest.html#module-unittest
# python PythonBase_3.py
# after run unittest.main(), script will exit
import unittest
class TestStringMethods(unittest.TestCase):
    def test_upper(self):
        self.assertEqual('foo'.upper(), 'FOO')
    def test_isUpper(self):
        self.assertTrue('FOO'.isupper())
        self.assertFalse('Foo'.isupper())
    def test_split(self):
        s = 'hello world'
        self.assertEqual(s.split(), ['hellos','world'])
        with self.assertRaises(TypeError):
            s.split(2)
#if __name__ == '__main__':
#    unittest.main()
 


# 标准库 Part 2
# 支持专业编程工作所需的更高级的模块
# 1. 输出格式
# reprlib https://docs.python.org/3/library/reprlib.html#module-reprlib
# reprlib 模块为大型的或深度嵌套的容器缩写显示提供了repr()函数的一个定制版本 
import reprlib
print("reprlib.repr(set('https://docs.python.org/3/library/reprlib.html#module-reprlib'))", 
    reprlib.repr(set('https://docs.python.org/3/library/reprlib.html#module-reprlib')))
# pprint data pretty printer:一种解释器可读的方式深入控制内置和用户自定义对象的打印
# https://docs.python.org/3/library/pprint.html#module-pprint
import pprint 
t = [[['black', 'cyan'], 'white', ['green','red']],[['blue','yellow','red']] ]
pprint.pprint(t,width=50)
# textwrap 模块格式化文本段落以适应设定的屏宽
# https://docs.python.org/3/library/textwrap.html#module-textwrap
import textwrap
doc = '''When you are old and grey and full of sleep, and nodding by the fire, take down this book,
and slowly read, and dream of the soft book '''
print(textwrap.fill(doc, width=60))
# locale 模块按访问预定好的国家信息数据库
# https://docs.python.org/3/library/locale.html#module-locale
import locale
print("locale.setlocale(locale.LC_ALL, 'English_United States.1252') ",
    locale.setlocale(locale.LC_ALL, 'English_United States.1252'))
conv = locale.localeconv()
x = 1234567489.1
print('locale.format_string("%d", x, grouping=True) ', 
    locale.format_string("%d", x, grouping=True))
print ("locale.format_string('%s%.*f', (conv['currency_symbol'], conv['frac_digits'], x), grouping=True)", 
    locale.format_string('%s%.*f', (conv['currency_symbol'], conv['frac_digits'], x), grouping=True))