class Solution:
    '''
    给定一个整数数组 nums, 找到一个具有最大和的连续子数组(子数组最少包含一个元素),返回其最大和
    判断前i个数的和是否大于0, 第i+1个数加上小于0的前i个数的和会使值更小
    max_sum: 最大的和
    pos_sum: 前i个数的和, 如果前i个数的和小于0, 从第i+1个数开始统计
    '''

    def maxSubArray(self, nums) -> int:
        max_sum, pos_sum = nums[0], 0
        for num in nums:
            pos_sum += num
            if pos_sum > max_sum:
                max_sum = pos_sum
            # [-1]
            if pos_sum < 0:
                pos_sum = 0
        return max_sum

    def maxSubArrayFast(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        pre = nums[0]
        res = pre
        for i in range(1, len(nums)):
            if pre+nums[i] > nums[i]:
                pre += nums[i]
            else:
                pre = nums[i]
            if pre > res:
                res = pre
        return res


so = Solution()
# print(so.threeSum([-1, 23, -5, 6, 77, 1, 0]))
print(so.maxSubArray([1, 2, 0]))
print(so.maxSubArray([3, 4, -1, 1]))
print(so.maxSubArrayFast([-1]))
print(so.maxSubArray([7, 8, 9, 11, 12]))
