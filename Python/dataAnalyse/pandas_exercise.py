'''
Pandas
1. Pandas 提供的基础数据结构 DataFrame 与 json 的契合度很高，转换起来就很方便。
2. 如果我们日常的数据清理工作不是很复杂的话，你通常用几句 Pandas 代码就可以对数据进行规整
3. 核心数据结构: Series 和 DataFrame
基于这两种数据结构，Pandas 可以对数据进行导入、清洗、处理、统计和输出

Series 是个定长的字典序列。
说是定长是因为在存储的时候，相当于两个 ndarray，这也是和字典结构最大的不同。
Series有两个基本属性：index 和 values。
在 Series 结构中，index 默认是 0,1,2,……递增的整数序列，
当然我们也可以自己来指定索引，比如 index=[‘a’, ‘b’, ‘c’, ‘d’]

DataFrame 类型数据结构类似数据库表
它包括了行索引和列索引，我们可以将 DataFrame 看成是由相同索引的 Series 组成的字典类型
'''
import pandas as pd
import numpy as np
import math
from pandas import Series, DataFrame
from pandasql import sqldf

x = Series([1, 2, 3, 4])
y = Series([1, 2, 3, 4], index=['a', 'b', 'c', 'd'])
print(x, y)
d = {'a': 1, 'b': 2, 'c': 3, 'd': 4}
z = Series(d)
print(z)

# dataFrame
data = {'Chinese': [66, 95, 93, 90, 80], 'English': [
    65, 85, 92, 88, 90], 'Math': [30, 98, 96, 77, 90]}
df1 = DataFrame(data)
# index: 行索引, 默认为0,1,2..., columns: 列索引
df2 = DataFrame(data, index=['ZhangFei', 'GuanYu', 'ZhaoYun',
                             'HuangZhong', 'DianWei'], columns=['English', 'Math', 'Chinese'])
print(df1, df2)

# 数据导入和输出: Pandas 允许直接从 xlsx，csv 等文件中导入数据，也可以输出到 xlsx, csv 等文件，非常方便
# score = DataFrame(pd.read_excel('data.xlsx'))
# score.to_excel('data1.xlsx')
# print(score)

# 数据清洗
data = {'Chinese': [66, 95, 93, 90, 80], 'English': [
    65, 85, 92, 88, 90], 'Math': [30, 98, 96, 77, 90]}
df2 = DataFrame(data, index=['ZhangFei', 'GuanYu', 'ZhaoYun',
                             'HuangZhong', 'DianWei'], columns=['English', 'Math', 'Chinese'])
print(df2)
# 1. 删除 DataFrame 中的不必要的列或行
df = df2.drop(columns=['Chinese'])
df = df.drop(index=['ZhangFei'])
print(df2, '\n', df)
# 2. 重命名列名 columns，让列表名更容易识别
df2.rename(columns={'Chinese': 'yuwen', 'English': 'yingyu'}, inplace=True)
print(df2)
# 3. 去重复的值
df = df.drop_duplicates()  # 去除重复行
# 4. 格式问题
# 更改数据格式
data = {'Chinese': [66, 95, 93, 90, 80], 'English': [
    65, 85, 92, 88, 90], 'Math': [33, 98, 96, 77, 90]}
df2 = DataFrame(data, index=['ZhangFei', 'GuanYu', 'ZhaoYun',
                             'HuangZhong', 'DianWei'], columns=['English', 'Math', 'Chinese'])
df2['Chinese'] = df2['Chinese'].apply(str)  # df2['Chinese'].astype(str)
df2['English'] = df2['English'].astype(int)
print(df2.English, df2['Chinese'], df2)

# 数据间的空格
# 删除左右两边空格
df2['Chinese'] = df2['Chinese'].map(str.strip)
# 删除左边空格
df2['Chinese'] = df2['Chinese'].map(str.lstrip)
# 删除右边空格
df2['Chinese'] = df2['Chinese'].map(str.rstrip)
df2['Chinese'] = df2['Chinese'].str.strip('$')
print(df2)
# 大小写转换
# 全部大写
df2.columns = df2.columns.str.upper()
print(df2)
# 全部小写
df2.columns = df2.columns.str.lower()
print(df2)
# 首字母大写
df2.columns = df2.columns.str.title()
print(df2)

