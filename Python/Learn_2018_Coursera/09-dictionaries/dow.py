import string

# 02
def countWeek():
    fname = input('Enter the file name: ')
    try:
        fhand = open(fname)
    except:
        print('File cannot be opened:', fname)
        exit()   
    #From stephen.marquard@uct.ac.za Sat Jan  5 09:14:16 2008

    counts = dict()
    for line in fhand:
        if not line.startswith('From') : continue
        line = line.rstrip()
        #line = line.translate(line.maketrans('','',string.punctuation))
        words = line.split()
        if len(words) > 2: 
            w = words[2]
            counts[w] = counts.get(w,0)+1
    print(counts)

def countEmailFromAdress(fhandarg):
    counts = dict()
    for line in fhandarg:
        if not line.startswith('From:') : continue
        line = line.rstrip()
        #line = line.translate(line.maketrans('','',string.punctuation))
        words = line.split()
        if len(words) > 1: 
            w = words[1]
            counts[w] = counts.get(w,0) + 1
    return counts

# 04 
def maxEmailFromAdress(fhandarg):
    counts = countEmailFromAdress(fhandarg) 
    maxVal = 0
    for num in counts.values():
        if not num is None and num > maxVal:
            maxVal = num
    for name in counts.keys():
        if counts[name] == maxVal:
            print('maxEmailFromAdress: ',name, maxVal) 

# 05
def countDomain(fhandarg):
    domains = dict()
    for line in fhandarg:
        if not line.startswith('From'): continue
        words = line.rstrip().split()
        if len(words) > 2:
            domain = words[1].split('@')[1]
            domain = domain.translate(domain.maketrans('','',string.punctuation))
            domains[domain] = domains.get(domain,0)+1
    return domains    

#countWeek(fhand)
fhand = open("mbox.txt")
print(countEmailFromAdress(fhand))
fhand = open("mbox.txt")
maxEmailFromAdress(fhand)
fhand = open("mbox.txt")
print(countDomain(fhand))
