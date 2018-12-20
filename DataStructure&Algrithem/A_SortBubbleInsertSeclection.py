#!/usr/bin/env python
# -*- coding: utf-8 -*-
from datetime import datetime 

# Bubble Sort 冒泡排序
# 冒泡排序只会操作相邻的两个数据。
# 自然界中, 气泡的密度比水小,在水中,越大的气泡受到的浮力也就越大, 就会先到达水面
# 每次冒泡操作都会对相邻的两个元素进行比较，看是否满足大小关系要求。如果不满足就让它俩互换。
# 一次冒泡会让至少一个元素移动到它应该在的位置，重复 n 次，就完成了 n 个数据的排序工作。
def bubbleSort(arr):
    length = len(arr)
    if length <= 0:
        return arr
    for i in range(length):
        # 每一趟冒泡都会通过交换,排好一个元素, 当没有交换操作时就意味着整个数组是有序的
        isCompare = False
        for j in range(length-i-1):
            if arr[j] > arr[j+1]:
                arr[j], arr[j+1] = arr[j+1], arr[j]
                isCompare = True 
        if not isCompare:
            break                
    return arr



# 插入排序
# 类似于纸牌游戏,得到新牌后插到合适的位置
# 假设a[0]是已排序区间,接着就近取出未排序区间中的第一个元素(a[1]), 寻找a[1]在已排序区间中的位置,进行插入, 
# 接下来依次排序a[2],a[3]...a[n]
# range(3): 0 1 2
def InsertSort(arr):
    for i in range(len(arr)):
        temp = arr[i]
        j = i 
        # 取未排序区间中的元素，在已排序区间中找到合适的插入位置将其插入，并保证已排序区间数据一直有序
        # j > 0表示开始时,a[0]是已排序区间; temp是未排序区间中的第一个元素
        # 接下来保证已排序区间有序, 当temp小于已排序区间中元素, 有序元素相应后移,temp插入到合适位置
        while j > 0 and temp < arr[j-1]:
            arr[j]=arr[j-1]
            j = j-1 
        arr[j]=temp
    return arr 



# 选择排序 
# 选取得分最高的3名同学, 一旦选出后, 就不再参加排名
# 选择排序每次会从未排序区间中找到最小的元素，将其放到已排序区间的末尾
# O（n**2） n+(n-1)+...1=n/2(n+1)
def FindMin(arr):
    if not arr or len(arr) <=0 : 
        return
    temp = arr[0]
    curIndex = 0
    for i in range(1, len(arr)):
        if temp > arr[i]:
            temp=arr[i]
            curIndex=i
    return curIndex
def SelectionSort(arr):
    sortedArr = []
    minIndex=0
    for i in range(len(arr)):
        minIndex = FindMin(arr)
        # arr数组中的最小值被弹出
        sortedArr.append(arr.pop(minIndex))
    return sortedArr



        


if __name__ == '__main__':
    print(datetime.now().strftime('%H:%M:%S.%f')) 
    print('bubbleSort:', bubbleSort(
        [90, 0, -1, 22, 3, 2, 2, 1, 44, 55, 32, 9, 8, 7, 6, 5, 5, 3, 2]))
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('SelectionSort:', SelectionSort(
        [90, 0, -1, 22, 3, 2, 2, 1, 44, 55, 32, 9, 8, 7, 6, 5, 5, 3, 2]))
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('InsertSort:', InsertSort(
        [90, 0, -1, 22, 3, 2, 2, 1, 44, 55, 32, 9, 8, 7, 6, 5, 5, 3, 2]))
    print(datetime.now().strftime('%H:%M:%S.%f'))
