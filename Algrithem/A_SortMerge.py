from datetime import datetime

# 归并排序 MergeSort
def MergeSort(arr):
    # 只有一个元素的区间不再需要排序
    if len(arr) <= 1:
        return arr
    middle = len(arr)//2
    leftArr = MergeSort(arr[:middle])
    rightArr = MergeSort(arr[middle:])
    lenL, lenR = len(leftArr), len(rightArr)
    i, j, k = 0, 0, 0
    while i < lenL and j < lenR:
        if leftArr[i] < rightArr[j]:
            arr[k], i = leftArr[i], i+1
        else:
            arr[k], j = rightArr[j], j+1
        k += 1
    while i < lenL:
        arr[k] = leftArr[i]
        i, k = i+1, k+1
    while j < lenR:
        arr[k] = rightArr[j]
        j, k = j+1, k+1
    # print(i,j,k,arr)
    return arr

# 利用内置函数,分别取最值, 从两个方向逼近    
def MergeSort2(arr):
    start, end = [], []
    if len(arr) <= 1:
        return arr
    while len(arr) > 1:
        a, b = min(arr), max(arr)
        start.append(a)
        end.append(b)
        arr.remove(a)
        arr.remove(b)
    start.append(arr[0])
    end.reverse()
    return start+end

if __name__ == '__main__':
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('MergeSort:', MergeSort(
        [90, 0, -1, 22, 3, 2, 2, 1, 44, 55, 32, 9, 8, 7, 6, 5, 5, 3, 2]))
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('MergeSort:', MergeSort2(
        [90, 0, -1, 22, 3, 2, 2, 1, 44, 55, 32, 9, 8, 7, 6, 5, 5, 3, 2]))
    print(datetime.now().strftime('%H:%M:%S.%f'))    
