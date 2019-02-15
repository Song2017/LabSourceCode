# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    def addTwoNumbers(self, l1, l2):
        """
        :type l1: ListNode
        :type l2: ListNode
        :rtype: ListNode
        将待加的数存储为单链表, 考察对单链表的使用
        """
        rtn = ListNode(0)
        r = rtn
        carry = 0
        while l1 or l2:
            x = l1.val if l1 else 0
            y = l2.val if l2 else 0
            r.next = ListNode((x+y + carry) % 10)
            carry = 1 if (x + y + carry) > 9 else 0
            r = r.next
            if l1 != None:
                l1 = l1.next
            if l2 != None:
                l2 = l2.next
        if carry > 0:
            r.next = ListNode(1)
        #rtn.next.val: 7
        return rtn.next
    def addTwoNumbersGreat(self, l1, l2):
        """
        :type l1: ListNode
        :type l2: ListNode
        :rtype: ListNode
        """
        l3 = ListNode(0)
        before = head = l3
        while l1 and l2:
            s = l1.val + l2.val + l3.val
            if s>=10:
                l3.val = s - 10
                l3.next = ListNode(1)
                before = l3
                l3 = l3.next
            else:
                l3.val = s
                l3.next = ListNode(0)
                before = l3
                l3 = l3.next
            l1 = l1.next
            l2 = l2.next
        if not (l1 or l2):
            pass
        else:
            con = l1 if l1 else l2
            while con:
                l3.val += con.val
                more = 0
                if l3.val >= 10:
                    l3.val = l3.val - 10
                    more = 1
                l3.next = ListNode(more)
                before = l3
                l3 = l3.next
                con = con.next
        
        if l3.val == 0:before.next = None
        return head
                


# 输入：(2 -> 4 -> 3) + (5 -> 6 -> 6 -> 9 -> 9)
l1 = ListNode(2)
l1.next = ListNode(4)
l1.next.next = ListNode(3)
print(l1.val, l1.next.val, l1.next.next.val)
l2 = ListNode(5)
l2.next = ListNode(6)
l2.next.next = ListNode(6)
l2.next.next.next = ListNode(9)
l2.next.next.next.next = ListNode(9)
print(l2.val, l2.next.val, l2.next.next.val)
sol = Solution()
r = sol.addTwoNumbers(l1, l2)
print(r.val, r.next.val, r.next.next.val, r.next.next.next.val,
      r.next.next.next.next.val, r.next.next.next.next.next.val)
