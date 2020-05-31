class Solution:
    # 输入: nums = [5,6,7,8,10], target = 8
    # 输出: 3
    def search_binary(self, nums: list, target: int) -> list:
        if target not in nums:
            return -1


if __name__ == "__main__":
    s = Solution()
    print(s.search_binary([4, 5, 7, 8, 10, 11], 11))
