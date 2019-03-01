
from datetime import datetime


def test(n):
    # 设置最大递归深度
    maxDepth = 10
    cache = {}

    def funcRecursion(n, recursionDepth):
        # 函数调用记录
        # print(datetime.now().strftime('%H:%M:%S.%f'))
        recursionDepth = recursionDepth + 1
        if recursionDepth > maxDepth:
            raise Exception("stack overflow")
        if n == 1:
            cache[1] = 1
            return 1
        elif n == 2:
            cache[2] = 2
            return 2
        # 若已被缓存,则返回缓存值; 若无, 则获取前两次的递归值
        # 因为进行了缓存, 前两次的递归值不需要再递归获取
        if n not in cache.keys():
            cache[n] = funcRecursion(
                n-1, recursionDepth) + funcRecursion(n-2, recursionDepth)
        return cache[n]
    return funcRecursion(n, 0)


print(test(9))
# print(test(12))


def test1(n):
    # 设置最大递归深度
    maxDepth = 100
    recursionDepth = 0

    def funcRecursion(n):
        nonlocal recursionDepth
        if recursionDepth >= maxDepth:
            return "stack overflow"
        recursionDepth = (recursionDepth + 1)
        if n == 1:
            return 1
        return funcRecursion(n-1) + n

    return funcRecursion(n)


print(test1(99))
# print(test1(101))


def test11(n):
    sum = 0
    for i in range(1, n+1):
        sum += i
    return sum


print(test11(99))
print(test11(101))
