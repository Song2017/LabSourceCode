# Definition for singly-linked list.
class ListNode(object):
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution(object):
    def mergeKLists(self, lists):
        """
        :type lists: List[ListNode]
        [[1,4,5],[1,3,4],[2,6]]
        :rtype: ListNode
        """
        if len(lists) == 0: return None
        if len(lists) == 1: return lists[0]
        head = {}
        tail = {}
        for l in lists:
            while(l):
                v = l.val
                if v in head:
                    tail[v].next = l
                    tail[v] = l
                else:
                    head[v] = l
                    tail[v] = l
                l = l.next
        keys = head.keys()
        keys.sort()
        r = ListNode(0)
        temp = r
        for k in keys:
            temp.next = head[k]
            temp = tail[k]
        return r.next    