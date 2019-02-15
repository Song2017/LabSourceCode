
## Sort Algrithem 排序算法
### 分类
O(n^2): 冒泡排序、插入排序、选择排序
O(nlogn): 归并排序、快速排序
O(n): 计数排序、基数排序、桶排序
### 分析排序算法
#### 时间复杂度
1. 最好情况、最坏情况、平均情况
原始数据的不同的有序程度,对应不同的时间复杂度. 
#### 空间复杂度
算法的内存消耗可以通过空间复杂度来衡量。
*原地排序算法*:就是特指空间复杂度是 O(1) 的排序算法
#### 稳定性
概念:如果待排序的序列中存在值相等的元素，经过排序之后，相等元素之间原有的先后顺序不变。
实际上,双十一时的订单都会有两个属性,下单时间和金额. 如何计算发货顺序呢,我们先按照下单时间给订单排序，排序完成之后，我们用稳定排序算法，按照订单金额重新排序。两遍排序之后，我们得到的订单数据就是按照金额从小到大排序，*金额相同的订单按照下单时间从早到晚排序,稳定排序算法可以保持金额相同的两个对象，在排序之后的前后顺序不变*。
## O(n^2): 冒泡排序、插入排序、选择排序、希尔排序
### Bubble Sort 冒泡排序 
自然界中, 气泡的密度比水小,在水中,越大的气泡受到的浮力也就越大, 就会先到达水面
冒泡排序只会操作相邻的两个数据。
每次冒泡操作都会**对相邻的两个元素进行比较，看是否满足大小关系要求**。如果不满足就让它俩互换。
一趟冒泡会让至少一个元素移动到它应该在的位置，重复 n 趟，就完成了 n 个数据的排序工作。
#### 分析
1. 原地排序算法: 只涉及相邻数据的交换, 需要一个常量级的临时空间, 空间复杂度为O(1)
2. 稳定的: 相等的元素不会进行交换,所以等值的元素在排序前后不会改变顺序
3. 时间复杂度: 最好时只要进行一趟冒泡, O(n)
    最坏情况要进行n趟冒泡,O(n^2)
    平均情况作简单估算, 
        冒泡排序包含比较和交换两个操作, 比较只需读值不需要写内存, 所以我们考虑交换操作,交换一次, 逆序度就减一.
        逆序度=满有序度-有序度, 所以逆序度一定小于满有序, 也就是n(n-1)/2, 
        逆序度为0时, 不需进行交换操作,取两者中间值n(n-1)/4
#### 实现
```
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
```
### Insert Sort 插入排序 
像纸牌游戏,得到新牌后插到合适的位置
将数组中的数据分为两个区间，已排序区间和未排序区间。初始已排序区间只有一个元素，就是数组的第一个元素。
插入算法的核心思想是**取未排序区间中的元素，在已排序区间中找到合适的插入位置将其插入**，并保证已排序区间数据一直有序。
重复这个过程，直到未排序区间中元素为空
#### 分析
1. 原地排序算法: 只涉及数据的比较和移动, 不需要额外的临时空间, 空间复杂度为O(1)
2. 稳定的: 进行严格比较时,即相等的元素不进行交换,等值的元素在排序前后不会改变顺序
3. 时间复杂度: 最好时,比较一个数据就能确定插入的位置,只是进行一次从头到尾的遍历, O(n)
    最坏情况,每次插入都相当于在数组的第一个位置插入新的数据,O(n^2)
    平均情况作简单估算, 
        在有序数组中插入一个值的时间复杂度是O(n), 插入排序只是排序了n次, 也就是O(n^2)
#### 实现     
类似于纸牌游戏,得到新牌后插到合适的位置
假设a[0]是已排序区间,接着就近取出未排序区间中的第一个元素(a[1]), 寻找a[1]在已排序区间中的位置,进行插入, 
接下来依次排序a[2],a[3]...a[n] 
```
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
```
### Selection Sort 选择排序
选择排序算法的实现思路有点类似插入排序，也分已排序区间和未排序区间。
但是**选择排序每次会从未排序区间中找到最小的元素，将其放到已排序区间的末尾**。
#### 分析
1. 原地排序算法: 只涉及数据的比较和移动, 不需要额外的临时空间, 空间复杂度为O(1)
2. 稳定的: 进行严格比较时,即相等的元素不进行交换,等值的元素在排序前后不会改变顺序
3. 时间复杂度: 即使是有序的情况,每次也要遍历一遍未排序区间,复杂度为 n+n-1+...1 , O(n^2)
    最坏情况,每次也只是需要遍历一遍未排序区间选择的最小元素,O(n^2)
    平均情况作简单估算, 
        时间复杂度的上限和下限都是O(n^2), 所以平均情况也是O(n^2)
