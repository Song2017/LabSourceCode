class Solution:
    def evalRPN0(self, tokens: 'List[str]') -> 'int':
        '''
        根据逆波兰表示法，求表达式的值。
        有效的运算符包括 +, -, *, / 。每个运算对象可以是整数，也可以是另一个逆波兰表达式。
        说明：
        整数除法只保留整数部分。
        给定逆波兰表达式总是有效的。换句话说，表达式总会得出有效数值且不存在除数为 0 的情况。
        '''
        nums = []
        tokens.reverse()
        while tokens:
            i = tokens.pop()
            if i in ['+', '-', '*', '/']:
                tmp = nums.pop()
                if i == '+':
                    nums.append(nums.pop() + tmp)
                elif i == '-':
                    nums.append(nums.pop() - tmp)
                elif i == '*':
                    nums.append(int(nums.pop() * tmp))
                else:
                    nums.append(int(nums.pop() / tmp))
            else:
                nums.append(int(i))
            print(nums)
        return nums[0]

    def evalRPN(self, tokens):
        """
        :type tokens: List[str]
        :rtype: int
        """
        stack = []
        for i in tokens:
            if i in ['+', '-', '*', '/']:
                if i == "+":
                    stack.append(stack.pop()+stack.pop())
                elif i == "-":
                    stack.append(-stack.pop()+stack.pop())
                elif i == "*":
                    stack.append(stack.pop()*stack.pop())
                else:
                    stack.append(int(1/stack.pop()*stack.pop()))
            else:
                stack.append(int(i))
        return stack[0]


s = Solution()
# ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
print(s.evalRPN(["10", "6", "9", "3", "+", "-11",
                 "*", "/", "*", "17", "+", "5", "+"]))
print(s.evalRPN(["4", "3", "/"]))
