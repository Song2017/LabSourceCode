class Solution(object):
    def twoSum2(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        通过和与已知加数计算出未知加数, 通过hash结构缓存所有待比较数
        判断未知加数是否存在于待比较数中
        O(n**2)
        """ 
        for i in range(len(nums)): 
            for j in range(i+1, len(nums)):
                if nums[i] + nums[j] == target:
                    return i,j 
    def twoSumFast(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        O(n)
        """
        mirror = {}
        for idx, num in enumerate(nums):
            if num in mirror:
                return [mirror[num], idx]
            mirror[target - num] = idx                   
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        通过和与已知加数计算出未知加数, 通过hash结构缓存所有待比较数
        判断未知加数是否存在于待比较数中
        O(n)
        """          
        dic = {nums[i]:i for i in range(len(nums))}
        for i in range(len(nums)):
            j = target-nums[i]
            if j in dic.keys() and i != dic[j]:
                return i, dic.get(j)

so = Solution()
print(so.twoSum([1,23,5,6,77,1], 2))


