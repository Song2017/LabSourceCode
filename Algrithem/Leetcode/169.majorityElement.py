class Solution:
    def majorityElement(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        查找众数
        hash反存值和出现的次数
        """
        #利用字典表反存值:出现的次数
        dic = {}
        for i in nums:
            if i not in dic:
                dic[i] = 1
            else:
                dic[i] +=1
        
        #根据列表获取值最大的索引
        vs = list(dic.values())
        return list(dic.keys())[vs.index(max(vs))]
    def majorityElementFast(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        dict1 = {}
        for i in nums:
            if i not in dict1:
                dict1[i] = 1
            else:
                dict1[i] +=1
                
        return max(dict1,key=dict1.get)
so = Solution()
print(so.majorityElement([1,23,5,6,77,1]))        
print(so.majorityElementFast([1,23,1,5,6,77,1])) 