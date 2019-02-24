class Solution:
'''
解决思路, 构建可以从栈中弹出的括号字符的**索引的辅助列表**
'''
    def longestValidParenthes(self, s: 'str') -> 'int':
        '''
        给定一个只包含 '(' 和 ')' 的字符串，找出'()'的最大有效长度
        '''
        maxLen = 0
        last = ''
        p = [0]*len(s)
        s = s[s.find('('):]
        for i, c in enumerate(s):
            if c == last:
                p[i] = 1
            else:
                p[i] = p[i-1] + 1
            maxLen = max(p[i], maxLen)
            last = c
        # max length for '()'
        return maxLen - 1 if maxLen % 2 == 1 else maxLen

    def longestValidParentheses1(self, s: 'str') -> 'int':
        '''
        给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。
        cp: cache pop, 缓存可以匹配的索引, 均设置为1
        ml: max length
        cl: continuous length
        '''
        tmp, cp = [],  [0]*len(s)
        for i, c in enumerate(s):
            if c == '(':
                tmp.append(i)
            elif tmp:
                cp[tmp.pop()], cp[i] = 1, 1
        ml, cl = 0, 0
        for i in cp:
            if i:
                cl += 1
            else:
                ml, cl = max(ml, cl), 0
        return max(ml, cl)

    def longestValidParentheses(self, s):
        """
        :type s: str
        :rtype: int
        
        辅助列表中存的是字符的索引
        """
        cl = maxlen = 0
        stack = []
        start = -1
        for i, c in enumerate(s):
            if c == '(':
                stack.append(i)
            else:
                if stack:
                    stack.pop()
                    if stack:
                        cl = i - stack[-1]
                    else:
                        cl = i-start
                    if cl > maxlen:
                        maxlen = cl
                else:
                    start = i
        return maxlen


s = Solution()
# print(s.longestValidParentheses(")("))
print(s.longestValidParentheses("(()"))
# print(s.longestValidParentheses("()"))
# print(s.longestValidParentheses(")()())"))
# print(s.longestValidParentheses(""))
print(s.longestValidParentheses(")()()(()))"))
