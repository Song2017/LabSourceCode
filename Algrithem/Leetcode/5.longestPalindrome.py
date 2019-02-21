class Solution:
    def longestPalindrome(self, s):
        """
        :type s: str
        :rtype: str
        https://www.felix021.com/blog/read.php?2040
        """
        sc, si, mx, id = '#', '#', 0, 0
        for c in s:
            si = si + c + sc
        p = [0]*len(si)

        for i, c in enumerate(si):
            if i == 0:
                continue
            p[i] = min(p[id*2-i], mx-i) if mx > i else 1
            while i+p[i] < len(si) and si[i-p[i]] == si[i+p[i]]:
                p[i] += 1
            if i+p[i] > mx:
                id, mx = i, i+p[i]
        mxp = max(p)
        cindex = [i for i, v in enumerate(p) if v == mxp][-1]
        return si[cindex-mxp+1:cindex+mxp].replace(sc, '')


Solution1 = Solution()
print(Solution1.longestPalindrome("abcba"))
print(Solution1.longestPalindrome("aaaa"))
print(Solution1.longestPalindrome("babad"))
print(Solution1.longestPalindrome("bb"))
print(Solution1.longestPalindrome("121"))
print(Solution1.longestPalindrome("cbbd"))
print(Solution1.longestPalindrome("a"))
print(Solution1.longestPalindrome("ac"))