#### 实现    
每次选择出一个最值，下次排序只需要比较剩下的元素,需要排序的元素越来越少
```
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
```
###  Shell Sort 希尔排序 
缩小增量插入排序算法, 通过逐步缩小插入排序增量, 减小最坏情况下的插入排序的时间复杂度. Marcin Ciura's gap sequence, 基于经验得出的一组序列, 但是序列的生成规律还未得到证明,  [701, 301, 132, 57, 23, 10, 4, 1]
#### 分析
	 1. 原地排序算法: 只涉及数据的比较和移动, 不需要额外的临时空间, 空间复杂度为O(1)
	 2. 稳定的: 进行严格比较时,即相等的元素不进行交换 arr[j-gap] > temp,等值的元素在排序前后不会改变顺序
	 3. 时间复杂度: 例: 5,4,3,2,1
	       最好时,比较一个数据就能确定插入的位置,只是进行8*n次从头到尾的遍历, 不需要进行元素交换 O(n)
	       最坏情况下, 希尔排序中gap为4时就交换了1和5, 接着交换3次就达到整体有序, 总共交换了4次
	                插入排序中, 数字5要经过4次交换, 到达末尾, 4经过3次到达倒数第二位,总共交换4+3+2+1=10次 
#### 实现 	                
```
Shell Sort 希尔排序    
def ShellInsertSort(arr, gap):
    for i in range(len(arr)):
        temp = arr[i]
        j = i
        while j >= gap and arr[j-gap] > temp:
            arr[j] = arr[j-gap]
            j-=gap
            arr[j] = temp
def ShellSort(arr):
    '''
    基于经验得出的一组序列, 但是序列的生成规律还未得到证明
    Marcin Ciura's gap sequence
    '''
    gaps = [701, 301, 132, 57, 23, 10, 4, 1]
    for gap in gaps:
        ShellInsertSort(arr, gap)
    return arr
```
## O(nlogn): 归并排序、快速排序
#### 归并排序、快速排序异同
归并排序: 先二分法分拆数组,进行局部比较,局部有序后再合并得到整体有序. 某种意义上是**按数组索引比较**
快速排序: 选出基准值后,比较剩余元素与基准值,获得元素的位置.递归操作下去得到排序结果. 可以说是**按数组值比较**
###  Merge Sort 归并排序  
排序一个数组，我们*先把数组从中间分成前后两部分，然后对前后两部分分别排序，再将***排好序的两部分合并**在一起.
#### 分析
	 1. 原地排序算法: 只涉及数据的比较和移动, 不需要额外的临时空间, 空间复杂度为O(1)
	 2. 不稳定的: 合并操作是,等值的元素在排序前后可能会改变顺序. 考虑[2,2,2,2]
	 3. 时间复杂度: 只是进行一次粗略的估计
            归并排序会先将整个数组递归的拆分成单个元素, 然后进行排序,合并. 
            每次都要对n个元素扫描, 近似的取n个元素的时间复杂度为o(n).
            因为采用二分法拆分数组, 所以操作的深度就是o(log2n), 两个步骤是嵌套的关系取乘积o(nlog2n)
#### 实现 	                
```
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
```
###  Quick Sort 快速排序  
取基准值,元素按大小左右分区,然后进行递归直到每个分区只有一个元素或为空
#### 分析
    1. 原地排序算法: 只涉及数据的比较和移动, 不需要额外的临时空间, 空间复杂度为O(1)
    2. 不稳定的: 快排会按值移动数组元素位置, 是不稳定的, 假设[2,2,2,3,2], 基准值取3时, 最后的2会跑到前面
    3. 时间复杂度: O(nlogn) n:每层元素的个数; logn:调用栈的高度.
           O(n):处理每层n个元素的时间; O(logn): 需要处理的层数
    4. 单向实现: 简单易懂, 基准值选取: 首位,末位和中位的平均值
       双向排序: 提高非随机输入的性能,不需要额外的空间,在待排序数组本身内部进行排序, 基准值通过random随机选取
