# Definition for singly-linked list.
class ListNode(object):
    def __init__(self, x):
        self.val = x
        self.next = None


class Solution(object):
    def mergeKListsExceed(self, lists):
        """
        :type lists: List[ListNode]
        :rtype: ListNode
        使用分治思想, K个list的整体排序递归分解为两两List的有序
        """
        length = len(lists)
        if length == 0:
            return lists
        if length == 1:
            return lists[0]
        mid = length//2
        left = lists[0:mid]
        right = lists[mid: length-1]
        recsl = self.mergeKLists(left)
        recsr = self.mergeKLists(right)
        return self.mergeTwoLists(recsl, recsr)

    def mergeTwoLists(self, l1, l2):
        head = ListNode(0)
        r = head
        while l1 and l2:
            if l1.val < l2.val:
                r.next = l1
            else:
                r.next = l2
        if l1:
            r.next = l1
        if l2:
            r.next = l2
        return head.next
    def mergeKLists(self, lists):
        """
        :type lists: List[ListNode]
        :rtype: ListNode
        获取所有值转为列表, 进行排序, 然后重新返回新的链表
        """
        l = []
        for nodes in lists:
            while nodes:
                l.append(nodes.val)
                nodes = nodes.next
        l.sort()
        head = ListNode(-1)
        temp = head
        for i in l:
            temp.next = ListNode(i)
            temp = temp.next
        return head.next 

        
