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
print('squares[:], squares[1], squares[-1], squares[-3:], [-1, 0]+squares', squares[:], squares[1], squares[-1], squares[-3:], [-1, 0]+squares)
