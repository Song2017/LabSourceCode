#!/usr/bin/python3
# check prime number

num = int(input('enter a number : '))

floor = int(num//2 + 1)

if num <= 1:
    print('prime num is greater than 1')
else:
    for i in range(2, floor):
        if (num % i) == 0:
            print(num, "is not a prime number")
            print(i, " times ", num/i, " is ", num)
            break
        else:
            print(num, " is a prime number")
