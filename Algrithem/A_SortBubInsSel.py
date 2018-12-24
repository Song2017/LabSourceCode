#!/usr/bin/env python
# -*- coding: utf-8 -*-
from datetime import datetime 

# Bubble Sort 冒泡排序
# 冒泡排序只会操作相邻的两个数据。 
# 自然界中, 气泡的密度比水小,在水中,越大的气泡受到的浮力也就越大, 就会先到达水面
# 冒泡排序只会操作相邻的两个数据。
# 每次冒泡操作都会**对相邻的两个元素进行比较，看是否满足大小关系要求**。如果不满足就让它俩互换。
# 一趟冒泡会让至少一个元素移动到它应该在的位置，重复 n 趟，就完成了 n 个数据的排序工作。
# #### 分析
# 1. 原地排序算法: 只涉及相邻数据的交换, 需要一个常量级的临时空间, 空间复杂度为O(1)
# 2. 稳定的: 相等的元素不会进行交换,所以等值的元素在排序前后不会改变顺序
# 3. 时间复杂度: 最好时只要进行一趟冒泡, O(n)
#     最坏情况要进行n趟冒泡,O(n^2)
#     平均情况作简单估算, 
#         冒泡排序包含比较和交换两个操作, 比较只需读值不需要写内存, 所以我们考虑交换操作,交换一次, 逆序度就减一.
#         逆序度=满有序度-有序度, 所以逆序度一定小于满有序, 也就是n(n-1)/2, 
#         逆序度为0时, 不需进行交换操作,取两者中间值n(n-1)/4
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



# Insert Sort 插入排序
# 像纸牌游戏,得到新牌后插到合适的位置
# 将数组中的数据分为两个区间，已排序区间和未排序区间。初始已排序区间只有一个元素，就是数组的第一个元素。
# 插入算法的核心思想是**取未排序区间中的元素，在已排序区间中找到合适的插入位置将其插入**，并保证已排序区间数据一直有序。
# 重复这个过程，直到未排序区间中元素为空
# #### 分析
# 1. 原地排序算法: 只涉及数据的比较和移动, 不需要额外的临时空间, 空间复杂度为O(1)
# 2. 稳定的: 进行严格比较时,即相等的元素不进行交换,等值的元素在排序前后不会改变顺序
# 3. 时间复杂度: 最好时,比较一个数据就能确定插入的位置,只是进行一次从头到尾的遍历, O(n)
#     最坏情况,每次插入都相当于在数组的第一个位置插入新的数据,O(n^2)
#     平均情况作简单估算, 
#         在有序数组中插入一个值的时间复杂度是O(n), 插入排序只是排序了n次, 也就是O(n^2)
# #### 实现     
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
            # print(arr)
            arr[j]=arr[j-1]
            j = j-1
            arr[j]=temp
    return arr 

# Shell Sort 希尔排序    
# #### 分析
# 1. 原地排序算法: 只涉及数据的比较和移动, 不需要额外的临时空间, 空间复杂度为O(1)
# 2. 稳定的: 进行严格比较时,即相等的元素不进行交换 arr[j-gap] > temp,等值的元素在排序前后不会改变顺序
# 3. 时间复杂度: 例: 5,4,3,2,1
#       最好时,比较一个数据就能确定插入的位置,只是进行8*n次从头到尾的遍历, 不需要进行元素交换 O(n)
#       最坏情况, 希尔排序中gap为4时得到交换了1和5, 后续交换3次, 总共交换了4次
#                插入排序中, 要经过5次交换, 到达1的位置, 总共交换10次 
def ShellInsertSort(arr, gap):
    for i in range(len(arr)):
        temp = arr[i]
        j = i
        while j >= gap and arr[j-gap] > temp:
            # print(arr)
            arr[j] = arr[j-gap]
            j-=gap
            arr[j] = temp

def ShellSort(arr):
    # 基于经验得出的一组序列, 但是序列的生成规律还未得到证明
    # Marcin Ciura's gap sequence
    gaps = [701, 301, 132, 57, 23, 10, 4, 1]
    for gap in gaps:
        ShellInsertSort(arr, gap)
    return arr



# Selection Sort 选择排序 
# 选择排序算法的实现思路有点类似插入排序，也分已排序区间和未排序区间。
# 但是**选择排序每次会从未排序区间中找到最小的元素，将其放到已排序区间的末尾**。
# #### 分析
# 1. 原地排序算法: 只涉及数据的比较和移动, 不需要额外的临时空间, 空间复杂度为O(1)
# 2. 稳定的: 进行严格比较时,即相等的元素不进行交换,等值的元素在排序前后不会改变顺序
# 3. 时间复杂度: 即使是有序的情况,每次也要遍历一遍未排序区间,复杂度为 n+n-1+...1 , O(n^2)
#     最坏情况,每次也只是需要遍历一遍未排序区间选择的最小元素,O(n^2)
#     平均情况作简单估算, 
#         时间复杂度的上限和下限都是O(n^2), 所以平均情况也是O(n^2)
# #### 实现    
# 每次选择出一个最值，下次排序只需要比较剩下的元素,需要排序的元素越来越少
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
    print('ShellSort:', ShellSort(
        [90, 0, -1, 22, 3, 2, 2, 1, 44, 55, 32, 9, 8, 7, 6, 5, 5, 3, 2]))
    # print(datetime.now().strftime('%H:%M:%S.%f'))    
    # print('ShellSort2:', ShellSort([5,4,3,2,1]))
    # print(datetime.now().strftime('%H:%M:%S.%f'))    
    # print('InsertSort2:', InsertSort([5,4,3,2,1]))
    # print(datetime.now().strftime('%H:%M:%S.%f'))        
