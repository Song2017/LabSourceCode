cheeses = ['cheddar', 'Edam', 'Gouda']
numbers = [17, 12]
empty = []
mixs = ['cheddar', "double quote", 17, [], ['a', 'b']]
print('cheeses,numbers,empty,mixs:', cheeses, numbers, empty, mixs)
print('cheeses[0]', cheeses[0])

numbers[0] = 55
print('numbers[0] = 55, numbers:', numbers)
print("'Edam' in cheeses", 'Edam' in cheeses)

# iteration lists
for item in cheeses:
    print(item)
for i in range(len(numbers)):
    numbers[i] = numbers[i]*2
print('numbers[:]', numbers[:])

# operation
a = [1, 2, 3]
b = [4, 5, 6]
c = a + b + a
print('a,b:', a, b)
print('c = a + b, c:', c)
print('a * 3:', a*3)

print('c[:]', c[:])
print('c[0:2]', c[0:2])
print('c[2:4]', c[2:4])
print('c[:5]', c[:5])
print('c[3:]', c[3:])
print('c[-1]', c[-1])

# add
a.append(['append'])
print("a.append(['append']); a", a)

a.extend('extend')
print("a.extend('extend')", a)
c.sort()
print('c.sort()', c)

# delete
x = b.pop(1)
print('x = b.pop(1), b,x:', b, x)
x = b.pop()
print('x = b.pop(), b,x:', b, x)
del c[1]
print('del c[1], c:', c)
c.remove(2)
print('c.remove(2), c:', c)
del c[2:4]
print('del c[2:4], c:', c)

# function
nums = [3, 41, 12, 9, 74, 15]
print('nums[:]', nums[:])
print('len(nums)', len(nums))
print('max(nums)', max(nums))
print('min(nums)', min(nums))
print('sum(nums)', sum(nums))
print('sum(nums)/len(nums)', sum(nums)/len(nums))

'''
numlist = list()
while(True):
    inp = input('enter a number: ')
    if inp == 'done' : break
    value = float(inp)
    numlist.append(value)
print('sum(numlist) / len(numlist) :', sum(numlist) / len(numlist))
'''

s = 'pining for the fjords'
t = s.split()
print("'pining for the fjords'.split()", t)
print('t[2]', t[2])
print("'-'.join(t)", '-'.join(t))

a = 'banana'
b = "banana"
print("'banana' is \"banana\"", a is b)
a = [1, 2, 3]
b = [1, 2, 3]
print("[1,2,3] is [1,2,3]", a is b)
a = [1, 2, 3]
b = a
print("b = a, a is b", a is b)
b[2] = 20
print("b[2]=20, a:", a)

'''
debug
list function 多会返回None
t = t.sort()           # WRONG! t：None
'''