class MyCircularQueue0:
    '''
    设计你的循环队列实现
    循环队列是一种线性数据结构,其操作表现基于 FIFO（先进先出）原则并且队尾被连接在队首之后以形成一个循环.
    它也被称为“环形缓冲器”.
    循环队列的一个好处是我们可以利用这个队列之前用过的空间.
    在一个普通队列里,一旦一个队列满了,我们就不能插入下一个元素,即使在队列前面仍有空间.
    但是使用循环队列,我们能使用这些空间去存储新的值.
    Note: 为了区分环形队列的首,尾结点, tail指向一个空元素, 即环形队列的实际物理空间要比理论上的长度多1
    你的实现应该支持如下操作:
    MyCircularQueue(k): 构造器,设置队列长度为 k .
    Front: 从队首获取元素.如果队列为空,返回 -1 .
    Rear: 获取队尾元素.如果队列为空,返回 -1 .
    enQueue(value): 向循环队列插入一个元素.如果成功插入则返回真.
    deQueue(): 从循环队列中删除一个元素.如果成功删除则返回真.
    isEmpty(): 检查循环队列是否为空.
    isFull(): 检查循环队列是否已满.

    from collections import deque
    # collections.deque is a collection, while Queue.Queue is a communications mechanism.
    circular_queue = deque([1, 2], maxlen=4)
    circular_queue.append(3)
    circular_queue.extend([4])

    # at this point you have [1,2,3,4]
    print(circular_queue.popleft())  # --> 1 
    print(circular_queue.pop())  #  --> 4

    # key step. effectively rotate the pointer
    # circular_queue.rotate(-1)  # negative to the left. positive to the right
    print(circular_queue[-1])  # 3
    print(circular_queue[0])
    print(circular_queue)
    '''

    def __init__(self, k: int):
        """
        Initialize your data structure hereSet the size of the queue to be k.
        """
        self.cap = k + 1
        self.cq = [0]*self.cap
        self.head = self.tail = 0

    def isEmpty(self) -> bool:
        """
        Checks whether the circular queue is empty or not.
        """
        return self.head == self.tail

    def isFull(self) -> bool:
        """
        Checks whether the circular queue is full or not.
        """
        return (self.tail+1) % self.cap == self.head

    def enQueue(self, value: int) -> bool:
        """
        Insert an element into the circular queue
        Return true if the operation is successful.
        """
        if self.isFull():
            return False
        self.cq[self.tail] = value
        self.tail = (self.tail+1) % self.cap
        return True

    def deQueue(self) -> bool:
        """
        Delete an element from the circular queue
        Return true if the operation is successful.
        """
        if self.isEmpty():
            return False
        self.head = (self.head+1) % self.cap
        return True

    def Front(self) -> int:
        """
        Get the front item from the queue.
        """
        if self.isEmpty():
            return -1
        return self.cq[self.head]

    def Rear(self) -> int:
        """
        Get the last item from the queue.
        """
        if self.isEmpty():
            return -1
        return self.cq[(self.tail-1) % self.cap]


class MyCircularQueue(object):
    '''
            self.cq circlar queue:
            self.h head: 首结点索引
            self.t tail: 尾结点索引+1
            self.cap capacity:
            self.cnt count: 实际存在的元素个数
    '''

    def __init__(self, k):
        """
        Initialize your data structure here. Set the size of the queue to be k.
        :type k: int
        """
        self.cq = [0]*k
        self.h = self.t = 0
        self.cap = k
        self.cnt = 0

    def enQueue(self, value):
        """
        Insert an element into the circular queue. Return true if the operation is successful.
        :type value: int
        :rtype: bool
        """
        if self.cnt < self.cap:
            self.cq[self.t] = value
            self.t = (self.t+1) % self.cap
            self.cnt += 1
            return True
        else:
            return False

    def deQueue(self):
        """
        Delete an element from the circular queue. Return true if the operation is successful.
        :rtype: bool
        """
        if self.cnt > 0:
            self.h = (self.h+1) % self.cap
            self.cnt -= 1

            return True
        else:
            return False

    def Front(self):
        """
        Get the front item from the queue.
        :rtype: int
        """
        if self.cnt > 0:
            return self.cq[(self.h) % self.cap]
        else:
            return -1

    def Rear(self):
        """
        Get the last item from the queue.
        :rtype: int
        """
        if self.cnt > 0:
            return self.cq[(self.t+self.cap-1) % self.cap]
        else:
            return -1

    def isEmpty(self):
        """
        Checks whether the circular queue is empty or not.
        :rtype: bool
        """
        return self.cnt == 0

    def isFull(self) -> bool:
        """
        Checks whether the circular queue is full or not.
        :rtype: bool
        """
        return self.cnt == self.cap

# Your MyCircularQueue object will be instantiated and called as such:
# obj = MyCircularQueue(k)
# param_1 = obj.enQueue(value)
# param_2 = obj.deQueue()
# param_3 = obj.Front()
# param_4 = obj.Rear()
# param_5 = obj.isEmpty()
# param_6 = obj.isFull()
