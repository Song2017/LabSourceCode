# Definition for singly-linked list.
# class ListNode(object):
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution(object):
    def hasCycle(self, head):
        """
        :type head: ListNode
        :rtype: bool
        如果列表中不存在环，最终快指针将会最先到达尾部，此时我们可以返回 False。

        现在考虑一个环形链表，把慢指针和快指针想象成两个在环形赛道上跑步的运动员。
        而快的最终一定会追上慢的
        时间复杂度O(n), 空间复杂度为操作原始链表为常数级别
        """
        if head == None or head.next == None : 
            return False
        slow = head
        fast = head.next
        while slow != fast:
            if fast == None or fast.next == None:
                return False
            slow = slow.next
            fast = fast.next.next
            
        return True
    class Solution(object):
    def hasCycleFast(self, head):
        """
        :type head: ListNode
        :rtype: bool
        """
        slow=fast=head
        while slow and fast:
            try:
                slow=slow.next
                fast=fast.next.next
            except:
                return False
            if slow==fast:
                return True
        return False

def stringToListNode(input):
    # Generate list from the input
    numbers = json.loads(input)

    # Now convert that list into linked list
    dummyRoot = ListNode(0)
    ptr = dummyRoot
    for number in numbers:
        ptr.next = ListNode(number)
        ptr = ptr.next

    ptr = dummyRoot.next
    return ptr

def stringToInt(input):
    return int(input)

def main():
    import sys
    def readlines():
        for line in sys.stdin:
            yield line.strip('\n')
    lines = readlines()
    while True:
        try:
            line = lines.next()
            head = stringToListNode(line)
            line = lines.next()
            pos = stringToInt(line)
            
            ret = Solution().hasCycle(head, pos)

            out = (ret)
            print out
        except StopIteration:
            break

if __name__ == '__main__':
    main()