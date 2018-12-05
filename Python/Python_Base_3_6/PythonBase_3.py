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

# 2. Template 模板
# class string.Template(template) https://docs.python.org/3/library/string.html#string.Template
# string 提供了一个灵活多变的模版类 Template ，使用它最终用户可以用简单的进行编辑
# 格式使用 $ 为开头的 Python 合法标识（数字、字母和下划线）作为占位符。
#   占位符外面的大括号使它可以和其它的字符不加空格混在一起。 $$ 创建一个单独的 $
from string import Template
t = Template('${village}folk send $$10 to $cause')
print("t.substitute(village='Shanghai', cause='the dich fund')",
    t.substitute(village='Shanghai', cause='the dich fund'))
# safe_substitute()如果数据不完整，它就不会改变占位符
print("t.safe_substitute(village='Shanghai')", t.safe_substitute(village='Shanghai'))
# 模板子类可以指定一个自定义分隔符
# 实例: 图像查看器的批量重命名工具;  把多样的输出格式细节从程序逻辑中分类
import time
photofiles = ['img_1074.jpg','img_1075.jpg','img_1077.jpg']
class BatchRename(Template):
    delimiter = '%'
fmt = 'BEN_%d%n%f'
t = BatchRename(fmt)
date = time.strftime('%d%b%y_')
for i, filename in enumerate(photofiles):
    newname = t.safe_substitute(d=date, n=i, f='.ext')
    # BEN_04Dec18_0.ext
    print('newname', newname)

# 3. 使用二进制数据记录布局
# struct 模块为使用变长的二进制记录格式提供了 pack() 和 unpack() 函数
# [struct — Interpret bytes as packed binary data](https://docs.python.org/3/library/struct.html#struct.unpack)
# 压缩码 "H" 和 "I" 分别表示2和4字节无符号数字，"<" 表明它们都是标准大小并且按照 little-endian 字节排序
import struct
with open('demo.zip', 'rb') as f:
    data=f.read()
start = 0
for i in range(3):
    start += 14
    fields = struct.unpack('<IIIHH',data[start:start+16])
    crc32, comp_size, uncomp_size, filename_size, extra_size = fields
    start += 16
    filename=data[start:start+filename_size]
    start += filename_size
    extra = data[start:start+extra_size]
    print('filename, hex(crc32), comp_size, uncomp_size ',filename, hex(crc32), comp_size, uncomp_size)
    start += extra_size+comp_size

# 4. 多线程
# 线程是一个分离无顺序依赖关系任务的技术 
# [threading — Thread-based parallelism](https://docs.python.org/3/library/threading.html#module-threading)   
# 在某些任务运行于后台的时候应用程序会变得迟缓，线程可以提升其速度。
# 用途: I/O 的同时其它线程可以并行计算
# 主要挑战: 协调线程，诸如线程间共享数据或其它资源。
#   为了达到那个目的，线程模块提供了许多同步化的原生支持，包括：锁，事件，条件变量和信号灯 
#   任务协调的首选方法是把对一个资源的所有访问集中在一个单独的线程中，
#       然后使用 queue 模块用那个线程服务其他线程的请求。https://docs.python.org/3/library/queue.html#module-queue
#   为内部线程通信和协调而使用 Queue 对象的应用程序更易于设计，更可读，并且更可靠
import threading, zipfile, datetime
class AsyncZip(threading.Thread):
    def __init__(self, infile, outfile):
        threading.Thread.__init__(self)
        self.infile=infile
        self.outfile=outfile
    # run() 线程要做的活动或任务.多被重写
    def run(self):
        f= zipfile.ZipFile(self.outfile, 'w', zipfile.ZIP_DEFLATED)
        f.write(self.infile)
        f.close()
        print('Finished background zip of:', self.infile,' at current time ', datetime.datetime.now().strftime('%H:%M:%S.%f') )
        print('time.sleep(1)', time.sleep(1))
        print('run after sleep current time ', datetime.datetime.now().strftime('%H:%M:%S.%f'))
background = AsyncZip('fibo.py', 'fibo.zip')
print('AsyncZip current time ', datetime.datetime.now().strftime('%H:%M:%S.%f'))
# 开始线程, 一个线程对象至多运行一次. 将在一个可控的独立线程中运行run()
background.start()
print('background.start() current time ', datetime.datetime.now().strftime('%H:%M:%S.%f'))
# 等待线程, 等待直到线程结束. 这会阻塞调用线程, 直到调用join()的线程对象结束或返回异常,或者超时
background.join()
print('background.join() current time ', datetime.datetime.now().strftime('%H:%M:%S.%f'))

