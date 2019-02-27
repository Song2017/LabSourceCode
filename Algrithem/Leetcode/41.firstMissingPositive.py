class Solution:
    def firstMissingPositive(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        根据正整数数组的特性, 在原数组的空间上做一次排序, 然后根据索引和值之间的关系得到结果 
        O(n) & O(k)
        """
        numsLen = len(nums)
        for i in range(numsLen):
            # 遍历数组，保证数组中的大于0且小于等于数组长度的数i，都位于i-1的位置
            # nums[i] < i+1 and nums[i] > 0: 保证索引不会越界
            # 理解nums[i] != nums[nums[i]-1]:
            # 正确的列表模板是固定的[1,2,3,4,5...], 例如取i=3, nums[3]=4; 有nums[3]-1
            # 也就是nums[3] == nums[nums[3]-1] = 4
            while nums[i] < i+1 and nums[i] > 0 and nums[i] != nums[nums[i]-1]:
                temp = nums[nums[i] - 1]
                nums[nums[i] - 1] = nums[i]
                nums[i] = temp
        # 遍历数组，第一个满足nums[i-1] != i的数，即为缺失的第一个正数
        for i in range(numsLen):
            if nums[i] != i+1:
                return i+1
        return numsLen+1

    def firstMissingPositiveFast(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        简单易懂且高效
        O(n)
        """
        n = 1
        while n in nums:
            n += 1
        return n


so = Solution()
# print(so.threeSum([-1, 23, -5, 6, 77, 1, 0]))
print(so.firstMissingPositive([1, 2, 0]))
print(so.firstMissingPositive([3, 4, -1, 1]))
print(so.firstMissingPositive([33333333]))
print(so.firstMissingPositive([7, 8, 9, 11, 12]))
print(so.firstMissingPositiveFast([1, 2, 0]))
print(so.firstMissingPositiveFast([3, 4, -1, 1]))
print(so.firstMissingPositiveFast([33333333]))
print(so.firstMissingPositiveFast([7, 8, 9, 11, 12]))
