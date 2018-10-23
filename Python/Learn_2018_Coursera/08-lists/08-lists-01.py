def chop(inargs):
    if(len(inargs)<2):
        print('check input lists.')
    else:
        inargs.pop(0)
        inargs.pop()
    return None
t = [1,11,21,23.4,44,'test','44',54,'54']
print('chop(t)',chop(t))
print(t)
def middle(inargs):
    if(len(inargs)<2):
        print('check input lists.')
    else:
        t = inargs[1:len(inargs)-1]
    return t
print('middle(t)',middle(t))
print(t)

# 02 03 
fhand = open('mbox.txt')
count = 0
for line in fhand:
    words = line.split()
    # print 'Debug:', words
    if len(words) == 0 or words[0] != 'From' : continue
    if len(words) >= 2:    
        print(words[2])

# 04
print('Enter file: romeo.txt')
words = list()
fhand = open('romeo.txt')
for line in fhand:
    lts = line.split()
    if len(lts) <=0 : continue
    for  lt in lts:
        if not lt in words:
            words.append(lt)
words.sort()
print(words)

# 05
print('Enter a file name: mbox.txt')
count = 0
words = list()
fhand = open('mbox.txt')
for line in fhand:
    if not line.startswith('From') : continue
    count = count + 1
    lts = line.split()
    if len(lts) <= 2 : continue
    print(lts[1])
print('There were %d lines in the file with From as the first word' % count)

# 06
nums = list()
while (True):
    inp = input('Enter a number: ')
    try :
        if inp == 'done' : break
        nums.append(float(inp))
    except:
        pass
print('Maximum: ', max(nums))
print('Minimum: ', min(nums))




