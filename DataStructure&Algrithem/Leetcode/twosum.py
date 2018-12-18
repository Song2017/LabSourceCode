class Solution(object):
    def twoSum2(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """ 
        for i in range(len(nums)): 
            for j in range(i+1, len(nums)):
                if nums[i] + nums[j] == target:
                    return i,j 
    def twoSum(self, nums, target): 
        dic = {nums[i]:i for i in range(len(nums))}
        for i in range(len(nums)):
            j = target-nums[i]
            if j in dic.keys() and i != dic[j]:
                return i, dic.get(j)

so = Solution()
print(so.twoSum([1,23,5,6,77,1], 2))


