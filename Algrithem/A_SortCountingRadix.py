#!/usr/bin/env python
# -*- coding: utf-8 -*-
from datetime import datetime

def countingSort(arr):
    '''
    计数排序: 桶排序的特殊情况, 将数据值的范围作为索引, 反过来进行排序
    适合值的范围有限且均为正整数的数据
    适用的实际情况:对考试分数排序
    1. 非原地排序算法: 需要计数数组, 空间由值的范围确定,一般比较小
        需要一个已排序数组, 长度与待排序数组一样, 空间复杂度为O(n)
    2. 稳定的:从后向前遍历数组, 后面的元素, 仍然在后面
    3. 时间复杂度: O(n), 构造好计数桶后, 从后向前遍历待排序数组, 根据桶的值, 直接插入到已排序数组

    要求:待排序数组的值均为正整数(不包含0)
    排序前格式化数组: 
        存在小于1的整数, 数组的每个值都增加最小值绝对值+1, 使最小值为1
        存在小数, 同时扩大倍数:小数位数*10
    '''
    absVal = 0
    if min(arr) <= 0:
        absVal = abs(min(arr))+1
        arr = [i+absVal for i in arr]

    arrLength = len(arr)
    countArrLength = max(arr)
    countArr = [0]*countArrLength
    sortedArr = [0]*arrLength
    # [2, 2, 3, 2, 0, 0, 0, 0, 1]
    for i in range(arrLength):
        countArr[arr[i]-1] += 1
    # [2, 4, 7, 9, 9, 9, 9, 9, 10]
    for i in range(1, countArrLength):
        countArr[i] += countArr[i-1]
    # 进行排序, 为了稳定性,从后向前遍历数据,
    #     根据数据的值从桶里取数,这个数就是排序后的数据位置,
    #     取数后要将桶的数的值减一, 这就是当前桶对应的待排序数据的下一个数据位置, 也是当前数据对应的已排序数组索引
    for i in arr[::-1]:
        countArr[i-1] = countArr[i-1] - 1
        sortedArr[countArr[i-1]] = i

    if absVal > 0:
        sortedArr = [i-absVal for i in sortedArr]
    return sortedArr



def radixSort(arr):
    '''
    基数排序: 桶排序的拓展
    将数组元素看作一个数组, 适合比较长的数字排序
    电话号码的排序
    1. 非原地排序算法: 需要计数数组, 空间由元素的值的范围确定,一般为0,1,2...9
        需要一个已排序数组, 长度与待排序数组一样, 空间复杂度为O(n)
    2. 稳定的: 基于计数排序, 计数排序是稳定的
    3. 时间复杂度: O(len(arr)*n), 
        使用计数排序, 用数组元素的指定数位的值构造好计数桶后, 从后向前遍历待排序数组, 
            根据桶的值, 直接插入到已排序数组, 时间复杂度为O(n)
        从低位向高位迭代, 进行元素的最大长度次迭代, 排序完成

    要求: 数组元素的数位长度是一致的. 不足的可以往高位补0
    sample：[12341234,25342534,16781678,67296729]
    '''
    arrLen = len(arr)
    arrSorted = [0]*arrLen
    eleLenMax = max([len(e) for e in [str(i) for i in arr]])
    # 从后向前, 比较每个元素上数位的值的大小并以此排序元素
    for ieArr in range(eleLenMax-1, -1, -1):
        arrPos = []
        # 拼接数位数组
        for eArr in [str(i) for i in arr]:
            arrPos.append(int(eArr[ieArr]))
        # 计数排序 数位数组
        arrEleCount = RadixCounting(arrPos)
        # 根据数位数组的值去统计数组寻找位置,
        #数位数组的索引与待排序数组索引是一样的, 关联排序
        index = arrLen-1
        for i in arrPos[::-1]:
            arrEleCount[i] = arrEleCount[i] - 1
            arrSorted[arrEleCount[i]] = arr[index]
            index -= 1
        # 进行下一次迭代
        arr = arrSorted.copy()
    return arrSorted

def RadixCounting(arrPos):
    '''
    对应数位上的值数组进行计数排序
    返回计数数组
    '''
    arrEleCount = [0]*10
    # 计数排序 数位数组
    for i in range(len(arrPos)):
        arrEleCount[arrPos[i]] += 1
    for i in range(1, 10):
        arrEleCount[i] += arrEleCount[i-1]
    return arrEleCount
 

if __name__ == '__main__':
    print(datetime.now().strftime('%H:%M:%S.%f')) 
    print('countingSort', countingSort([1, -2, 3, 0, 9, 3, 4, -1, 2, 3]))
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('radixSort', radixSort(
        [12341234, 25342534, 16781678, 67296729, 10781678, 67295729]))
    print(datetime.now().strftime('%H:%M:%S.%f'))