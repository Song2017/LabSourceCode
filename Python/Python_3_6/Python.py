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
while i<100:
    print(i)
    pass
    i+=1
# def 定义函数