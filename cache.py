# 快速排序
# 取基准值,元素按大小左右分区,然后进行递归直到每个分区只有一个元素或为空
# 排序思想: 分而治之 D&C divide and conquer
# 递归: 基线条件 不再进行递归的条件 设计数组时,多是数组为空或只有一个元素
#       递归条件 继续调用函数自身的条件
# O(nlogn) n:每层元素的个数; logn:调用栈的高度.
#          O(n):处理每层n个元素的时间; O(logn): 需要处理的层数
def QuickSort(arr):
    if not arr:
        return
    arrLen = len(arr)
    if arrLen < 2:
        return arr
    # 基准值为数组首位,末位,中间位数字的平均值
    pivot = (arr[0] + arr[-1] + arr[arrLen//2])/3
    # 推导式简单实现[i, pivot]
    less = [i for i in arr[:] if i <= pivot]
    # 推导式简单实现(pivot, len(arr)]
    greater = [i for i in arr[:] if i > pivot]
    return QuickSort(less) + QuickSort(greater)

print('QuickSort([90,0,-1,22,3])', QuickSort([90, 0, -1, 22, 3]))


# 编程珠玑实现
# 双向排序: 提高非随机输入的性能
# 不需要额外的空间,在待排序数组本身内部进行排序
# 基准值通过random随机选取
# 入参: 待排序数组, 数组开始索引 0, 数组结束索引 len(array)-1
import random

def swap(arr, l, u):
    arr[l],arr[u] = arr[u],arr[l]
    return arr

def QuickSort_Perl(arr, l, u):
    # 小数组排序i可以用插入或选择排序 
    # if u-l < 50 : return arr
    # 基线条件: low index = upper index; 也就是只有一个值的区间
    if l >= u:
        return arr
    #swap(arr, l, int(random.uniform(l, u)))
    tmpIndex = int(random.uniform(l, u))
    temp = arr[tmpIndex]
    i, j = l, u
    while True:
        print(i, j, arr[i], arr[j], temp)
        while arr[i] <= temp and i < j:
            i += 1
        while arr[j] > temp and j > i:
            j -= 1
        if i >= j:
            break
        arr[i], arr[j] = arr[j], arr[i]
    #swap(arr, l, j)
    print('arr ',arr)
    QuickSort_Perl(arr, l, j-1)
    QuickSort_Perl(arr, j+1, u)
    return arr

print('QuickSort_Perl([22,22,0,-1,22,3])',
      QuickSort_Perl([22, 22, 0, -1, 22, 3], 0, 5))
