class Solution:
    def isValid0(self, s: 'str') -> 'bool':
        '''
        有效的括号
        '''
        if len(s) % 2 != 0:
            return False
        tmp = []
        mapc = {')': '(', '}': '{', ']': '['}
        for c in s: 
            if c in mapc.values():
                tmp.append(c)
            else:
                if len(tmp) == 0 or tmp.pop() != mapc.get(c):
                    return False
        return len(tmp) == 0

    def isValid(self, s: 'str') -> 'bool':
        def pair(c):
            if c == ')':
                return '('
            if c == '}':
                return '{'
            if c == ']':
                return '['
        strs = []
        for c in s:
            if c in ['(', '{', '[']:
                strs.append(c)
            elif len(strs) == 0:
                return False
            elif strs.pop() != pair(c):
                return False
        return len(strs) == 0


s = Solution()
print(s.isValid("()[][]{}"))
print(s.isValid(""))
