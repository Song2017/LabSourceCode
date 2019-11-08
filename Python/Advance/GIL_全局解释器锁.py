'''
# GIL，全局解释器锁
本质上是类似操作系统的互斥锁 Mutex
1. CPython 引进 GIL 其实主要就是这么两个原因：
    一是设计者为了规避类似于内存管理这样的复杂的竞争风险问题（race condition）；
    查看引用计数的方法：sys.getrefcount(a)
    二是因为 CPython 大量使用 C 语言库，但大部分 C 语言库都不是原生线程安全的
    （线程安全会降低性能和增加复杂度）
2. GIL 是如何工作的
    1 . 一个线程在开始执行时，都会锁住 GIL，以阻止别的线程执行；
        同样的，每一个线程执行完一段后，会释放 GIL，以允许别的线程开始利用资源
    2. check_interval，意思是 CPython 解释器会去轮询检查线程 GIL 的锁住情况。
        每隔一段时间，Python 解释器就会强制当前线程去释放 GIL，这样别的线程才能有执行的机会
3. Python 的线程安全(应用层面并不是)
    函数本身是由多层堆栈的, 而这并不是线程安全的
    >>> import dis
    >>> dis.dis(foo)
    LOAD_GLOBAL              0 (n)
    LOAD_CONST               1 (1)
    INPLACE_ADD
    STORE_GLOBAL             0 (n)

GIL 的设计，主要是为了方便 CPython 解释器层面的编写者，而不是 Python 应用层面的程序员
作为 Python 的使用者，我们还是需要 lock 等工具，来确保线程安全
绕过GIL的两种思路：
1. 绕过CPython，使用JPython等别的实现；
2. 把关键性能代码放到其他语言中实现，比如C++
'''
import time
import concurrent.futures
import threading
import asyncio


def CountDown(n):
    while n > 0:
        n -= 1


def multipleThread(n):
    for _ in range(2):
        th = threading.Thread(target=CountDown, args=[n//2])
        th.start()
        th.join()


async def asyCountDown(n):
    while n > 0:
        n -= 1


async def asyncThread(n):
    asyncio.create_task(asyCountDown(n))


# 应用级别也要保证线程安全
n = 0
lock = threading.Lock()


def foo():
    '''
    要保证线程安全
    '''
    global n
    with lock:
        n += 1


def test():
    threads = []
    for _ in range(100):
        t = threading.Thread(target=foo)
        threads.append(t)

    for t in threads:
        t.start()

    for t in threads:
        t.join()

    print(n)


if __name__ == "__main__":
    # start_time = time.perf_counter()
    # CountDown(50000000)
    # end_time = time.perf_counter()
    # print('thread run time: ', end_time-start_time)
    # start_time = time.perf_counter()
    # multipleThread(100000000)
    # end_time = time.perf_counter()
    # print('multipleProcess run time: ', end_time-start_time)
    # start_time = time.perf_counter()
    # asyncio.run(asyncThread(50000000))
    # end_time = time.perf_counter()
    # print('asyncThread run time: ', end_time-start_time)
    test()
