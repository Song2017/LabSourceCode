'''
# 快速排序
1. 取基准值,元素按大小左右分区,然后进行递归直到每个分区只有一个元素或为空
2. 排序思想: 分而治之 D&C divide and conquer
3. 递归: 基线条件 不再进行递归的条件 涉及数组时,多是数组为空或只有一个元素
       递归条件 继续调用函数自身的条件
4. O(nlogn) n:每层元素的个数; logn:调用栈的高度.
           O(n):处理每层n个元素的时间; O(logn): 需要处理的层数
5. 单向实现: 简单易懂
    基准值选取: 首位,末位和中位的平均值
6. 双向排序: 提高非随机输入的性能
    不需要额外的空间,在待排序数组本身内部进行排序
    基准值通过random随机选取
'''
# 快速排序
# 取基准值,元素按大小左右分区,然后进行递归直到每个分区只有一个元素或为空
# 排序思想: 分而治之 D&C divide and conquer
# 递归: 基线条件 不再进行递归的条件 涉及数组时,多是数组为空或只有一个元素
#       递归条件 继续调用函数自身的条件
# O(nlogn) n:每层元素的个数; logn:调用栈的高度.
#          O(n):处理每层n个元素的时间; O(logn): 需要处理的层数
def QuickSort(arr): 
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

# 用快速排序查找第K大元素(非索引值) 1=<K<=len(arr)
def QuickSortPosK(arr, K):
    # 基准值为数组首位,末位,中间位数字的平均值
    if len(arr) == 1 : return arr[0]
    pivot = arr[-1]
    # 推导式简单实现[i, pivot]
    less = [i for i in arr[:] if i <= pivot]
    greater = [i for i in arr[:] if i > pivot]
    lenLess = len(less)
    if lenLess == K:
        return less[-1]
    elif lenLess > K:
        return QuickSortPosK(less[:-1], K)
    elif lenLess < K:
        return QuickSortPosK(greater, K-lenLess)
 
print('QuickSortPosK',QuickSortPosK([90, 0, -1, 22, 3, 3, 3],4))

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
    # 随机选取基准值, 并将基准值替换到数组第一个元素        
    swap(arr, l, int(random.uniform(l, u)))
    temp = arr[l]
    # 缓存边界值, 从上下边界同时排序
    i, j = l, u
    while True:
        # 第一个元素是基准值,所以要跳过
        i+=1
        # 在小区间中, 进行排序
        # 从下边界开始寻找大于基准值的索引
        while i <= u and arr[i] <= temp:
            i += 1
        # 从上边界开始寻找小于基准值的索引
        # 因为j肯定大于i, 所以索引值肯定在小区间中
        while arr[j] > temp:
            j -= 1
        # 如果小索引仍小于大索引, 调换二者位置
        if i >= j:
            break
        arr[i], arr[j] = arr[j], arr[i]
    # 将基准值的索引从下边界调换到索引分割点
    swap(arr, l, j)
    QuickSort_Perl(arr, l, j-1)
    QuickSort_Perl(arr, j+1, u)
    return arr

print('QuickSort_Perl([-22, -21, 0, 1, 2, 22])',
      QuickSort_Perl([-22, -21, 0, 1, 2, 22], 0, 5))