#### 实现 	                
``` 
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
```
#### 用快速排序查找第K大元素 1=<K<=len(arr)
```
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
 
print('QuickSortPosK',QuickSortPosK([90, 0, -1, 22, 3,3,3],4))
```
## O(n) : 计数排序、基数排序、桶排序
线性排序: 时间复杂度是线性的O(n)
### Bucket sort 桶排序
将要排序的数据分到几个有序的桶里，每个桶里的数据再单独进行排序。
桶内排完序之后，再把每个桶里的数据按照顺序依次取出，组成的序列就是有序的了。
#### 分析
时间复杂度: 设n个数据, m个桶, 每个桶内部用快速排序. 每个桶的数据有k=n/m个
O(mklog2k)代入k=n/m得O(nlog2[n/m]), 根据log函数的特性得到O(n(log2n-log2m))
也就是说桶分的足够多时, 时间复杂度无限趋向于0. 当然这不太实际
#### 应用
但是桶排序非常适合数据密集分布的数据, 像考试的分数, 几百万的数据只会密集分布在100(百分制)个区间内
适合于外部排序,就是数据存储在外部磁盘中，数据量比较大，内存有限，无法将数据全部加载到内存中
    
假设有10GB的订单数据，需按订单金额(假设金额都是正整数)进行排序,但内存有限，仅几百MB
解决思路：
扫描一遍文件，看订单金额所处数据范围，比如1元-10万元，那么就分100个桶。
第一个桶存储金额1-1000元之内的订单，第二个桶存1001-2000元之内的订单，依次类推。
每个桶对应一个文件，并按照金额范围的大小顺序编号命名(00，01，02，…，99)。
然后将100个小文件依次放入内存并用快排排序。
所有文件排好序后，只需按照文件编号从小到大依次读取每个小文件并写到大文件中即可
### Counting sort 计数排序
将数据值的范围作为索引, 反过来操作数组的索引
计数排序是桶排序的一种特殊情况. 适用于数据数量多, 但是数据值的范围集中,有限且均为整数的情况.
#### 分析
    1. 非原地排序算法: 需要计数数组, 空间由值的范围确定,一般比较小
        需要一个已排序数组, 长度与待排序数组一样, 空间复杂度为O(n)
    2. 稳定的:从后向前遍历数组, 后面的元素, 仍然在后面
    3. 时间复杂度: O(n), 构造好计数桶后, 从后向前遍历待排序数组, 根据桶的值, 直接插入到已排序数组

统计数据值, 转换为正整数. 存在小数,乘10倍增; 有负数, 加最小值绝对值归零
根据数据范围造桶, 然后往桶里添加计数, 注意计数的规则,前一个桶的数加上自身桶里的数, 是一个递增的数列
进行排序, 为了稳定性,从后向前遍历数据, 
    根据数据的值从桶里取数,这个数就是排序后的数据位置, 
    取数后要将桶的数的值减一, 这就是当前桶对应的待排序数据的下一个数据位置, 也是当前数据对应的已排序数组索引
待排序数组遍历完成后, 已排序数组也就插入完成
#### 应用
考试分数排序, 年龄排序
#### 实现
```
def countingSort(arr):
    '''
    计数排序: 桶排序的特殊情况, 将数据值的范围作为索引, 反过来进行排序
    适合值的范围有限且均为正整数的数据
    适用的实际情况:对考试分数排序

    要求:待排序数组的值均为正整数(不包含0)
    排序前格式化数组: 
        存在小于1的整数, 数组的每个值都增加最小值绝对值+1, 使最小值为1
        存在小数, 同时扩大倍数:小数位数*10
    '''
    arrLength = len(arr)
    countArrLength = max(arr)
    countArr = [0]*countArrLength
    # [2, 2, 3, 2, 0, 0, 0, 0, 1]
    for i in range(arrLength):
        countArr[arr[i]-1] += 1
    # [2, 4, 7, 9, 9, 9, 9, 9, 10]
    for i in range(1, countArrLength):
        countArr[i] += countArr[i-1]
    # 进行排序, 为了稳定性,从后向前遍历数据,
    #     根据数据的值从桶里取数,这个数就是排序后的数据位置,
    #     取数后要将桶的数的值减一, 这就是当前桶对应的待排序数据的下一个数据位置, 也是当前数据对应的已排序数组索引
    sortedArr = [0]*arrLength
    for i in arr[::-1]:
        countArr[i-1] = countArr[i-1] - 1
        sortedArr[countArr[i-1]] = i
    return sortedArr
print(countingSort([1, 2, 3, 4, 9, 3, 4, 1, 2, 3]))
```
### Radix sort 基数排序
将计数排序看作桶排序的一种特殊情况, 基数排序可以看作桶排序的拓展算法.
将待排序数组的数据看作更小元素的组成的数组, [123,456]中的123, 看作['1','2','3']
然后从后向前一位一位的排序.从低数位有序到高数位有序, 最终整体有序
位之间的排序采用计数排序得到线性时间复杂度
#### 分析
    1. 非原地排序算法: 需要计数数组, 空间由元素的值的范围确定,一般为0,1,2...9
        需要一个已排序数组, 长度与待排序数组一样, 空间复杂度为O(n)
    2. 稳定的: 基于计数排序, 计数排序是稳定的
    3. 时间复杂度: O(len(arr)*n), 
        使用计数排序, 用数组元素的指定数位的值构造好计数桶后, 从后向前遍历待排序数组, 
            根据桶的值, 直接插入到已排序数组, 时间复杂度为O(n)
        从低位向高位迭代, 进行元素的最大长度次迭代, 排序完成