# 查找空值
df2 = DataFrame(pd.read_excel('data.xlsx'))
# 二维矩阵任意地方存在空值
print(df2.isnull())
# 列存在空值
print(df2.isnull().any())

# 使用 apply 函数对数据进行清洗
# apply 函数是 Pandas 中自由度非常高的函数，使用频率也非常高
# 自定义个函数，在 apply 中进行使用
data = {'Chinese': [66, 95, 93, 90, 80], 'English': [
    65, 85, 92, 88, 90], 'Math': [33, 98, 96, 77, 90]}
df = DataFrame(data, index=['ZhangFei', 'GuanYu', 'ZhaoYun',
                            'HuangZhong', 'DianWei'], columns=['English', 'Math', 'Chinese'])
df['Chinese'] = df['Chinese'].apply(lambda x: x**2)
print(df)


def plus(df, n, m):
    df['col1'] = (df['English'] + df['Math'])*n
    df['col2'] = (df['English'] + df['Math'])*m
    return df


df = df.apply(plus, axis=1, args=(2, 3, ))
print(df)


# 数据统计
# describe() 函数是个统计大礼包，可以快速让我们对数据有个全面的了解
df1 = DataFrame(
    {'name': ['ZhangFei', 'GuanYu', 'a', 'b', 'c', 'd'], 'data1': range(6)})
print(df1, df1.describe())

# 数据表合并
df1 = DataFrame(
    {'name': ['ZhangFei', 'GuanYu', 'a', 'b', 'c'], 'data1': range(5)})
df2 = DataFrame(
    {'name': ['ZhangFei', 'GuanYu', 'A', 'B', 'C'], 'data2': range(5)})
# 1. 基于指定列进行连接
df3 = pd.merge(df1, df2, on='name')
print(df3)
# 2. inner 内连接
#  内链接是 merge 合并的默认情况，inner 内连接其实也就是键的交集，在这里 df1, df2 相同的键是 name
df3 = pd.merge(df1, df2, how='inner')
print(df3)
# 3. left 左连接
df3 = pd.merge(df1, df2, how='left')
print(df3)
# 4. right 右连接
df3 = pd.merge(df1, df2, how='right')
print(df3)

# 用 SQL 方式打开 Pandas
# from pandasql import sqldf, load_meat, load_births
df1 = DataFrame(
    {'name': ['ZhangFei', 'GuanYu', 'a', 'b', 'c'], 'data1': range(5)})
sql = "select * from df1 where name ='ZhangFei'"
print(sqldf(sql, globals()))

# 数据清洗
data = {'Chinese': [66, 95, 93, 90, 80, 80], 'English': [65, 85, 92, 88, 90, 90],
        'Math': [None, 98, 96, 77, 90, 90]}
df = pd.DataFrame(data, index=['张飞', '关羽', '赵云', '黄忠', '典韦', '典韦'],
                  columns=['English', 'Math', 'Chinese'])
print(df)
# 去重
df = df.drop_duplicates()
# 列名重排
cols = ['Chinese', 'English', 'Math']
df = df.filter(cols, axis=1)
# rename
df.rename(columns={'Chinese': 'yuwen', 'English': 'yingyu'}, inplace=True)


def total(df):
    df['总分'] = df['yuwen']+df['yingyu']+(0 if math.isnan(df['Math']) else df['Math'])
    return df


# 增加求和列
# df['总分'] = df['yuwen']+df['英语']+df['Math']
df = df.apply(total, axis=1)

# 排序
df.sort_values(['总分'], ascending=False, inplace=True)
print(df)
print(df.isnull().sum(), df.describe())
# 使用数学成绩均值填充张飞同学的缺失值
df['Math'].fillna(df['Math'].mean(), inplace=True)
df.fillna(0, inplace=True)
print(df)
print(df.isnull().sum(), df.describe())
