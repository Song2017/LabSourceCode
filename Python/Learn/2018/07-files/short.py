fname = input('Enter a file name:')
try:
    fhand = open(fname)
    for line in fhand:
        line = line.rstrip()
        print(line.upper())
except:
    print('please check name: output.txt')

#02
fname = input('Enter a file name:')
count = sum = 0
try:
    fhand = open(fname)
    for line in fhand:
        if line.find('X-DSPAM-Confidence:') == -1 : continue
        count = count + 1
        sum += float(line.split(':')[1].strip())
    print('Average spam confidence:', sum/count, 'sum:', sum, 'count:', count)
except Exception as e:
    print('please check name: mbox.txt')

# 03 egg.py
fname = input('Enter a file name:')
cnt = 0
try:
    fhand = open(fname)
    for line in fhand:
        count = count + 1
    print('There were %d subject lines in mbox.txt' % count)
except Exception as e:
    if(fname.lower() == 'na na boo boo'):
        print("NA NA BOO BOO TO YOU - You have been punk'd!")
    else :
        print('File cannot be opened:', fname)
