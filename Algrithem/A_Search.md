## Search Algrithem 搜索算法
搜索算法的思想和排序算法是一致的,只是最终的结果变成返回具体的值
例如, 查找第K大元素, 可以结合快速排序算法的思想
### 为什么要有搜索算法
首先, 对一个固定的结果集, 如果结果集合中的元素数量多, 顺序查找的时间复杂度O(n)即使是线性的, 最终需要的时间也很长.
这种情况下, 二分查找可以极大的缩短搜索时间.
其次, 生产环境下的数据集合绝大多数是实时变化的, 像十大热词的搜索, 互联网中的内容具有强时效性,热词的更新非常快
这时, 可以用深度搜索
### 分类
顺序查找, 二分查找
### Binary Search 二分查找
也叫折半查找算法, 针对"有序数据集合"的查找算法
优势
    “近似”查找问题
        二分查找更适合用在“近似”查找问题，
        在这类问题上(实际数据经常会有重复值的情况)，二分查找的优势更加明显, 内存预读会减少查找时间。 
        相较于散列表、二叉树这些支持快速查找的动态数据结构, 二分查找使用的内存空间是最少的. 
        散列表和二叉树都需要比较多的额外内存空间, 适合“值等于给定值”的查找,
    基于链表存储的二分查找分析:
        假设链表长度为n，二分查找每次都要找到中间点(计算中忽略奇偶数差异): 
        第一次查找中间点，需要移动指针n/2次；第二次，需要移动指针n/4次；第三次需要移动指针n/8次；
        以此类推，一直到1次为值
        总共指针移动次数(查找次数) = n/2 + n/4 +...+ 1，这是个等比数列，根据等比数列求和公式：Sum = n - 1. 
        最后算法时间复杂度是：O(n-1)，记为O(n)，时间复杂度和顺序查找时间复杂度相同
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
时间复杂度:最坏时间复杂度O(logn)
#### 二分问题
实际数据经常会有重复值的情况
1. 查找第一个值等于给定值的元素
``` 
def binarySearch(arr, value):
    low = 0
    high = len(arr) - 1
    while low <= high:
        # 等价于 mid = (low + high)//2, 下面的写法可以避免大数之和的溢出
        # 不同语言中, 双目运算符>> 优先级低于单目运算符+
        mid = low + ((high - low) >> 1)
        # 存在相等的值时, 等号会取第一个符合的值
        if arr[mid] >= value:
            high = mid - 1
        # low或high直接取mid会出现死循环, 当二者的值相等
        elif arr[mid] < value:
            low = mid + 1 
    # 大于等于会将索引都转移到low, 添加low的值的有效判断
    if  low < len(arr) and arr[low] == value : return low
    else: return -1
```
2. 查找最后一个值等于给定值的元素
```
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
```
3. 查找第一个大于等于给定值的元素 
```
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
```
4. 查找最后一个小于等于给定值的元素
```
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

```
#### 实现
**二分查找细节注意: 终止条件、区间上下界更新方法、返回值选择**

#### 平方根求解
```
def squareByTaylor(num, precise=2):
    '''
    根据泰勒展开式计算平方根
    precise:正整数
    负数返回复数集
    '''
    result, preresult = 1, 0
    while abs(result - preresult) > 0.1 ** precise:
        preresult = result
        result = (result + num / result) / 2
    return str(result) 
def squareByBinary(num, precise=2):
    '''
    根据二分法逼近答案
    precise应该是正整数
    负数返回复数集
    '''
    result, preresult = num/2, 0
    while abs(result**2 - num) > 0.1 ** precise:
        if result**2 > num:
            result = (result + preresult) / 2
        elif result**2 < num:
            preresult, result = result,  (result + num) / 2
    return str(result)  
```
#### 循环有序的数组使用二分查找
leetcode 33
我们发现循环数组存在一个性质：以数组中间点为分区，会将数组分成一个有序数组和一个循环有序数组。
    如果首元素小于 mid，说明前半部分是有序的，后半部分是循环有序数组；
    如果首元素大于 mid，说明后半部分是有序的，前半部分是循环有序的数组；
    如果目标元素在有序数组范围中，使用二分查找；
    如果目标元素在循环有序数组中，设定数组边界后，使用以上方法继续查找。
