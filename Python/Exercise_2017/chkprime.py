#!/usr/bin/python3
# check prime number

def checkprime(num):
	floor = int(num/2 + 1)
	rtn = ''
	if num <= 1:
		print('prime num should be greater than 1')
	else:
		for i in range(2, floor):
			if (num % i) == 0:
				print(num, "is not a prime number")
				rtn = "{0} times {1} is {2}".format(i,num/i,num)
				break
	if num > 1 and len(rtn) < 1 :
		print(num, 'is a prime')
