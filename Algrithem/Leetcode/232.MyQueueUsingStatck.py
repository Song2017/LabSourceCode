class MyQueue(object):
    '''
    使用栈实现队列的下列操作：

    push(x) -- 将一个元素放入队列的尾部。
    pop() -- 从队列首部移除元素。
    peek() -- 返回队列首部的元素。
    empty() -- 返回队列是否为空。
    '''

    def __init__(self):
        """
        Initialize your data structure here.
        """
        self.stack = []
        self.len = 0

    def push(self, x):
        """
        Push element x to the back of queue.
        :type x: int
        :rtype: None
        """
        self.stack.append(x)
        self.len += 1

    def pop(self):
        """
        Removes the element from in front of queue and returns that element.
        :rtype: int
        """
        if not self.len:
            return False
        self.len -= 1
        temp = self.stack[0]
        self.stack = self.stack[1:]
        return temp

    def peek(self):
        """
        Get the front element.
        :rtype: int
        """
        if not self.len:
            return -1
        return self.stack[0]

    def empty(self):
        """
        Returns whether the queue is empty.
        :rtype: bool
        """
        if self.len:
            return False
        else:
            return True


# Your MyQueue object will be instantiated and called as such:
# obj = MyQueue()
# obj.push(x)
# param_2 = obj.pop()
# param_3 = obj.peek()
# param_4 = obj.empty()
