'''
NumPy
它不仅是 Python 中使用最多的第三方库，而且还是 SciPy、Pandas 等数据科学的基础库。
它所提供的数据结构比 Python 自身的“更高级、更高效”，可以这么说，NumPy 所提供的数据结构是 Python 数据分析的基础
1. 列表 list 的元素在系统内存中是分散存储的，而 NumPy 数组 Ndarray 存储在一个均匀连续的内存块中
2. 内存访问模式中，缓存会直接把字节块从 RAM 加载到 CPU 寄存器中。
因为数据连续的存储在内存中，NumPy 直接利用现代 CPU 的矢量化指令计算，加载寄存器中的多个连续浮点数。
3. NumPy 中的矩阵计算可以采用多线程的方式，充分利用多核 CPU 计算资源，大大提升了计算效率

提升内存和提高计算资源的利用率: 避免采用隐式拷贝，而是采用就地操作的方式
'''
import numpy as np
a = np.array([1, 2, 3])
b = np.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
b[1, 1] = 10
print(a.shape, b.shape, a.dtype)
print(b)

# 结构数组
persontype = np.dtype(
    {'names': ['name', 'age', 'math', 'chinese'],
     'formats': ['S32', 'i', 'f', 'f']})
peoples = np.array([("ZhangFei", 32, 75, 90), ("GuanYu", 24, 85, 88.5),
                    ("ZhaoYun", 28, 85, 96.5), ("HuangZhong", 29, 65, 85)],
                   dtype=persontype)
ages = peoples[:]['age']
print(ages, np.mean(ages))
chinese = peoples[:]['chinese']
print(chinese, np.mean(chinese))

# ufunc 运算
# ufunc 是 universal function 的缩写，它能对数组中每个元素进行函数操作。
# NumPy 中很多 ufunc 函数计算速度非常快，因为都是采用 C 语言实现的

# 连续数组的创建
# arange() 类似内置函数 range()，
# 通过指定初始值、终值、步长来创建等差数列的一维数组，默认是不包括终值的
x1 = np.arange(1, 11, 2)
# linspace 是 linear space 的缩写，代表线性等分向量的含义。
# linspace() 通过指定初始值、终值、元素个数来创建等差数列的一维数组，默认是包括终值的
x2 = np.linspace(1, 9, 5)
print(x1, x2, np.linspace(1, 9, 6))

# 算数运算
print(np.add(x1, x2))
print(np.subtract(x1, x2))
print(np.multiply(x1, x2))
print(np.divide(x1, x2))
# n次方
print(np.power(x1, x2))
# 取余
print(np.remainder(x1, x2))

# 统计函数
a = np.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
# axis=0: 列; 1: 行
print(np.amin(a), np.amin(a, 0), np.amin(a, 1))
print(np.amax(a), np.amax(a, 0), np.amax(a, 1))

# 统计最大值与最小值之差 ptp()
a = np.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
# 列: 0, 行: 1
print(np.ptp(a), np.ptp(a, 0), np.ptp(a, 1))

# 统计数组的百分位数 percentile()
a = np.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
# 1,4,7=> 25%: 1+(7-1)*25%
print(np.percentile(a, 50), np.percentile(a, 25, 0), np.percentile(a, 50, 1))

# 统计数组中的中位数 median()、平均数 mean()
a = np.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
# 中位数
print(np.median(a), np.median(a, 0), np.median(a, axis=1))
# 平均数
print(np.mean(a), np.mean(a, 0), np.mean(a, axis=1))

# 统计数组中的加权平均值 average()
a = np.arange(1, 5, 1, dtype=int)
wts = np.array([1, 2, 3, 4])
# (1+2+3+4)/4=2.5
# (1*1+2*2+3*3+4*4)/(1+2+3+4)=3.0
print(np.average(a), np.average(a, weights=wts))

# 统计数组中的标准差 std()、方差 var()
# 方差的计算是指每个数值与平均值之差的平方求和的平均值，即 mean((x - x.mean())** 2)。
# 标准差是方差的算术平方根
a = np.linspace(0, 8, 5, dtype=int)
print(a, np.std(a), np.var(a))

# NumPy 排序
# kind 里，可以指定 quicksort、mergesort、heapsort 分别表示快速排序、合并排序、堆排序
#   默认为 quicksort
# axis 默认是 -1，即沿着数组的最后一个轴进行排序，也可以取不同的 axis 轴，
#   或者 axis=None 代表采用扁平化的方式作为一个向量进行排序
#   None: 返回一维数组, 0: 列, 1: 行
a = np.array([[4, 3, 2], [2, 4, 1]])
print(np.sort(a))
print(np.sort(a, axis=None))
print(np.sort(a, axis=0), np.sort(a, axis=1))
print(np.sort(a, kind='quicksort', axis=None),
      np.sort(a, kind='heapsort', axis=None))

# Exercise: 统计全班的成绩
'''
1.用NumPy统计下这些人在语文、英语、数学中的平均成绩、最小成绩、最大成绩、方差、标准差。
2.总成绩排序，得出名次进行成绩输出
'''
scoretype = np.dtype({'names': ['name', 'chinese', 'english', 'math'],
                      'formats': ['S32', 'i', 'i', 'i']})
peoples = np.array(
    [
        ("zhangfei", 66, 65, 30),
        ("guanyu", 95, 85, 98),
        ("zhaoyun", 93, 92, 96),
        ("huangzhong", 90, 88, 77),
        ("dianwei", 80, 90, 90)
    ], dtype=scoretype)
print("科目 | 平均成绩 | 最小成绩 | 最大成绩 | 方差 | 标准差")
courses = {'语文': peoples[:]['chinese'],
           '英文': peoples[:]['english'], '数学': peoples[:]['math']}
for course, scores in courses.items():
    print(course, np.mean(scores), np.amin(scores), np.amax(scores), np.std(scores),
          np.var(scores))
print('Ranking')
ranking = sorted(peoples, key=lambda x: x[1]+x[2]+x[3], reverse=True)
print(ranking)
