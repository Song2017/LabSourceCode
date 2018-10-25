stuff = list()
stuff.append('python')
stuff.append('chuck')
stuff.sort()
print(stuff.__getitem__(0))
print(list.__getitem__(stuff,0))

#dir()函数的输出来查看对象的功能
print(dir(stuff))



# just sample Input >program >Output
usf = input('Enter the US Floor Number: ')
wf = int(usf) - 1
print('Non-US Floor Number is',wf)



