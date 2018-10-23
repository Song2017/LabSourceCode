eng2sp = dict()
print('eng2sp = dict(), eng2sp:', eng2sp)
eng2sp['one'] = 'uno'
print("eng2sp['one'] = 'uno'", eng2sp)
eng2sp = {'one':'uno', 'two':'dos', 'three':'tres'}
print("eng2sp = {'one':'uno', 'two':'dos', 'three':'tres'}", eng2sp)
print("eng2sp['two']",eng2sp['two'])
#print("eng2sp['four']",eng2sp['four']) #KeyError: 'four'
print("len(eng2sp)", len(eng2sp))
print("'one' in eng2sp",'one' in eng2sp)
print("'uno' in eng2sp",'uno' in eng2sp)
print("'uno' in eng2sp.values()",'uno' in eng2sp.values())

# 01
words = dict()
fhand = open('words.txt')
for line in fhand:
    if len(line) <= 0 : continue
    lists = line.strip().split()
    for lst in lists:
        #words[lst] = words.get(lst, 0) + 1 
        if not lst in words:
            words[lst] = 1
        else :
            words[lst] += 1
print(words)

# get
word = 'brontosaurus'
d = dict()
for c in word:
    d[c] = d.get(c,0) + 1
print(d)

# iteration
counts = {'chuck':1 , 'annie':42, 'jan':100}
for key in counts:
    if counts[key] > 10:
        print(key, counts[key])
lst = list(counts.keys())
print(lst)
lst.sort()
for key in lst:
    print(key, counts[key])

# advanced
import string
#print('string.punctuation)',string.punctuation)
fname = input('Enter the file name: ')
try:
    fhand = open(fname)
except:
    print('File cannot be opened:', fname)
    exit()   

counts = dict()
for line in fhand:
    line = line.rstrip()
    line = line.translate(line.maketrans('','',string.punctuation))
    words = line.lower().split()
    for w in words:
        counts[w] = counts.get(w,0)+1
print(counts)