import re

pattern = input('Enter a regular expression: ')
try:
    count = 0
    hand = open('mbox-short.txt')
    for line in hand:
        if re.search(pattern, line.rstrip()) :
            count += 1
    print('mbox-short.txt had',count, 'lines that matched', pattern)

except Exception as e:
    print(e)

# New Revision: 39742
fname = input('Enter file: ')
try:
    hand = open(fname)
except Exception as e:
    print(e)
count = sumNum = 0.0
for line in hand:
    x = re.findall(r'^[\S]{3} [\S]*: ([\d]{5})',line.rstrip())
    if len(x) > 0:
        sumNum += float(x[0])
        count += 1

if count > 0:
    print(sumNum/count)