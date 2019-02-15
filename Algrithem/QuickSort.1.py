# 快速排序 
# 取基准值,元素按大小左右分区,然后进行递归直到每个分区只有一个元素或为空
# 排序思想: 分而治之 D&C divide and conquer
# 递归: 基线条件 不再进行递归的条件 设计数组时,多是数组为空或只有一个元素
#       递归条件 继续调用函数自身的条件
# O(nlogn) n:每层元素的个数; logn:调用栈的高度. 
#          O(n):处理每层n个元素的时间; O(logn): 需要处理的层数
def QuickSort(arr):
    if not arr : return
    arrLen = len(arr)
    if arrLen < 2: 
        return arr
    pivot = (arr[0] + arr[-1] + arr[arrLen//2])/3
    less = [i for i in arr[:] if i<=pivot]
    greater = [i for i in arr[:] if i>pivot]
    return QuickSort(less) + QuickSort(greater)

print('QuickSort([90,0,-1,22,3])', QuickSort([90,0,-1,22,3]))
    

#编程珠玑实现
# 双向排序: 提高非随机输入的性能
# 不需要额外的空间,在待排序数组本身内部进行排序
def swap(arr, l, u):
    arr[l] ,arr[u]= arr[u],arr[l]
    return arr 
import random
def QuickSort_Perl(arr, l, u):
    # if u-l < 50 : return arr
    if l >= u: return arr
    # 随机选取基准值, 并将基准值替换到数组第一个元素
    swap(arr,l, int(random.uniform(l,u)))
    temp = arr[l]
    i,j = l,u  
    while True :
        # 第一个元素是基准值,所以要跳过
        i+=1
        # 在小区间中, 进行排序
        while i <= u and arr[i] <= temp: i+=1
        # 因为j肯定大于i, 所以索引值肯定在小区间中
        while arr[j] > temp: j-=1
        if i > j: break
        arr[i], arr[j] =arr[j],arr[i]
    swap(arr, l, j)
    QuickSort_Perl(arr, l, j-1)
    QuickSort_Perl(arr, j+1, u)
    return arr

print('QuickSort_Perl([40,90,0,-1,22,3])', QuickSort_Perl([40,90,0,-1,22,3],0,5))