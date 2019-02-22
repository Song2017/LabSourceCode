# Definition for singly-linked list.
class ListNode(object):
    def __init__(self, x):
        self.val = x
        self.next = None


class Solution(object): 
    def mergeTwoLists(self, l1, l2):
        head = ListNode(0)
        rtn = head
        while l1 and l2: 
            if l1.val < l2.val:
                rtn.next = l1
                l1 = l1.next
            else:
                rtn.next = l2
                l2 = l2.next
            # 已排序列表需要推进到下一结点
            rtn = rtn.next  
        if l1:
            rtn.next = l1
        if l2:
            rtn.next = l2
        return head.next    
    def mergeTwoListsFast(self, l1, l2):
        """
        :type l1: ListNode
        :type l2: ListNode
        :rtype: ListNode
        """
        
        if l1 is None and l2 is None:
            return None
        if l1 is None and l2:
            return l2
        if l1 and l2 is None:
            return l1
        
        if l1.val > l2.val:
            l2.next = self.mergeTwoLists(l1, l2.next)
            return l2
        else:
            l1.next = self.mergeTwoLists(l1.next, l2)
            return l1

head = ListNode(1)  # 测试代码
p1 = ListNode(2)  # 建立链表1->2->3->4->None
p2 = ListNode(3)
p3 = ListNode(4)
head.next = p1
p1.next = p2
p2.next = p3
head2 = ListNode(1)  # 测试代码
p12 = ListNode(5)
head2.next = p12
s = Solution()
result = s.mergeTwoLists(head, head2)
while result:
    print(11,result.val)
    result = result.next