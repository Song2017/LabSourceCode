class Solution:
    def majorityElement(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        dic = {}
        for ele in nums:
            dic[ele] = dic.get(ele, 0) + 1
        vs = list(dic.values())
        return list(dic.keys())[vs.index(max(vs))]

so = Solution()
print(so.majorityElement([1,23,5,6,77,1]))        