#### 应用
基数排序对要排序的数据是有要求的，需要可以分割出独立的“位”来比较，而且位之间有递进的关系. 
每一位的数据范围不能太大，要可以用线性排序算法来排序，否则，基数排序的时间复杂度就无法做到 O(n) 
#### 实现
``` 
def radixSort(arr):
    '''
    基数排序: 桶排序的拓展
    将数组元素看作一个数组, 适合比较长的数字排序
    电话号码的排序

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
``` 
### 排序优化
如何实现一个通用的、高性能的排序函数
排序算法为了提升性能, 主要有两种方式, 分治法或构建辅助数据,
    分治法都会都会有logn的复杂度, 像, 归并排序,快速排序, 希尔排序
    构建辅助数据的多为特殊数据, 像基数排序, 计数排序, 桶排序.
但对于小规模数据,分治法或构件辅助数据需要的额外运算, 不足以弥补带来的提升, 
多直接用冒泡排序, 选择排序或直接插入排序. 

排序算法	平均时间复杂度	最坏时间复杂度	空间复杂度	是否稳定
冒泡排序	O(n^2)    	    O(n^2)    	  O(1)     	是
选择排序	O(n^2)    	    O(n^2)    	  O(1)     	是
直接插入排序 O(n^2)    	    O(n^2)    	   O(1)     是
归并排序	O(nlogn)    	O(nlogn)      O(n)O(n)	不是/是
快速排序	O(nlogn)    	O(n^2)    	  O(logn)	不是/是
堆排序	    O(nlogn)    	O(nlogn)      O(1)     	不是
希尔排序	O(nlogn)    	O(ns)O(ns)	  O(1)     	不是
计数排序	O(n+k)    	    O(n+k)        O(n+k)	是
基数排序	O(n∗M)          O(n∗M)    	  O(M) 	    是 

#### .Net FrameWork Array Sort

    桌面版本4.5
        IntrospectiveSort(keys, values, index, length, comparer)
        如果待排序数组长度小于16
            <=3: 直接交换1,2 1,3 2,3
            插入排序 InsertionSort
        如果待排序数组长度大于16: 
            根据二分法得到分层深度, 然后选取分区, 递归降低深度为0, 调用堆排序
            if (depthLimit == 0) Heapsort(keys, values, lo, hi, comparer); return;
            depthLimit--;
            PickPivotAndPartition(keys, values, lo, hi, comparer);
            IntroSort(keys, values, num2 + 1, hi, depthLimit, comparer);
            hi = num2 - 1;
    其他版本 
        DepthLimitedQuickSort(keys, values, index, length + index - 1, comparer, 32)
        使用快速排序降低递归深度, 深度降为0后, 调用堆排序 
