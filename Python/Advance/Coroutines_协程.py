'''
协程
协程是实现并发编程的一种方式, 协程通过 async/await 语法进行声明，是编写异步应用的推荐方式
async 修饰词声明异步函数，于是，这里的 crawl_page 和 main 都变成了异步函数。
    print(crawl_page('')): 调用异步函数，我们便可得到一个协程对象（coroutine object）
await 调用可等待对象, 可等待对象有三种主要类型: 协程, 任务 和 Future.
    await可以从任务中切入也可以切出

协程的执行:
1. asyncio.run(main())，程序进入 main() 函数，事件循环开启. Python 3.7 之后才有的特性，
    可以让 Python 的协程接口变得非常简单，你不用去理会事件循环怎么定义和怎么使用的问题
2. await: await 执行的效果，和 Python 正常执行是一样的，程序会阻塞在这里，进入被调用的协程函数，执行完毕返回后再继续
3. asyncio.create_task() 函数: 并发运行作为 asyncio 任务 的多个协程. 注册就开始执行
4. asyncio.gather(*[]): 并发 运行 aws 序列中的 可等待对象。
    如果 aws 中的某个可等待对象为协程，它将自动作为一个任务加入日程。
    如果所有可等待对象都成功完成，结果将是一个由所有返回值聚合而成的列表。结果值的顺序与 aws 中可等待对象的顺序一致。
    如果 return_exceptions 为 False (默认)，所引发的首个异常会立即传播给等待 gather() 的任务。
        aws 序列中的其他可等待对象 不会被取消 并将继续运行。
    如果 return_exceptions 为 True，异常会和成功的结果一样处理，并聚合至结果列表。
    如果 gather() 被取消，所有被提交 (尚未完成) 的可等待对象也会 被取消。
    如果 aws 序列中的任一 Task 或 Future 对象 被取消，它将被当作引发了 CancelledError 一样处理 -- 
    在此情况下 gather() 调用 不会 被取消。这是为了防止一个已提交的 Task/Future 被取消导致其他 Tasks/Future 也被取消

Note
1. 协程和多线程的区别，主要在于两点，一是协程为单线程；二是协程由用户决定，在哪些地方交出控制权，切换到下一个任务。
2. 协程的写法更加简洁清晰，把 async / await 语法和 create_task 结合来用，对于中小级别的并发需求已经毫无压力。
3. 写协程程序的时候，你的脑海中要有清晰的事件循环概念，知道程序在什么时候需要暂停、等待 I/O，什么时候需要一并执行到底
'''
import asyncio
import aiohttp

from bs4 import BeautifulSoup
import time
import random


async def crawl_page(url):
    print(url, f"started at {time.strftime('%X')}")
    await asyncio.sleep(int(url.split('_')[-1]))
    print(url, f"end at {time.strftime('%X')}")


async def main(urls):
    # await
    # for url in urls:
    #     await crawl_page(url)
    tasks = [asyncio.create_task(crawl_page(url)) for url in urls]
    # for task in tasks:
    #     await task
    # *tasks 解包列表，将列表变成了函数的参数；** dict 将字典变成了函数的参数
    await asyncio.gather(*tasks)
print(f"started at {time.strftime('%X')}")
# asyncio.run(main(['url_1', 'url_2', 'url_3', 'url_4']))
print(f"end at {time.strftime('%X')}")

# 给某些协程任务限定运行时间，一旦超时就取消


async def w1():
    await asyncio.sleep(1)
    print('w1')
    return 1


async def w2():
    await asyncio.sleep(4)
    print('w2')
    return 2/0


async def w3():
    await asyncio.sleep(3)
    print('w3')
    return 3


async def main3():
    t1 = asyncio.create_task(w1())
    t2 = asyncio.create_task(w2())
    t3 = asyncio.create_task(w3())
    await asyncio.sleep(2)
    # 先打印了w1 和 w2, 然后打印sleep end
    print(f"main3 sleep end at {time.strftime('%X')}")
    t3.cancel()
    res = await asyncio.gather(t1, t2, t3, return_exceptions=True)
    print(res)
print(f"main3 started at {time.strftime('%X')}")
asyncio.run(main3())
print(f"main3 end at {time.strftime('%X')}")


# 生产者消费者模型
async def consumer(queue, id):
    while True:
        val = await queue.get()
        print('{} get a val: {}'.format(id, val))
        await asyncio.sleep(1)


async def producer(queue, id):
    for _ in range(5):
        val = random.randint(1, 10)
        await queue.put(val)
        print('{} get a val: {}'.format(id, val))
        await asyncio.sleep(1)


async def maincp():
    queue = asyncio.Queue()
    cs1 = asyncio.create_task(consumer(queue, 'consumer1'))
    cs2 = asyncio.create_task(consumer(queue, 'consumer2'))

    pd1 = asyncio.create_task(producer(queue, 'producer1'))
    pd2 = asyncio.create_task(producer(queue, 'producer2'))

    await asyncio.sleep(10)
    cs1.cancel()
    cs2.cancel()

    await asyncio.gather(cs1, cs2, pd1, pd2, return_exceptions=True)
print(f"maincp started at {time.strftime('%X')}")
asyncio.run(maincp())
print(f"maincp end at {time.strftime('%X')}")

# Movie Spider


async def fecth_content(url):
    header = {
        "User-Agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) \
            Chrome/75.0.3770.100 Safari/537.36"}
    async with aiohttp.ClientSession(
            headers=header, connector=aiohttp.TCPConnector(ssl=False)) as session:
        async with session.get(url) as resp:
            return await resp.text()


async def spider():
    url = "https://movie.douban.com/cinema/later/beijing/"
    init_page = await fecth_content(url)
    init_soup = BeautifulSoup(init_page, 'lxml')

    movie_names, urls_fetch, movie_dates = [], [], []

    all_movies = init_soup.find('div', id='showing-soon')
    for movie in all_movies.find_all('div', class_='item'):
        a_tag = movie.find_all('a')
        li_tag = movie.find_all('li')

        movie_names.append(a_tag[1].text)
        urls_fetch.append(a_tag[1]['href'])
        movie_dates.append(li_tag[0].text)

    tasks = [fecth_content(url) for url in urls_fetch]
    pages = await asyncio.gather(*tasks)

    for name, date, page in zip(movie_names, movie_dates, pages):
        soup_item = BeautifulSoup(page, 'lxml')
        img_tag = soup_item.find('img')
        print('{} {} {}'.format(name, date, img_tag['src']))
print(f"movie spider started at {time.strftime('%X')}")
asyncio.run(spider())
print(f"movie spider end at {time.strftime('%X')}")
