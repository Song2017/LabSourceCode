# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution:
    def reverseListWhile(self, head):
        '''
        反转一个单链表。
        示例:
        输入: 1->2->3->4->5->NULL
        输出: 5->4->3->2->1->NULL

        遍历输入链表的每个节点, 
        1. 暂存当前结点的下一结点的内存地址, 
        2. 输入链表中的当前结点指向已反转的链表的首结点地址
        3. 这里有点绕, 
            因为第一步已经缓存了输入链表的下一个结点, 
            所以可以把当前结点独立出输入链表, 
            经过第二步的赋值, 此时是已反转链表的首结点
            只需要把已反转链表更新为输入链表的当前结点
        4. 当前结点已经反转了, 将第一步中缓存的下一结点地址更新为当前结点
        
        '''
        rev = None
        p = head
        while p:
            tmp = p.next 
            #1, 2+1, 3+2->1
            p.next = rev
            rev = p
            p = tmp 
        return rev
    def reverseListRecur(self, head, prev=None):
        if not head:
            return prev
        nextnode = head.next
        head.next = prev
        return self.reverseListRecur(nextnode, head)
    def reverseList(self, head):
        rev = None
        p = head
        while p:
            #多元赋值的时候，右边的值不会随着赋值而改变
            rev, rev.next, p = p, rev, p.next
        return rev
        