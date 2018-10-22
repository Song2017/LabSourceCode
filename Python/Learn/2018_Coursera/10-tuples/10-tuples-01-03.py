import string
#print('string.punctuation)',string.punctuation)
from string import digits

fname = input('Enter the file name: ')
try:
    fhand = open(fname)
except:
    print('File cannot be opened:', fname)
    exit()   

#01
def getMostCommits(fhandargs):
    counts = dict()
    lst = list()
    for line in fhandargs:
        if not line.startswith('From'): continue
        words = line.lower().split()
        if len(words) < 2: continue
        counts[words[1]] = counts.get(words[1],0)+1

    for email, count in list(counts.items()):
        lst.append((count,email))
    lst.sort(reverse=True)
    c,e = lst[0] 
    print(e, c)

getMostCommits(fhand)

# 02
def sortHour(fhandargs):
    counts = dict()
    lst = list()
    for line in fhandargs:
        if not line.startswith('From'): continue
        words = line.lower().split()
        if len(words) < 7: continue
        h,m,s = words[5].split(':')   
        counts[h] = counts.get(h,0)+1
    for hour, count in list(counts.items()):
        lst.append((hour,count))
    lst.sort()
    for h,c in lst:
        print(h,c)
sortHour(open('mbox-short.txt'))

# 03
def descLettersFrequency(fhandargs):
    totalNum = 0
    words = dict()
    lst = list()
    for line in fhandargs:
        line = line.strip().lower().translate(str.maketrans('','',string.punctuation))
        line = line.translate(str.maketrans('','',digits))
        line = line.replace(' ','')
        if len(line) < 0 : continue 
        totalNum+=len(line)
        for word in line:
            words[word] = words.get(word,0) +1
    for w,n in words.items():
        lst.append((w,n/totalNum))
    lst.sort()
    for w,f in lst:
        print(w,f)

descLettersFrequency(open('mbox-short.txt'))