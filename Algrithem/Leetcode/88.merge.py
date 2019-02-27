class Solution:
    def mergeFast(self, nums1, m, nums2, n):
        """
        :type nums1: List[int]
        :type m: int
        :type nums2: List[int]
        :type n: int
        :rtype: void Do not return anything, modify nums1 in-place instead.

        nums2替换掉nums1中的0, 进行排序
        """
        for i in nums2:
            nums1[m] = i
            m += 1
        nums1.sort()

    def merge(self, nums1, m, nums2, n):
        """
        :type nums1: List[int]
        :type m: int
        :type nums2: List[int]
        :type n: int
        :rtype: void Do not return anything, modify nums1 in-place instead.
        从后向前插入值
        """
        i = m - 1
        j = n-1

        for k in range(m+n-1, -1, -1):
            if i == -1:
                nums1[k] = nums2[j]
                j -= 1
            elif j == -1:
                nums1[k] = nums1[i]
                i -= 1
            elif nums1[i] > nums2[j]:
                nums1[k] = nums1[i]
                i -= 1
            else:
                nums1[k] = nums2[j]
                j -= 1
