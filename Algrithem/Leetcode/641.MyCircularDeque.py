class MyCircularDeque:
    '''
    设计实现双端队列。
    你的实现需要支持以下操作：
    MyCircularDeque(k)：构造函数,双端队列的大小为k。
    insertFront()：将一个元素添加到双端队列头部。 如果操作成功返回 true。
    insertLast()：将一个元素添加到双端队列尾部。如果操作成功返回 true。
    deleteFront()：从双端队列头部删除一个元素。 如果操作成功返回 true。
    deleteLast()：从双端队列尾部删除一个元素。如果操作成功返回 true。
    getFront()：从双端队列头部获得一个元素。如果双端队列为空，返回 -1。
    getRear()：获得双端队列的最后一个元素。 如果双端队列为空，返回 -1。
    isEmpty()：检查双端队列是否为空。
    isFull()：检查双端队列是否满了。

    self.cdeq circlar dequeue:
    self.h head: 首结点索引
    self.t tail: 尾结点索引+1
    self.cap capacity:
    self.cnt count: 实际存在的元素个数
    '''

    def __init__(self, k: 'int'):
        """
        Initialize your data structure here. Set the size of the deque to be k.
        """
        self.cap = k
        self.cdeq = [0]*self.cap
        self.h = self.t = self.cnt = 0

    def insertFront(self, value: 'int') -> 'bool':
        """
        Adds an item at the front of Deque. Return true if the operation is successful.
        """
        if self.cnt < self.cap:
            self.h = (self.h + self.cap - 1) % self.cap
            self.cdeq[self.h] = value
            self.cnt += 1
            return True
        else:
            return False

    def insertLast(self, value: 'int') -> 'bool':
        """
        Adds an item at the rear of Deque. Return true if the operation is successful.
        """
        if self.cnt < self.cap:
            self.cdeq[self.t] = value
            self.t = (self.t + 1) % self.cap
            self.cnt += 1
            return True
        else:
            return False

    def deleteFront(self) -> 'bool':
        """
        Deletes an item from the front of Deque. Return true if the operation is successful.
        """
        if self.cnt > 0:
            self.h = (self.h + 1) % self.cap
            self.cnt -= 1
            return True
        else:
            return False

    def deleteLast(self) -> 'bool':
        """
        Deletes an item from the rear of Deque. Return true if the operation is successful.
        """
        if self.cnt > 0:
            self.t = (self.t + self.cap - 1) % self.cap
            self.cnt -= 1
            return True
        else:
            return False

    def getFront(self) -> 'int':
        """
        Get the front item from the deque.
        """
        if self.cnt > 0:
            return self.cdeq[self.h]
        else:
            return -1

    def getRear(self) -> 'int':
        """
        Get the last item from the deque.
        """
        if self.cnt > 0:
            return self.cdeq[(self.t+self.cap-1) % self.cap]
        else:
            return -1

    def isEmpty(self) -> 'bool':
        """
        Checks whether the circular deque is empty or not.
        """
        return self.cnt == 0

    def isFull(self) -> 'bool':
        """
        Checks whether the circular deque is full or not.
        """
        return self.cnt == self.cap


class MyCircularDequeViaBuildInDeque:

    def __init__(self, k):
        """
        Initialize your data structure here. Set the size of the deque to be k.
        :type k: int
        """
        from collections import deque
        self.deque = deque()
        self.a = 0
        self.z = k   # a为队列头，z为队列尾

    def insertFront(self, value):
        """
        Adds an item at the front of Deque. Return true if the operation is successful.
        :type value: int
        :rtype: bool
        """
        if self.a >= self.z:
            return False
        self.deque.appendleft(value)
        self.a += 1
        return True

    def insertLast(self, value):
        """
        Adds an item at the rear of Deque. Return true if the operation is successful.
        :type value: int
        :rtype: bool
        """
        if self.a >= self.z:
            return False
        self.deque.append(value)
        self.a += 1
        return True

    def deleteFront(self):
        """
        Deletes an item from the front of Deque. Return true if the operation is successful.
        :rtype: bool
        """
        if self.a == 0:
            return False
        self.deque.popleft()
        self.a -= 1
        return True

    def deleteLast(self):
        """
        Deletes an item from the rear of Deque. Return true if the operation is successful.
        :rtype: bool
        """
        if self.a == 0:
            return False
        self.deque.pop()
        self.a -= 1
        return True

    def getFront(self):
        """
        Get the front item from the deque.
        :rtype: int
        """
        if self.a == 0:
            return -1
        return self.deque[0]

    def getRear(self):
        """
        Get the last item from the deque.
        :rtype: int
        """
        if self.a == 0:
            return -1
        return self.deque[-1]

    def isEmpty(self):
        """
        Checks whether the circular deque is empty or not.
        :rtype: bool
        """
        return self.a == 0

    def isFull(self):
        """
        Checks whether the circular deque is full or not.
        :rtype: bool
        """
        return self.a == self.z


class MyCircularDequeArray:

    def __init__(self, k):
        """
        Initialize your data structure here. Set the size of the deque to be k.
        :type k: int
        """
        self.k = k
        self.que = []

    def insertFront(self, value):
        """
        Adds an item at the front of Deque. Return true if the operation is successful.
        :type value: int
        :rtype: bool
        """
        if self.isFull():
            return False
        else:
            self.que = [value]+self.que
            return True

    def insertLast(self, value):
        """
        Adds an item at the rear of Deque. Return true if the operation is successful.
        :type value: int
        :rtype: bool
        """
        if self.isFull():
            return False
        else:
            self.que.append(value)
            return True

    def deleteFront(self):
        """
        Deletes an item from the front of Deque. Return true if the operation is successful.
        :rtype: bool
        """
        if self.isEmpty():
            return False
        else:
            self.que.pop(0)
            return True

    def deleteLast(self):
        """
        Deletes an item from the rear of Deque. Return true if the operation is successful.
        :rtype: bool
        """
        if self.isEmpty():
            return False
        else:
            self.que.pop(-1)
            return True

    def getFront(self):
        """
        Get the front item from the deque.
        :rtype: int
        """
        if self.isEmpty():
            return -1
        else:
            return self.que[0]

    def getRear(self):
        """
        Get the last item from the deque.
        :rtype: int
        """
        if self.isEmpty():
            return -1
        else:
            return self.que[-1]

    def isEmpty(self):
        """
        Checks whether the circular deque is empty or not.
        :rtype: bool
        """
        return len(self.que) == 0

    def isFull(self):
        """
        Checks whether the circular deque is full or not.
        :rtype: bool
        """
        return len(self.que) == self.k
# Your MyCircularDeque object will be instantiated and called as such:
# obj = MyCircularDeque(k)
# param_1 = obj.insertFront(value)
# param_2 = obj.insertLast(value)
# param_3 = obj.deleteFront()
# param_4 = obj.deleteLast()
# param_5 = obj.getFront()
# param_6 = obj.getRear()
# param_7 = obj.isEmpty()
# param_8 = obj.isFull()
