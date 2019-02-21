class Solution:
    def lengthOfLongestSubstring(self, s):
        """
        :type s: str
        :rtype: int
        uniqueStart: 不重复子字串的起始索引
        existCharIndexs: 字符在原字符串中的最大的索引
        将不重复的字符串缓存为一个区, 每次移动时从比对一个字符提升到比对不重复字符串缓存区
        O(n)&O(n)
        """
        uniqueStart = maxLength = 0
        existCharIndexs = {}
        for index, char in enumerate(s):
            if char in existCharIndexs and uniqueStart <= existCharIndexs[char]:
                # 出现重复字符时,更新其索引为下一个字符的位置
                uniqueStart = existCharIndexs[char] + 1
            else:
                maxLength = max(maxLength, index-uniqueStart+1)
            existCharIndexs[char] = index
        return maxLength



Solution1 = Solution()
print(Solution1.lengthOfLongestSubstring('asdfasd11111'))
