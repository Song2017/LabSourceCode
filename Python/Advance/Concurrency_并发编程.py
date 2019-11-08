'''
# 区分并发和并行
并发（Concurrency）:并发并不是指同一时刻有多个操作（thread、task）同时进行。
    相反，某个特定的时刻，它只允许有一个操作发生，只不过线程/任务之间会互相切换，直到完成
    1. thread 和 task: 对应 Python 中并发的两种形式——threading(线程级别) 和 asyncio(协程级别)
        threading: 由操作系统控制, 进行线程切换. 但是切换的操作可能发生在执行一个简单语句(x+=1)时
        asyncio: 由程序控制, 切换任务时，必须得到此任务可以被切换的通知，
            这样一来也就可以避免刚刚提到的 race condition 的情况
    2. 常应用于 I/O 操作频繁的场景，比如你要从网站上下载多个文件，I/O 操作的时间可能会比
        CPU 运行处理的时间长得多
并行（Parallelism）:同一时刻、同时发生。Python 中的 multi-processing 便是这个意思，
    可以这么理解：比如你的电脑是 6 核处理器，那么就可以强制 Python 开 6 个进程，同时执行
    1. 适用于 CPU heavy 的场景，比如 MapReduce 中的并行计算，为了加快运行速度，一般会用多个处理器来完成

# asyncio.Future和concurrent.futures
asyncio.Future: Python 3.5出现 https://docs.python.org/3/library/asyncio-task.html
    期程, 通过async/await, 使用协程的方式写异步程序, GIL(全局解释器锁)保证了Python 主程序只允许有一个线程执行
    可以非常有效的使用单线程内的资源, 但是不能跨线程操作.
    期程对象支持底层回调式代码(例如在协议实现中使用asyncio transports) 与高层异步/等待式代码交互.
    期程对象是为了模仿 concurrent.futures.Future 。主要差异包含：
        concurrent.futures.Future 实例不能像asyncio期程那样等待。
        asyncio.Future.result() 和 asyncio.Future.exception() 不接受 timeout 参数。
        期程没有 完成 时 asyncio.Future.result() 和 asyncio.Future.exception() 
            引发 InvalidStateError 引发一个异常。
        使用 asyncio.Future.add_done_callback() 注册的回调函数不会立即调用，
            而是被 loop.call_soon() 调度。
        asyncio期程不能兼容 concurrent.futures.wait() 和 concurrent.futures.as_completed() 函数
concurrent.futures: Python 3.2出现  https://docs.python.org/zh-cn/3/library/concurrent.futures.html
    通过提供进程池和线程池(单进程)实现异步编程. 可以很好的利用CPU多核的优势
    缺点是由操作系统控制, 不能保留程序上下文, 线程之间切换会有资源争用的情况
    异步执行可以由 ThreadPoolExecutor 使用线程或由 ProcessPoolExecutor 使用单独的进程来实现。
    两者都是实现抽像类 Executor 定义的接口: submit, map, shutdown
# Asyncio 工作原理
1. Asyncio 和其他 Python 程序一样，是单线程的，它只有一个主线程，
但是可以进行多个不同的任务（task），这里的任务，就是特殊的 future 对象, 被一个叫做 event loop 的对象所控制


如何选择使用的技术
1. CPU-bound的任务主要是multi-processing，
2. IO-bound的话，如果IO比较快，用多线程，
3. 如果IO比较慢，用asyncio，因为效率更加高


'''
import requests
import time

import concurrent.futures
import asyncio
import aiohttp


def download(url):
    # resp = requests.get(url)
    # print('Read {} from {}'.format(len(resp.content), url))
    print('Read {} from {}'.format(url.split('/')[-1], url))


def download_all(sites):
    with concurrent.futures.ThreadPoolExecutor(max_workers=4) as executor:
        todos = []
        for s in sites:
            future = executor.submit(download, s)
            todos.append(future)

        for future in concurrent.futures.as_completed(todos):
            try:
                future.result()
            except requests.exceptions.RequestException as e:
                msg = 'RequestException'+str(e)
            except Exception as e:
                msg = str(e)
            else:
                msg = None
            finally:
                if msg:
                    print('download error: ', msg)


def main(sites):
    start_time = time.perf_counter()
    download_all(sites)
    end_time = time.perf_counter()
    print('down load {} in {} sec.'.format(len(sites), end_time-start_time))


async def fetch(url):
    '''
    async with coroutines
    '''
    async with aiohttp.ClientSession(connector=aiohttp.TCPConnector(ssl=False)) as session:
        async with session.get(url) as resp:
            print('Read {} from {}'.format(resp.content_length, url))


async def fetch_all(urls):
    tasks = [asyncio.create_task(fetch(url)) for url in urls]
    await asyncio.gather(*tasks)


def asymain(sites):
    start_time = time.perf_counter()
    asyncio.run(fetch_all(sites))
    end_time = time.perf_counter()
    print('asymain down load {} in {} sec.'.format(
        len(sites), end_time-start_time))


if __name__ == '__main__':
    sites = [
        'https://blog.csdn.net/sgs595595/article/details/81747397',
        'https://blog.csdn.net/sgs595595/article/details/94589251',
        'https://blog.csdn.net/sgs595595/article/details/94393596',
        'https://blog.csdn.net/sgs595595/article/details/90896783',
        'https://blog.csdn.net/sgs595595/article/details/94017673'
    ]
    main(sites)
    asymain(sites)
