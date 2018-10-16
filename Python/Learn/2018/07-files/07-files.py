'''
stuff = 'X\nY'
print("stuff[:] 'X\\nY'", stuff[:])
print("stuff", stuff)
print("len(stuff)", len(stuff))

#fhand = open('mboxnoexists.txt')
# print(fhand)
fhand = open('mbox.txt')
print(fhand)
count = 0
for line in fhand:
    count = count + 1
print('mbox.txt line count: %d' % count)

# read all data to memory
# fhand is at last line once it's last line was used
fhand = open('mbox.txt')
inp = fhand.read()
print(len(inp))
print(inp[:58])

# find file
fhand = open('mbox.txt')
for line in fhand:
    # if line.startswith('From'):
    if not line.startswith('From'):
        continue
    print(line.rstrip())

fhand = open('mbox.txt')
for line in fhand:
    line = line.rstrip()     
    if line.find('@uct.ac.za') == -1 :continue
    print(line)


# read 
fname = input('please input your file name:')
try :
    fhand = open(str(fname))
except:
    print('please check file name')
    exit()
count = 0
for line in fhand :
    if line.startswith('Subject'):
        count = count + 1
print('There were', count, 'subject lines in', fname)    
'''

# write
fout = open('output.txt','w')
print(fout)
line1 = "this here's the wattle, \n"
fout.write(line1)
fout.write("the emblem of our land. \n")
fout.close()


s = '1 2\t 3\n 4'
print('repr(s)', repr(s))
print('s',s)