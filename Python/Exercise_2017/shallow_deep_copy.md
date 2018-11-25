# Python中赋值,浅拷贝,深拷贝的区别
三者的区别主要在*新列表中元素跟原来列表中元素是否仍有联系*

	赋值, 原列表简单类型元素的操作会影响新列表中元素
	浅拷贝, 原列表复合类型元素的操作会影响新列表中元素
	深拷贝, 原列表元素完全不会影响新列表中元素

## 赋值 
1.  形式 new_list = my_list
2.  只是简单的将my_list的内存地址引用传递给new_list
3.  因为运行结果中a在赋值完成后的操作均体现到了ae中,
    所以ae只是a的别名, ae自己没有独立的内存,仍然使用a的内存, 二者的内存地址是一样的
## 浅拷贝
1. 下面四种形式是等价的
    [new_list = old_list.copy()](https://docs.python.org/3/library/stdtypes.html#mutable-sequence-types)
    [new_list = old_list\[:\]](https://docs.python.org/3/library/stdtypes.html#mutable-sequence-types)
    [new_list = list(old_list)](https://docs.python.org/3/library/stdtypes.html#lists)
    [new_list = copy.copy(old_list)](https://docs.python.org/2/library/copy.html#copy.copy)
2.  上面四种形式得到的结果是一致的,对简单类型元素按值赋值,符合类型元素复制其地址
    import copy \n new_list = copy.copy(old_list)比list.copy()慢一点, 
    区别在于copy模块需要先确定old_list是列表类型
3.  因为在复制完成后修改a中第一个元素的值, b中元素值没有改变
    所以b有自己的内存,简单类型的元素'foo'是在b的新分配的内存区域中, 不同于a中'foo'的内存地址
    因为在复制完成后修改a中类实例的属性, b中类属性也改变了
    所以我们得到: b的复合类型对象Foo类实例foo指向a中foo实例的地址
## 深拷贝
1.  形式 [new_list = copy.deepcopy(old_list)](https://docs.python.org/2/library/copy.html#copy.deepcopy)
2.  对简单类型元素按值赋值,符合类型元素递归的复制其值到新列表中
3.  因为在复制完成后修改a中类实例的属性, b中类实例的属性没有改变
    所以我们得到: b的复合类型对象Foo类实例不同于a中foo实例的地址

# 参考
1.  [Shallow and deep copy operations](https://docs.python.org/3.6/library/copy.html#module-copy)
2.  [how-to-clone-or-copy-a-list](https://stackoverflow.com/questions/2612802/how-to-clone-or-copy-a-list)

# Code
```
import copy
class Foo(object):
    def __init__(self, val):
        self.val = val
    def __repr__(self):
        return str(self.val)
foo = Foo(1)
a = ['foo', foo]
# ae只是a的别名, ae自己没有独立的内存,仍然使用a的内存, 二者的内存地址是一样的
ae = a
# 因为在复制完成后修改a中第一个元素的值, b中元素值没有改变
# 所以b有自己的内存,简单类型的元素'foo'是在b的新分配的内存区域中, 不同于a中'foo'的内存地址
# 因为在复制完成后修改a中类实例的属性, b中类属性也改变了
# 所以我们得到: b的复合类型对象Foo类实例foo指向a中foo实例的地址
b = a.copy() 
c = a[:]
d = list(a)
e = copy.copy(a)
# 因为在复制完成后修改a中类实例的属性, b中类实例的属性没有改变
# 所以我们得到: b的复合类型对象Foo类实例不同于a中foo实例的地址
f = copy.deepcopy(a)

# edit orignal list and instance
a.append('baz')
a[0] = 'foo modified'
foo.val = 5

print(' original: %r\n equal: %r\n list.copy(): %r\n slice: %r\n list(): %r\n copy: %r\n deepcopy: %r'
      % (a, ae, b, c, d, e, f))
'''
 original: ['foo modified', 5, 'baz']
 equal: ['foo modified', 5, 'baz']
 list.copy(): ['foo', 5]
 slice: ['foo', 5]
 list(): ['foo', 5]
 copy: ['foo', 5]
 deepcopy: ['foo', 1]
''' 
```