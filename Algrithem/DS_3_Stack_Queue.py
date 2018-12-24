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