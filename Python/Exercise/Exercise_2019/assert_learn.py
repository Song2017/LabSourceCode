'''
Python 的 assert 语句，可以说是一个 debug 的好工具，主要用于测试一个条件是否满足。
如果测试的条件满足，则什么也不做，相当于执行了 pass 语句；
如果测试条件不满足，便会抛出异常 AssertionError，并返回具体的错误信息（optional）

1. assert 的检查是可以被关闭的，比如在运行 Python 程序时，加入-O这个选项就会让 assert 失效
语法: assert_stmt ::=  "assert" expression ["," expression]
等价于下面代码, 添加-O选项,python -O assert_learn.py: __debug__便为 False, 失效所有assert检查
if __debug__:
    if not expression1: raise AssertionError(expression2)

2. assert不能替换掉if/try..catch.., -O可以关闭assert, 条件判断就不生效了
3. assert不能加小括号
'''
print('__debug__', __debug__)
# assert 1 == 2, 'This should fail'

# if __debug__:
#     if not 1 == 2:
#         raise AssertionError('This should fail')


def apply_discount(price, discount):
    '''使用'''
    assert isinstance(price, int)
    updated_price = price * (1 - discount)
    assert 0 <= updated_price <= price,\
        'price should be greater or equal to 0 and less or equal to original price'
    return updated_price


apply_discount(100, 0.2)
# apply_discount('100', 2)
apply_discount(100, 2)
