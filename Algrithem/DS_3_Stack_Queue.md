## Stack 栈
### 定义
栈是一种遵循特定操作顺序(先进后出LIFO: last in first out),
    操作受限(只允许在一端插入或删除)的线性数据结构
当某个数据集合只涉及在一端插入和删除数据,并且满足后进先出,先进后出的特性,我们就应该首选“栈”这种数据结构
### 操作
1. push 压栈, 增加一个元素, 满则Overflow 
2. pop  出栈, 弹出栈顶元素, 空则Underflow 
3. peek/top 返回栈顶元素而不删除它, 空则Underflow 
4. isEmpty/isFull 是否为空
### 实现
顺序栈: 数组实现的栈; 链式栈: 链表实现的栈
正常情况下, 二者的出栈,入栈操作都是O(1), 但对顺序栈, 动态扩容时需要申请内存和数据搬移, 最坏时间复杂度变为O(n)
```
# 顺序栈
capcity = 3
def createStack():
    return []
def isEmpty(stack):
    return len(stack) == 0
def push(stack, item):
    if len(stack) == capcity:
        return 'error: stack overflow'
    stack.append(item)
def pop(stack):
    if isEmpty(stack):
        return 'error: stack underflow'
    return stack.pop()
def peek(stack):
    if isEmpty(stack):
        return 'error: stack underflow'
    return stack[len(stack)-1]

stack = createStack()
push(stack, str(10))
push(stack, str(20))
push(stack, str(30))
print(push(stack, str(30)))
print(pop(stack), " popped from stack")
print(peek(stack))


# 链式栈
class StackNode:
    __slots__ = ["data", "next"]
    def __init__(self, data):
        self.data = data
        self.next = None

class Stack(object):
    __slots__ = ["capcity", "root", "currLen"]
    def __init__(self, capcity=3):
        self.capcity = capcity
        self.root = None
        self.currLen = 0
    def isEmpty(self):
        return True if self.root is None else False
    def isFull(self):
        return True if self.capcity == self.currLen else False
    def push(self, data):
        if self.isFull():
            print('stack overflow')
            return
        newNode = StackNode(data)
        # 将原有的数据追加到新增结点上
        newNode.next = self.root
        # 将新增的结点置于栈顶
        self.root = newNode
        self.currLen = self.currLen + 1
    def pop(self):
        if self.isEmpty():
            print('error: stack underflow')
            return
        temp = self.root
        # 将栈顶元素指向第二顺位结点
        self.root = self.root.next
        return temp.data
    def top(self):
        if self.isEmpty():
            print('error: stack underflow')
            return
        return self.root.data

print(' linked stack ')
stackClass = Stack(2)
stackClass.push(str(10))
stackClass.push(str(20))
stackClass.push(str(30))
print(stackClass.top())
print(stackClass.pop(), " popped from stack")

```
### 应用
1. 栈在函数调用中的应用
栈非常适合控制函数中数据的作用域, 在进入被调用函数的时候,分配一段栈空间给这个函数的变量,在函数结束的时候,将栈顶复位,正好回到调用函数的作用域内.
2. 栈在表达式求值中的应用(比如:34+13*9+44-12/3)
利用两个栈,其中一个用来保存操作数,另一个用来保存运算符.我们从左向右遍历表达式,当遇到数字,我们就直接压入操作数栈；当遇到运算符,就与运算符栈的栈顶元素进行比较,若比运算符栈顶元素优先级高,就将当前运算符压入栈,若比运算符栈顶元素的优先级低或者相同,从运算符栈中取出栈顶运算符,从操作数栈顶取出2个操作数,然后进行计算,把计算完的结果压入操作数栈,继续比较.
3. 栈在括号匹配中的应用(比如:{}{[()]()})
用栈保存为匹配的左括号,从左到右一次扫描字符串,当扫描到左括号时,则将其压入栈中；当扫描到右括号时,从栈顶取出一个左括号,如果能匹配上,则继续扫描剩下的字符串.如果扫描过程中,遇到不能配对的右括号,或者栈中没有数据,则说明为非法格式.
当所有的括号都扫描完成之后,如果栈为空,则说明字符串为合法格式；否则,说明未匹配的左括号为非法格式.
4. 如何实现浏览器的前进后退功能？
我们使用两个栈X和Y,我们把首次浏览的页面依次压如栈X,当点击后退按钮时,再依次从栈X中出栈,并将出栈的数据一次放入Y栈.当点击前进按钮时,我们依次从栈Y中取出数据,放入栈X中.当栈X中没有数据时,说明没有页面可以继续后退浏览了.当Y栈没有数据,那就说明没有页面可以点击前进浏览了.
### 内存中的堆栈和数据结构堆栈的区别
内存中的堆栈是真实存在的物理区,数据结构中的堆栈是抽象的数据存储结构.
内存空间在逻辑上分为三部分:代码区,静态数据区和动态数据区,动态数据区又分为栈区和堆区.
代码区:存储方法体的二进制代码.高级调度(作业调度),中级调度(内存调度),低级调度(进程调度)控制代码区执行代码的切换.
静态数据区:存储全局变量,静态变量,常量,常量包括final修饰的常量和String常量.系统自动分配和回收.
栈区:存储运行方法的形参,局部变量,返回值.由系统自动分配和回收.
堆区:new一个对象的引用或地址存储在栈区,指向该对象存储在堆区中的真实数据.


