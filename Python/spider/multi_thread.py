import time
import threading
import random

gMoney = 0
gLock = threading.Lock()


def greet(index):
    print("helloworld-%d" % index)
    time.sleep(0.5)


def line_run():
    for i in range(5):
        greet(i)


def thread_run():
    for i in range(5):
        th = threading.Thread(target=greet, args=[i])
        th.start()


def producter():
    global gMoney
    while True:
        money = random.randint(0, 100)
        gLock.acquire()
        gMoney += money
        gLock.release()
        print("%s product %s money, rest is %s" %
              (threading.current_thread(), money, gMoney))
        time.sleep(0.5)


def consumer():
    global gMoney
    while True:
        money = random.randint(0, 100)
        gLock.acquire()
        if gMoney > money:
            gMoney -= money
            print("%s consume %s money, rest is %s" %
                  (threading.current_thread(), money, gMoney))
        else:
            print("NO money!!! %s consume %s money, rest is %s" %
                  (threading.current_thread(), money, gMoney))
        gLock.release()
        time.sleep(0.5)


if __name__ == '__main__':
    # line_run()
    # thread_run()
    for i in range(2):
        th = threading.Thread(target=producter)
        th.start()
    for i in range(2):
        th = threading.Thread(target=consumer)
        th.start()
