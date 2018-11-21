# 选择排序 
# 每次选择出一个最值，需要排序的元素越来越少
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
        sortedArr.append(arr.pop(minIndex))
    return sortedArr

print('SelectionSort([90,0,-1,22,3])',SelectionSort([90,0,-1,22,3]))


# 插入排序
# 类似于纸牌游戏,原来的牌从左向右依次增大,得到新牌后排到末尾,
# 然后从后向前进行对比,若新牌值小,那么交换新牌和当前比对牌的位置
# range(3): 0 1 2
def InsertSort(arr):
    for i in range(len(arr)):
        temp = arr[i]
        j = i
        # 当新插入的值小于比对值时,比对的值的位置后移
        while j > 0 and arr[j-1] > temp:
            arr[j]=arr[j-1]
            j = j-1 
        arr[j]=temp
    return arr 
        
print('InsertSort([90,0,-1,22,3])',InsertSort([90,0,-1,22,3]))