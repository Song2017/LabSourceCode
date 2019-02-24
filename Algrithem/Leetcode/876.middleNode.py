# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution:
    def middleNode1(self, head: 'ListNode') -> 'ListNode':
        '''
        给定一个带有头结点 head 的非空单链表，返回链表的中间结点。
        如果有两个中间结点，则返回第二个中间结点
        '''
        lists = [] 
        while head:
            lists.append(head.val)
            head = head.next 
        rtn = lst = ListNode(-1)
        for i in lists[len(lists)//2:]:
            lst.next = ListNode(i)
            lst = lst.next
        return rtn.next
    
    def middleNode(self, head: 'ListNode') -> 'ListNode':
        length = 0 
        rtn = head
        while head:
            length += 1
            head = head.next
        
        index = 0        
        while rtn:
            if index == length //2: break
            index += 1
            rtn = rtn.next
        return rtn
         