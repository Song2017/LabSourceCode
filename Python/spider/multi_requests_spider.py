#!/usr/bin/env python
# -*- coding: utf-8 -*-

import requests
from bs4 import BeautifulSoup

from urllib import request
import os
import threading
import time

PAGES_URLS = []
IMG_URLS = []
gLock = threading.Lock()
headers = {
    "user-agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 \
        (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36"}


def parse_page(page_url):
    res = requests.get(page_url, headers=headers)
    content = res.content.decode('utf-8')
    soup = BeautifulSoup(content, "lxml")
    img_list = soup.find_all("img", attrs="img-responsive lazy image_dta")
    for img in img_list:
        img_url = img['data-original']
        filename = img_url.split('/')[-1]
        full_path = os.path.join("images", filename)
        request.urlretrieve(img_url, full_path)


def producer():
    while True:
        gLock.acquire()
        if len(PAGES_URLS) == 0:
            gLock.release()
            break
        page_url = PAGES_URLS.pop()
        gLock.release()
        if page_url:
            res = requests.get(page_url, headers=headers)
            print('producer', res.status_code)

            content = res.content.decode('utf-8')
            soup = BeautifulSoup(content, "lxml")
            img_list = soup.find_all(
                "img", attrs="img-responsive lazy image_dta")
            for img in img_list:
                img_url = img['data-original']
                IMG_URLS.append(img_url)


def consumer():
    while True:
        # simulate manual operation
        time.sleep(0.5)
        gLock.acquire()
        if len(IMG_URLS) == 0 and len(PAGES_URLS) == 0:
            gLock.release()
            break
        img_url = IMG_URLS.pop()
        gLock.release()

        print('consumer', img_url)
        if img_url:
            filename = img_url.split('/')[-1]
            full_path = os.path.join("images", filename)
            request.urlretrieve(img_url, full_path)


def main():
    print('main')
    for i in range(1, 4):
        PAGES_URLS.append('https://www.doutula.com/photo/list/?page='+str(i))
    # for url in PAGES_URLS:
    #     parse_page(url)

    # producer count should be less than length of PAGES_URLS
    # otherwise, PAGES_URLS is empty for consumer
    for i in range(2):
        th = threading.Thread(target=producer)
        th.start()
    for i in range(2):
        th = threading.Thread(target=consumer)
        th.start()


if __name__ == '__main__':
    main()
