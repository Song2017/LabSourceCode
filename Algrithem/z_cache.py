from collections import deque
# collections.deque is a collection, while Queue.Queue is a communications mechanism.
circular_queue = deque([1, 2], maxlen=4)
circular_queue.append(3)
circular_queue.extend([4])

# at this point you have [1,2,3,4]
print(circular_queue.popleft())  # --> 1 
print(circular_queue.pop())  #  --> 4

# key step. effectively rotate the pointer
# circular_queue.rotate(-1)  # negative to the left. positive to the right
print(circular_queue[-1])  # 3
print(circular_queue[0])
print(circular_queue)