# 5. 日志
# logging 模块提供了完整和灵活的日志系统。
# [logging — Logging facility for Python](https://docs.python.org/3/library/logging.html#module-logging)
# 它最简单的用法是记录信息并发送到一个文件或 sys.stderr
# Logger对象提供应用程序可直接使用的接口，Handler保存日志到介质: 文件,字节流等，
# Filter提供了过滤日志信息的方法，Formatter指定日志显示格式
import logging 
logging.basicConfig(level=logging.DEBUG, 
                    format='%(asctime)s %(filename)s[line:%(lineno)d] %(levelname)s %(message)s',
                    datefmt='%a, %d %b %Y %H:%M:%S',
                    filename='test.log',
                    filemode='w')
logging.debug('logging debug info')
logging.info('logging info info')
logging.error('logging error info')
logging.warning('logging warning info')
logging.critical('logging critical info')

# 6. 弱引用
# Python 自动进行内存管理（对大多数的对象进行引用计数和垃圾回收—— 垃圾回收 ——以循环利用）
#   最后一个引用消失后，内存会很快释放. 但是为跟踪它们创建引用也会使其长期存在
# weakref 模块提供了不用创建引用的跟踪对象工具，一旦对象不再存在，它自动从弱引用表上删除并触发回调
import weakref, gc
class A:
    def __init__(self,value):
        self.value = value
    def __repr__(self):
        return str(self.value)
a = A(10)
a2 = A(10)
d = weakref.WeakValueDictionary()
ds = {}
d['primary'] = a
ds['primary'] = a2
print("d['primary'],ds['primary']",d['primary'],ds['primary'])
del a
del a2
gc.collect()
# 10
print("ds['primary']", ds['primary']) 
# has been removed, get KeyError: primary 
#print("d['primary']",d['primary'])

# 7. 用于列表工作的工具
# array 模块提供了一个类似列表的 array() 对象，它仅仅是存储数据，更为紧凑
from array import array
a = array('H', [4000, 10,12,555])
print('sum(a), a[1:3]',sum(a), a[1:3])
a = ['H', [4000, 10,12,555]]
print('a[1:3]', a[1:3])
# collections 模块提供了类似列表的 deque() 对象，
#   它从左边添加（append）和弹出（pop）更快，但是在内部查询更慢。
# 适用于队列实现和广度优先的树搜索
from collections import deque
d = deque(["task1","task2","task3"])
d.append('task4')
print('handling', d.popleft())
print('deque append, popleft ', d)
# 广度优先搜索 根结点开始沿着树的宽度, 横向搜索遍历
'''
# 实现思路
unsearched = deque([starting_node])
def breadth_first_search(unsearched):
    node = unsearched.popleft()
    for m in gen_moves(node):
        if is_goal(m):
            return m
        unsearched.append(m)
'''
# bisect 
# [bisect — Array bisection algorithm](https://docs.python.org/3/library/bisect.html#module-bisect) 
# 操作有序的存储链表, 采用简单的二分法对有序的数组进行插入,查询
import bisect
scores = [(100, 'perl'), (200, 'tcl'), (400, 'lua'), (500, 'python')]
bisect.insort(scores, (300, 'aaaa'))
print('scores',scores)
# heapq 
# [heapq — Heap queue algorithm¶](https://github.com/python/cpython/blob/3.7/Lib/heapq.py)
# 提供了基于优先队列的堆实现。priority_queue允许用户为队列中元素设置优先级，
#   放置元素的时候不是直接放到队尾，而是放置到比它优先级低的元素前面
# 最小的值总是保持在a[0]。适用于循环访问最小元素但是不想执行完整堆排序
from heapq import heapify, heappop, heappush
data = [1, 3, 5, 7, 9, 2, 4, 6, 8, 0]
heapify(data); print('data',data)
heappush(data, -5)
print('[heappop(data) for i in range(3)]', [heappop(data) for i in range(3)])
print('data',data)

# 8. 十进制浮点数算法
# decimal 模块提供了一个 Decimal 数据类型用于浮点数计算。
# [decimal — Decimal fixed point and floating point arithmetic](https://docs.python.org/3/library/decimal.html#module-decimal)
# 相比内置的二进制浮点数实现 float的优点
#   金融应用和其它需要精确十进制表达的场合，
from decimal import *
# 0.735 向上五入 得 0.74
print("round(Decimal('0.70')*Decimal('1.05'), 2)", 
    round(Decimal('0.70')*Decimal('1.05'), 2))
# 0.735 向下四舍 得 0.73
print("round(0.70*1.05, 2)", round(0.70*1.05, 2))
# 控制精度，控制舍入以适应法律或者规定要求，
print("Decimal('1.00')%Decimal('.10'), 1.00%.10: ", 
    Decimal('1.00')%Decimal('.10'), 1.00%.10)
print("sum([Decimal('0.1')]*10)==Decimal('1.0'), sum([0.1]*10) == 1.0:", 
    sum([Decimal('0.1')]*10)==Decimal('1.0'), sum([0.1]*10) == 1.0)
# 确保十进制数位精度
getcontext().prec = 36
print("Decimal(1)/Decimal(7)", Decimal(1)/Decimal(7))