## Queue 队列
### 定义
队列是一种遵循特定操作顺序(先进先出LIFO: last in first out),
    操作受限(入队:只允许在一端插入; 出队:另一端删除)的线性数据结构
当某个数据集合在一端插入, 一端删除数据,并且满足先进先出,我们就应该首选“队列”这种数据结构
### 实现
队列也可以用数组(顺序队列)和链表(链表队列)实现, 
但是出队操作后, 顺序队列的前几位变为空位,达到队列上限后需要进行数据搬移,最坏时间复杂度变为O(n).
为了避免数据搬移操作,就有了循环队列.
循环队列, 把最后一个位置连接回第一个位置形成圆,实现的关键是确定好队空和队满的判定条件.
```
# CircleQueue 循环队列
class MyCircleQueue(object):
    __slots__ = ["head", "size", "tail", "capcity", "queue"]
    def __init__(self, capcity=5):
        # head: 队列开始的数组索引, size: 队列的实际长度
        self.head = self.size = 0
        # tail: 队列结束的数组索引
        self.tail = 0
        self.capcity = capcity
        # 声明队列self.queue[self.tail]=item
        self.queue = [None]*capcity
    def enqueue(self, item):
        if self.size == self.capcity:
            return "error: queue full: "+item
        self.queue[self.tail]=item
        # 计算下次入队的索引
        self.tail = (self.tail + 1) % self.capcity
        self.size = self.size + 1
        # for i in self.queue:
        #     print(i, end='...')
    def dequeue(self):
        if self.size == 0:
            return "error: queue empty"
        temp = self.queue[self.head]
        # 计算下次出队的索引
        self.head = (self.head + 1) % self.capcity
        self.size = self.size - 1
        return temp 

circleQueue = MyCircleQueue()
print(circleQueue.dequeue())
circleQueue.enqueue(1)
circleQueue.enqueue(12)
circleQueue.enqueue(13)
circleQueue.enqueue(16)
circleQueue.enqueue(123)
print(circleQueue.enqueue('134'))
print(circleQueue.dequeue())
print(circleQueue.dequeue())
print(circleQueue.enqueue('135'))
print(circleQueue.enqueue('136'))
print(circleQueue.enqueue('137'))
print(circleQueue.dequeue())
print(circleQueue.dequeue())
print(circleQueue.enqueue('aaa'))
print(circleQueue.enqueue('bbb'))
```

### 应用
1.阻塞队列
    1.在队列的基础上增加阻塞操作,就成了阻塞队列.
    2.阻塞队列就是在队列为空的时候,从队头取数据会被阻塞,因为此时还没有数据可取,直到队列中有了数据才能返回；
    如果队列已经满了,那么插入数据的操作就会被阻塞,直到队列中有空闲位置后再插入数据,然后在返回.
    3.从上面的定义可以看出这就是一个“生产者-消费者模型”.这种基于阻塞队列实现的“生产者-消费者模型”可以有效地协调生产和消费的速度.
2.并发队列
    1.在多线程的情况下,多个线程同时操作队列时就存在线程安全问题.能够有效解决线程安全问题的队列就称为并发队列.
    2.并发队列简单的实现就是在enqueue(),dequeue()方法上加锁,但是独占式的锁, 在线程挂起,恢复和等待时存在很大的开销.
    3.一种非常高效的并发队列实现: 基于数组的循环队列利用CAS(compare and swap)原子操作.
        CAS语义:我认为V的值应该为A,如果是,那么将V的值更新为B,否则不修改并告诉V的值实际为多少
        CAS算法使用: 读取内存中位置并记住其中的值(旧值), 基于记住的旧值计算出新的值. 然后使用CAS交换新值,比较内存中的旧值是否与记住的旧值相等, 若否,从头开始重复,读取旧值, 计算新值, CAS计算.
        CAS有3个操作数:内存值V,旧的预期值A,要修改的新值B.当且仅当预期值A和内存值V相同时,将内存值V修改为B,否则什么都不做 
3.线程池资源枯竭是的处理
    在资源有限的场景,当没有空闲资源时,基本上都可以通过“队列”这种数据结构来实现请求排队.