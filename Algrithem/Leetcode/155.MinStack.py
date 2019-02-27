class MinStack0:
    '''
    设计一个支持 push，pop，top 操作，并能在常数时间内检索到最小元素的栈。

    push(x) -- 将元素 x 推入栈中。
    pop() -- 删除栈顶的元素。
    top() -- 获取栈顶元素。
    getMin() -- 检索栈中的最小元素    
    '''
    __slots__ = ["minval", "stack"]

    def __init__(self):
        """
        initialize your data structure here.
        """
        self.minval = None
        self.stack = []

    def push(self, x: int) -> None:
        if self.minval is None or x < self.minval:
            self.minval = x
        self.stack.append(x)

    def pop(self) -> None:
        if len(self.stack) == 0:
            return None
        if self.stack.pop() == self.minval:
            if len(self.stack) == 0:
                self.minval = None
            else:
                self.minval = min(self.stack)
        return None

    def top(self) -> int:
        if len(self.stack) == 0:
            return None
        return self.stack[-1]

    def getMin(self) -> int:
        return self.minval


class MinStack:
    __slots__ = ["min", "stack"]

    def __init__(self):
        """
        initialize your data structure here.
        """
        self.stack = []
        self.min = None

    def push(self, x):
        """
        :type x: int
        :rtype: void
        """
        self.stack.append(x)
        if self.min is None or self.min > x:
            self.min = x

    def pop(self):
        """
        :rtype: void
        """
        popItem = self.stack.pop()
        if len(self.stack) == 0:
            self.min = None
            return popItem

        if popItem == self.min:
            self.min = self.stack[0]
            for i in self.stack:
                if i < self.min:
                    self.min = i
        return popItem

    def top(self):
        """
        :rtype: int
        """
        return self.stack[-1]

    def getMin(self):
        """
        :rtype: int
        """
        return self.min


obj = MinStack()
obj.push(-2)
obj.push(0)
obj.push(-3)
print(obj.top())
print(obj.getMin())
obj.pop()
print(obj.top())
print(obj.getMin())
