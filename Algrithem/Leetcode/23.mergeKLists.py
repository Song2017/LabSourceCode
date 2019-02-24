# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None


class Solution(object):
    def mergeKLists(self, lists):
        """
        :type lists: List[ListNode]
        :rtype: ListNode
        使用分治思想, K个list的整体排序递归分解为两两List的有序
        """
        if len(lists) == 0:
            return None
        if len(lists) == 1:
            return lists[0]

        left = self.mergeKLists(lists[:len(lists)//2])
        right = self.mergeKLists(lists[len(lists)//2:])

        return self.mergeTwoLists(left, right)

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

    def mergeKListsFast(self, lists):
        """
        :type lists: List[ListNode]
        [[1,4,5],[1,3,4],[2,6]]
        :rtype: ListNode
        """
        if len(lists) == 0:
            return None
        if len(lists) == 1:
            return lists[0]
        head = {}
        tail = {}
        for l in lists:
            # 链表中还有数据元素
            while(l):
                v = l.val
                # hash表建立x轴联系, 键值是链表值去重后的结果, 存储值是链表
                # head用来获取链表值去重后的结果
                # tail用来关联所有的链表值, 下面是tail的数据结构
                #     1 2 3 4 5 10
                #     |   |
                #     1   3
                if v in head:
                    tail[v].next = l
                    tail[v] = l
                else:
                    head[v] = l
                    tail[v] = l
                l = l.next
        keys = list(head.keys())
        keys.sort()
        r = ListNode(0)
        temp = r
        for k in keys:
            temp.next = head[k]
            temp = tail[k]
        return r.next

    def mergeKListsArray(self, lists):
        """
        :type lists: List[ListNode]
        :rtype: ListNode
        获取所有值转为列表, 进行排序, 然后重新返回新的链表
        空间复杂度O(n*m)
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


head = ListNode(1)  # 测试代码
p1 = ListNode(2)
p2 = ListNode(3)
p3 = ListNode(4)
head.next = p1
p1.next = p2
p2.next = p3
head2 = ListNode(1)  # 测试代码
p12 = ListNode(5)
head2.next = p12
head3 = ListNode(3)  # 测试代码
p13 = ListNode(10)
head3.next = p13

s = Solution()
result = s.mergeKLists([head, head2, head3])
while result:
    print(11, result.val)
    result = result.next
