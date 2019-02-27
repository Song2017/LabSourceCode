class Solution:
    '''
    比较前i-1个数的最小值和i的值
    '''
    def maxProfit0(self, prices) -> int:
        if prices == []:
            return 0
        min_p, max_p = prices[0], 0
        for i in range(len(prices)):
            min_p = min_p if prices[i] > min_p else prices[i]
            max_p = max_p if (prices[i] - min_p) < max_p else prices[i] - min_p
        return max_p

    def maxProfit(self, prices) -> int:
        min_p, max_p = 2**30, 0
        for i in prices:
            if i < min_p:
                min_p = i
            elif i - min_p > max_p:
                max_p = i - min_p
        return max_p


s = Solution()
print(s.maxProfit([7, 1, 5, 3, 6, 4]))
