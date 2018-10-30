t = 'a', 'b', 'c', 'd', 'e'
print("t = 'a','b','c','d','e', t:", t)
t = ('a', 'b', 'c', 'd', 'e')
print("t = ('a', 'b', 'c', 'd', 'e'), t:", t)

t1 = ('a',)
print("t1 = ('a',), type(t1)", type(t1))
t2 = ('a')
print("t2 = ('a'), type(t2)", type(t2))

t = tuple()
print("t = tuple(), t:", t)
t = tuple('lupins')
print("t = tuple('lupins'), t:", t)
print("t[0]", t[0])
print("t[1:3]", t[1:3])
# t[0] = 'A'  #TypeError: 'tuple' object does not support item assignment
t = ('A',) + t[1:]
print("t = ('A',) + t[1:], t:", t)


# compare
print("(0,1,2) < (0,3,4)",(0,1,2) < (0,3,4))
print("(0,1,2000) < (0,3,4)",(0,1,2000) < (0,3,4))

# DSU sort
txt = 'but soft what light in yonder window breaks'
words = txt.split()
t = list()
for w in words:
    t.append((len(w),w))

t.sort(reverse=True)

tr = list()
for length, w in t:
    tr.append(w)
print("txt = 'but soft what light in yonder window breaks', t.sort(reverse=True)\n",tr)

# asignment
m = ['have','fun']
x,y = m
print("m = ['have','fun'],x,y = m, x,y:",x,',',y)
x,y = y,x
print("x,y = y,x, x,y:",x,',',y)
addr = "monty@python.com"
x,y = addr.split('@')
print("addr = 'monty@python.com', x,y = addr.split('@'), x,y:",x,',',y)
#x,y = 1,2,3 #ValueError: too many values to unpack (expected 2)

# dic
d = {'a':10, 'b':1, 'c':22}
t = list(d.items())
print("d = {'a':10, 'b':1, 'c':22},t = list(d.items), t:",t)
t.sort()
print("t = t.sort(), t:",t)
for (key,value) in d.items():
    print(key,value)
l =list()
for key, value in d.items():
    l.append((value,key))
l.sort(reverse=True)
print('reverse tuple field, sort tuple, l:',l)

# list the most common words
import string
fhand = open('mbox-short.txt')
counts = dict()
for line in fhand:
    line = line.rstrip().lower()
    line = line.translate(str.maketrans('','',string.punctuation))
    for word in line.split():
        counts[word] = counts.get(word,0)+1
lst = list()
for w,length in counts.items():
    lst.append((length,w))
lst.sort(reverse=True)
print(lst[:10])


# use tuples as keys in dictionary
directory = dict()
directory['last', 'first'] = 'number'
for last, fir in directory:
    print("directory['last', 'first'] = 'number', fir,last,directory[last,fir]:", 
        fir,last,directory[last,fir])

# strings, list, tuple, dictionary
# number：int float bool 
# string 'name' 不可变，不可以对其中的字符赋值; 多用list替代 可切片
# list [1, 2, 3] 可变，key必须是数字，可以对其组成元素进行增删改 可切片
# tuple (0, 1, 2) 不可变，常用于return返回的结果，形参，字典键， 可切片
# dict {'name':'zhangsan', 'age':20} 可变，key可以是string等非数字 {}
# set {1,2,3} 元素不可以重复，不能切片， 运算的单位是集合

