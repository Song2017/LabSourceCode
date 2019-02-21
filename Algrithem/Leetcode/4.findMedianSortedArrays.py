class Solution:
    def findMedianSortedArrays(self, nums1, nums2):
        """
        :type nums1: List[int]
        :type nums2: List[int]
        :rtype: float
        get median for nums1 and nums2, then use quick sort
        """
        nums = nums1 + nums2
        # 长度减1: 解决索引出错
        # 根据取整判断长度是奇偶数
        mid = (len(nums) - 1) / 2.0
        if mid == int(mid):
            rtn = self.QuickSortPosK(nums, int(mid)+1)
        else:
            rtn = (self.QuickSortPosK(nums, int(mid)+2) +
                   self.QuickSortPosK(nums, int(mid)+1))/2
        return rtn

    # 用快速排序查找第K大元素(非索引) 1=<K<=len(arr)
    def QuickSortPosK(self, arr, K):
        # 基准值为数组首位,末位,中间位数字的平均值
        if len(arr) == 1:
            return arr[0]
        pivot = arr[-1]
        # 推导式简单实现[i, pivot]
        less = [i for i in arr[:] if i <= pivot]
        greater = [i for i in arr[:] if i > pivot]
        lenLess = len(less)
        if lenLess == K:
            return less[-1]
        elif lenLess > K:
            return self.QuickSortPosK(less[:-1], K)
        elif lenLess < K:
            return self.QuickSortPosK(greater, K-lenLess)

    def findMedianSortedArraysFast(self, nums1, nums2):
        """
        :type nums1: List[int]
        :type nums2: List[int]
        :rtype: float
        """
        nums = nums1+nums2
        nums.sort()
        # 得到的是索引
        mid = (len(nums) - 1) / 2.0
        # 根据取整后的结果判断数组的个数奇偶性
        if mid == int(mid):
            return nums[int(mid)]
        else:
            return (nums[int(mid)] + nums[int(mid) + 1]) / 2.0


Solution1 = Solution()
print(Solution1.findMedianSortedArrays([], [9, 11]))
