class Solution(object):
    def threeSum(self, nums):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，
        使得 a + b + c = 0 ？找出所有满足条件且不重复的三元组
        通过和与已知加数计算出未知加数, 通过hash结构缓存所有待比较数
        判断未知加数是否存在于待比较数中
        """
        rtn = set()
        for target in nums:
            mirror = {}
            nums2 = nums.copy()
            nums2.remove(target)
            for idx, num in enumerate(nums2):
                if num in mirror:
                    rtnEle = [target, nums2[mirror[num]], nums2[idx]]
                    rtnEle.sort()
                    rtn.add(tuple(rtnEle))
                mirror[-target - num] = idx
        return [list(i) for i in rtn]

    def threeSumFast(self, nums):
        """
        :type nums: List[int]
        :rtype: List[List[int]]
        通过hash结构缓存去重值及出现的次数

        将值按正负区分, 将正负列表中的数字求和, 判断和的相反数是否仍存在于字典中

        """
        #将输入列表的值作为索引, 对应出现的次数作为新的字典结构的值
        dic = {}
        for ele in nums:
            if ele not in dic:
                dic[ele] = 0
            dic[ele] += 1
        # 存在3个0的特殊情况
        if 0 in dic and dic[0] > 2:
            rst = [[0, 0, 0]]
        else:
            rst = []

        pos = [p for p in dic if p > 0]
        neg = [n for n in dic if n < 0]

        # 若全为正或负值, 不存在和为0的情况
        for p in pos:
            for n in neg:
                inverse = -(p + n)
                if inverse in dic:
                    if inverse == p and dic[p] > 1:
                        rst.append([n, p, p])
                    elif inverse == n and dic[n] > 1:
                        rst.append([n, n, p])
                    # 去重: 小于负值且大于正值可以排除掉重复使用二者之间的值
                    elif inverse < n or inverse > p or inverse == 0:
                        rst.append([n, inverse, p])
        return rst


so = Solution()
#print(so.threeSum([-1, 23, -5, 6, 77, 1, 0]))
print(so.threeSum2([-13, -1, 0, 1, 2, 3, -1, -4, 14]))
