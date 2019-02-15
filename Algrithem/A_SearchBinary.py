#!/usr/bin/env python
# -*- coding: utf-8 -*-
from datetime import datetime

'''
二分查找（Binary Search）算法，也叫折半查找算法
针对"有序数据集合"的查找算法
优势
    相较于散列表、二叉树这些支持快速查找的动态数据结构, 二分查找使用的内存空间是最少的. 
    散列表和二叉树都需要比较多的额外内存空间.
局限性
    二分查找依赖的是顺序表结构，简单点说就是数组. 
        因为二分查找需要按照下标随机访问元素
    二分查找针对的是有序数据 
        二分查找对这一点的要求比较苛刻，数据必须是有序的。如果数据没有序，我们需要先排序。
        如果插入删除操作不频繁,我们可以一次排序多次查找, 减低排序的成本.
    数据量太小不适合二分查找        
        数据量小的时候可以直接顺序遍历
    数据量太大不适合二分查找
        数组的随机访问特性要求内存空间连续, 1GB 大小的数据，如果希望用数组来存储，那就需要 1GB 的连续内存空间
        注意即便有 2GB 的内存空间剩余，但是如果这剩余的 2GB 内存空间都是零散的，
        没有连续的 1GB 大小的内存空间，那照样无法申请一个 1GB 大小的数组
'''


def binarySearch(arr, value):
    '''
    查找第一个值等于给定值的元素
    1233343, 2
    '''
    low = 0
    high = len(arr) - 1
    while low <= high:
        # 等价于 mid = (low + high)//2, 下面的写法可以避免大数之和的溢出
        mid = low + ((high - low) >> 1)
        # 存在相等的值时, 等号会取第一个符合的值
        if arr[mid] >= value:
            high = mid - 1
        # low或high直接取mid会出现死循环, 当二者的值相等
        elif arr[mid] < value:
            low = mid + 1
    # 大于等于会将索引都转移到low, 添加low的值的有效判断
    if low < len(arr) and arr[low] == value:
        return low
    else:
        return -1


def binarySearchLast(arr, value):
    '''
    查找最后一个值等于给定值的元素
    123334,3 4 
    '''
    low = 0
    high = len(arr) - 1
    while low <= high:
        # 等价于 mid = (low + high)//2, 下面的写法可以避免大数之和的溢出
        mid = low + ((high - low) >> 1)
        # 存在相等的值时, 会取最后一个符合的值
        if arr[mid] <= value:
            low = mid + 1
        # low或high直接取mid会出现死循环, 当二者的值相等
        elif arr[mid] > value:
            high = mid - 1
    # 大于等于会将索引都转移到low, 添加low的值的有效判断
    if high < len(arr) and arr[high] == value:
        return high
    else:
        return -1


def binarySearchLargeEql(arr, value):
    '''
    查找第一个大于等于给定值的元素
    34679,5 6 
    '''
    low = 0
    high = len(arr) - 1
    while low <= high:
        # 等价于 mid = (low + high)//2, 下面的写法可以避免大数之和的溢出
        mid = low + ((high - low) >> 1)
        if arr[mid] >= value:
            if mid == 0 or arr[mid-1] < value:
                return mid
            else:
                high = mid - 1
        else:
            low = mid + 1
    return -1


def binarySearchSmallEql(arr, value):
    '''
    查找最后一个小于等于给定值的元素
    34679,5 4 
    '''
    low = 0
    high = len(arr) - 1
    while low <= high:
        # 等价于 mid = (low + high)//2, 下面的写法可以避免大数之和的溢出
        mid = low + ((high - low) >> 1)
        if arr[mid] > value:
            high = mid - 1
        else:
            if mid == len(arr) - 1 or arr[mid+1] > value:
                return mid
            else:
                low = mid + 1
    return -1


def binarySearchRec(arr, low, high, value):
    if low > high:
        return -1
    # 不同语言中, 双目运算符 >>优先级低于单目运算符 +
    mid = low + ((high - low) >> 1)
    if arr[mid] == value:
        return mid
    # low或high直接取mid会出现死循环, 当二者的值相等
    elif arr[mid] < value:
        binarySearchRec(arr, mid+1, high, value)
    else:
        binarySearchRec(arr, low, mid - 1, value)


if __name__ == '__main__':
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('binarySearch:', binarySearch(
        [-90, 0, 1, 22, 32, 32, 32, 32, 44, 55, 98, 765], 32))
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('binarySearchLast:', binarySearchLast(
        [-90, 0, 1, 22, 32, 32, 32, 32, 32, 44, 55, 98, 765], 32))
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('binarySearchLargeEql:', binarySearchLargeEql(
        [3, 4, 6, 7, 9], 5))
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('binarySearchSmallEql:', binarySearchSmallEql(
        [3, 4, 6, 7, 9], 5))
    print(datetime.now().strftime('%H:%M:%S.%f'))          
    print('binarySearchRec:', binarySearchRec(
        [-90, 0, 1, 22, 32, 44, 55, 98, 765], 0, 8, 32))
    print(datetime.now().strftime('%H:%M:%S.%f'))
