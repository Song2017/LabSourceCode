str = 'X-DSPAM-Confidence: 0.8475 '
#find
print('str[:]',str[:])
posIndex = str.find(':')
print("str.find(':')",str.find(':'))
print("float(str[str.find(':')+1:].strip())",float(str[str.find(':')+1:].strip()))

print("float(str[str.find(':')+1:].replace(' ', ''))",
        float(str[str.find(':')+1:].replace(' ', '')))
#Split
print("float(str.split(':')[1].strip())",float(str.split(':')[1].strip()))
