## recursive 递归
递归是一种应用非常广泛, 优雅的编程技巧.像DFS深度优先搜索、前中后序二叉树遍历等都是使用递归.
与分治的区别: 分治是一种解决问题的处理思想，递归是一种编程技巧
### 使用递归的条件
1. 函数可以调用自己
    一个问题的解可以分解为几个子问题的解,这个问题与分解之后的子问题,除了数据规模不同,求解思路完全一样
2. 函数停止调用自己
    也就是存在递归终止条件, 避免形成无限循环
### 如何写递归代码
写出递推公式,找到终止条件
找到将大问题分解为小问题的规律,并且基于此写出递推公式,然后再推敲终止条件,最后将递推公式和终止条件翻译成代码
涉及数组时,终止条件多是数组为空或只有一个元素
### 优劣
优势
1. 相比分治法将问题在广度进行拓展, 递归主要集中在问题深度的解决上. 
计算机作为初衷计算是机器, 精于数据存储和数理计算,十分擅长做重复的事情, 所以递归思想十分契合计算机的运行.
误区
1. 迷失于递归规律的分析
人脑侧重于问题展开后的推理演绎和判断,当我们考虑递归问题,习惯将递归问题从垂直的深度上一层一层的展开到平面, 试图搞清楚计算机中每一步的执行, 特别当面对一个问题要分解为多个子问题的情况, 容易被繁多的递归值分散精力, 失去对问题主线的关注. 
    我们找到递归公式后, 根据问题情况代入初始值(多为终止条件), 进行数学归纳证明, 抛开对实际数值的不断计算
    也就是说编写递归代码的关键: 只要遇到递归,我们就把它抽象成一个递推公式,不用想一层层的调用关系,不要试图用人脑去分解递归的每个步骤.
2. 警惕堆栈溢出
内存中的堆栈是物理存在的, 受限于内存, 堆栈的长度是一定的, 递归的深度大于堆栈的长度时就会发生堆栈溢出
    1. 我们可以设置递归深度的限制
    2. 递归函数转为for循环
```
def test1(n):
    # 设置最大递归深度
    maxDepth = 100
    recursionDepth = 0
    def funcRecursion(n):
        nonlocal recursionDepth
        if recursionDepth >= maxDepth: return "stack overflow"
        recursionDepth = (recursionDepth + 1)
        if n==1: return 1
        return funcRecursion(n-1) + n

    return funcRecursion(n)
print(test1(99)) 
#print(test1(101))

def test11(n):
    sum=0
    for i in range(1, n+1):
        sum+=i
    return sum
print(test11(99)) 
print(test11(101))
```
3. 避免重复计算
通过一个数据结构（比如散列表）来缓存已经求解过的 f(k).当递归调用到 f(k) 时,先看下是否已经求解过了.
如果是,则直接从散列表中取值返回,不需要重复计算.
```
from datetime import datetime

def test(n):
    # 设置最大递归深度
    maxDepth = 10 
    cache = {}
    def funcRecursion(n, recursionDepth): 
        # 函数调用记录
        # print(datetime.now().strftime('%H:%M:%S.%f'))
        recursionDepth = recursionDepth + 1 
        if recursionDepth > maxDepth: raise Exception("stack overflow")
        if n==1: 
            cache[1] = 1
            return 1 
        elif n==2:
            cache[2] = 2
            return 2
        # 若已被缓存,则返回缓存值; 若无, 则获取前两次的递归值
        # 因为进行了缓存, 前两次的递归值不需要再递归获取
        if not n in cache.keys():
            cache[n]  =  funcRecursion(n-1, recursionDepth) + funcRecursion(n-2, recursionDepth) 
        return cache[n]
    return funcRecursion(n, 0)
print(test(9))  
#print(test(12))  
```
### 实例分析
假如这里有 n 个台阶,每次你可以跨 1 个台阶或者 2 个台阶,请问走这 n 个台阶有多少种走法? 
    1. 分析: 可以根据第一步的走法把所有走法分为两类,第一类是第一步走了 1 个台阶,另一类是第一步走了 2 个台阶.
    所以 n 个台阶的走法就等于先走 1 阶后,剩下n-1 个台阶的走法加上先走 2 阶后,n-2 个台阶的走
    f(n) = f(n-1)+f(n-2)
    2. 穷举找规律
        台阶    走法
        1       1   1\
        2       2   1,1\2
        3       3   1,1,1\1,2\2,1
        4       5   1,1,1,1\2,1,1\1,2,1\1,1,2\2,2
        5       8   11111,2111,1211,1121,1112,221,212,122
    根据走法进行归纳: 1,2,3,5,8... 得到f(n) = f(n-1)+f(n-2)