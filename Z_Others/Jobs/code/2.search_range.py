class Solution:
    # 给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
    # 你的算法时间复杂度必须是 O(log n) 级别。
    # 如果数组中不存在目标值，返回 [-1, -1]。
    # 示例 1:
    # 输入: nums = [5,7,7,8,8,10], target = 8
    # 输出: [3,4] 
    def search_range(self, nums: list, target: int) -> list:
        if target not in nums:
            return [-1, -1]


if __name__ == "__main__":
    s = Solution()
    print(s.search_range([4, 4, 5, 7, 8, 8, 8, 10, 11], 11))
