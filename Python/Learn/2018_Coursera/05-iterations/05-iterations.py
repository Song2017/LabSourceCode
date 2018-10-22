

n=5
while n > 0:
    print(n)
    n=n-1
print('blastoff')


'''
while True:
    line = input('> ')
    if line[0] == '#':
        continue    
    if line == 'done':
        break
    print(line)
print('Done!')
'''

friends = ['amy','blank','cally']
for friend in friends:
    print('happy new year: ', friend)
print('Done!')

largest = None
print('Before:', largest)
for val in [3,41,12,9,74,15]:
    if largest is None or val > largest:
        largest = val
    print('loop:',val,  largest)
print('After:', largest)


def min(values):
    smallest = None
    for value in values:
        if smallest is None or value < smallest:
            smallest = value
    return smallest

print('smallest value is: ',min([3,41,12,9,74,15]))