##### C# InsertionSort
```
private static void InsertionSort(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer)
{
    for (int i = lo; i < hi; i++)
    {
        int num = i;
        TKey tkey = keys[i + 1];
        TValue tvalue = (values != null) ? values[i + 1] : default(TValue);
        while (num >= lo && comparer.Compare(tkey, keys[num]) < 0)
        {
            keys[num + 1] = keys[num];
            if (values != null)
            {
                values[num + 1] = values[num];
            }
            num--;
        }
        keys[num + 1] = tkey;
        if (values != null)
        {
            values[num + 1] = tvalue;
        }
    }
}   
```
##### C# FloorLog2
```
internal static int FloorLog2(int n)
{
    int num = 0;
    while (n >= 1)
    {
        num++;
        n /= 2;
    }
    return num;
}
```
##### C# PickPivotAndPartition
```
private static int PickPivotAndPartition(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer)
{
    int num = lo + (hi - lo) / 2;
    ArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, comparer, lo, num);
    ArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, comparer, lo, hi);
    ArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, comparer, num, hi);
    TKey tkey = keys[num];
    ArraySortHelper<TKey, TValue>.Swap(keys, values, num, hi - 1);
    int i = lo;
    int num2 = hi - 1;
    while (i < num2)
    {
        while (comparer.Compare(keys[++i], tkey) < 0)
        {
        }
        while (comparer.Compare(tkey, keys[--num2]) < 0)
        {
        }
        if (i >= num2)
        {
            break;
        }
        ArraySortHelper<TKey, TValue>.Swap(keys, values, i, num2);
    }
    ArraySortHelper<TKey, TValue>.Swap(keys, values, i, hi - 1);
    return i;
}
```
##### C# Heapsort
```
private static void Heapsort(TKey[] keys, TValue[] values, int lo, int hi, IComparer<TKey> comparer)
{
    int num = hi - lo + 1;
    for (int i = num / 2; i >= 1; i--)
    {
        ArraySortHelper<TKey, TValue>.DownHeap(keys, values, i, num, lo, comparer);
    }
    for (int j = num; j > 1; j--)
    {
        ArraySortHelper<TKey, TValue>.Swap(keys, values, lo, lo + j - 1);
        ArraySortHelper<TKey, TValue>.DownHeap(keys, values, 1, j - 1, lo, comparer);
    }
} 
private static void DownHeap(TKey[] keys, TValue[] values, int i, int n, int lo, IComparer<TKey> comparer)
{
    TKey tkey = keys[lo + i - 1];
    TValue tvalue = (values != null) ? values[lo + i - 1] : default(TValue);
    while (i <= n / 2)
    {
        int num = 2 * i;
        if (num < n && comparer.Compare(keys[lo + num - 1], keys[lo + num]) < 0)
        {
            num++;
        }
        if (comparer.Compare(tkey, keys[lo + num - 1]) >= 0)
        {
            break;
        }
        keys[lo + i - 1] = keys[lo + num - 1];
        if (values != null)
        {
            values[lo + i - 1] = values[lo + num - 1];
        }
        i = num;
    }
    keys[lo + i - 1] = tkey;
    if (values != null)
    {
        values[lo + i - 1] = tvalue;
    }
}
```
##### C# DepthLimitedQuickSort
```
internal static void DepthLimitedQuickSort(TKey[] keys, TValue[] values, int left, int right, IComparer<TKey> comparer, int depthLimit)
{
    while (depthLimit != 0)
    {
        int num = left;
        int num2 = right;
        int num3 = num + (num2 - num >> 1);
        ArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, comparer, num, num3);
        ArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, comparer, num, num2);
        ArraySortHelper<TKey, TValue>.SwapIfGreaterWithItems(keys, values, comparer, num3, num2);
        TKey tkey = keys[num3];
        for (;;)
        {
            if (comparer.Compare(keys[num], tkey) >= 0)
            {
                while (comparer.Compare(tkey, keys[num2]) < 0)
                {
                    num2--;
                }
                if (num > num2)
                {
                    break;
                }
                if (num < num2)
                {
                    TKey tkey2 = keys[num];
                    keys[num] = keys[num2];
                    keys[num2] = tkey2;
                    if (values != null)
                    {
                        TValue tvalue = values[num];
                        values[num] = values[num2];
                        values[num2] = tvalue;
                    }
                }
                num++;
                num2--;
                if (num > num2)
                {
                    break;
                }
            }
            else
            {
                num++;
            }
        }
        depthLimit--;
        if (num2 - left <= right - num)
        {
            if (left < num2)
            {
                ArraySortHelper<TKey, TValue>.DepthLimitedQuickSort(keys, values, left, num2, comparer, depthLimit);
            }
            left = num;
        }
        else
        {
            if (num < right)
            {
                ArraySortHelper<TKey, TValue>.DepthLimitedQuickSort(keys, values, num, right, comparer, depthLimit);
            }
            right = num2;
        }
        if (left >= right)
        {
            return;
        }
    }
    ArraySortHelper<TKey, TValue>.Heapsort(keys, values, left, right, comparer);
}
```
