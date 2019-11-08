import sys
import gc
'''
1, 垃圾回收是 Python 自带的机制，用于自动释放不会再用到的内存空间；
2. 引用计数是其中最简单的实现，不过切记，这只是充分非必要条件，
    因为循环引用需要通过不可达判定，来确定是否可以回收；
3. Python 的自动回收算法包括标记清除和分代收集，主要针对的是循环引用的垃圾收集；
4. 调试内存泄漏方面， objgraph 是很好的可视化分析工具
    sys.getrefcount() 可以查看一个变量的引用次数, 但本身也会引入一次计数
5. 手动释放内存
    del a; gc.collect();

Python 使用标记清除（mark-sweep）算法和分代收集（generational）
先来看标记清除算法。
我们先用图论来理解不可达的概念。对于一个有向图，如果从一个节点出发进行遍历，并标记其经过的所有节点；
那么，在遍历结束后，所有没有被标记的节点，我们就称之为不可达节点。这些节点的存在是没有任何意义的
在 Python 的垃圾回收实现中，mark-sweep 使用双向链表维护了一个数据结构，
并且只考虑容器类的对象（只有容器类对象才有可能产生循环引用）
分代收集算法
分代收集基于的思想是，新生的对象更有可能被垃圾回收，而存活更久的对象也有更高的概率继续存活
Python 将所有对象分为三代。刚刚创立的对象是第 0 代；
经过一次垃圾回收后，依然存在的对象，便会依次从上一代挪到下一代。
而每一代启动自动垃圾回收的阈值，则是可以单独指定的。
当垃圾回收器中新增对象减去删除对象达到相应的阈值时，就会对这一代对象启动垃圾回收。

调试内存泄漏
import objgraph
a = [1, 2, 3]
b = [4, 5, 6]
a.append(b)
b.append(a)
objgraph.show_refs([a])
objgraph.show_backrefs([a])
'''


# Python 内部的引用计数机制
a = []

# 两次引用，一次来自 a，一次来自 getrefcount
print(sys.getrefcount(a))


def func(a):
    # 四次引用，a，python 的函数调用栈，函数参数，和 getrefcount
    print(sys.getrefcount(a))


func(a)
# 两次引用，一次来自 a，一次来自 getrefcount，函数 func 调用已经不存在
print(sys.getrefcount(a))

b = a
c = b
d = b
e = c
f = e
g = d

print(sys.getrefcount(a))  # 八次


# 手动释放内存
# 先调用 del a 来删除一个对象；然后强制调用 gc.collect()，即可手动启动垃圾回收
del a
gc.collect()
# print(sys.getrefcount(a)) # name 'a' is not defined


# 循环引用

def func2():
    a = [i for i in range(10)]
    b = [i for i in range(10)]
    print('after a, b created')
    a.append(b)
    b.append(a)


func2()
# a, b的内存还占用着, 需要显式调用gc.collect()
gc.collect()
# print(sys.getrefcount(a), sys.getrefcount(b))
