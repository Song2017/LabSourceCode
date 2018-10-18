def reverse(words):
    index = len(words) - 1 
    reverseword = ''
    while index >= 0 :
        reverseword = reverseword + words[index]
        index = index -1
    print(reverseword)
reverse('index')

s = 'Monty Python'
print('s[:]', s[:])
print('s[0:5]', s[0:5])
print('s[6:12]', s[6:12])
print('s[:5]', s[:5])
print('s[6:]', s[6:])
print('s[-1]', s[-1])
print('"o" in s', 'o' in s)

print('type(s)', type(s))
#print('dir(s)', dir(s))

print('s.upper() s, ',s.upper(),s)
print('s.find("ty"),',s.find('ty'))
print('s.strip("M"),',s.strip('M'))
print('s.startswith("Monty"),',s.startswith('Monty'))
print('s.lower().startswith("m"),',s.lower().startswith('m'))


def countString(a, strs):
    try:
        cnt = 0
        for word in strs:
            if word == a:
                cnt = cnt + 1
        return cnt
    except Exception as e:
        print('error a in strs', a, strs, e)

print("countString('a', 'banana')",countString('a', 'banana'))

#该格式操作，%使我们能够构建字符串，替换存储在变量的数据串的部分。
#当应用于整数时，%是模数运算符。但是当第一个操作数是字符串时，%是格式运算符
print('in %d years i have spotted %g %s' % (1, 0.1, 'books everyday') )