import re
hand = open('mbox-short.txt')
for line in hand:
    line = line.rstrip()
    # if line.find('From:', 0) > -1:
    # if re.search('From:', line):
    # if re.search('^F..m:', line):# 以字符串“F..m：” 开头的行 ".":匹配任何字符
    if re.search('^F..m:.+@', line):# ^From:.+@将成功匹配以“From：”开头的行，后跟一个或多个字符（.+），后跟at符号
        print(line)

# Extracting data
s = 'A message from csev@umich.edu to cwen@iupui.edu about meeting @2PM'
rlst = re.findall('\S+@\S+',s) # 至少一个非空白字符的子字符串，后跟一个at符号，后跟至少一个非空白字符
print(rlst)

# email address
hand = open('mbox-short.txt')
for line in hand:
    x = re.findall('[a-zA-Z0-9]\S+@\S+[a-zA-Z]',line.rstrip()) 
    if len(x) > 0:
        print(x)

# X-DSPAM-Confidence: 0.8475
hand = open('mbox-short.txt')
for line in hand:
    line = line.rstrip()
    if re.search('^X-\S*: [0-9.]+', line):#  '*' >= 0; '+' >= 1
        print(line)
# extract number data
hand = open('mbox-short.txt')
for line in hand:
    line = line.rstrip()
    x = re.findall('^X-\S*: ([\d.]+)',line) 
    if len(x) > 0 and float(x[0]) > 0:
        print(x)

# extrate 'Details: http://source.sakaiproject.org/viewsvn/?view=rev&rev=39772' rev
hand = open('mbox-short.txt')
for line in hand:
    line = line.rstrip()
    x = re.findall('^Details: .*&rev=([\d]+)', line)
    if len(x) > 0 :
        print(x)

#　From stephen.marquard@uct.ac.za Sat Jan  5 09:14:16 2008　get hour
hand = open('mbox-short.txt')
for line in hand:
    line = line.rstrip()
    x = re.findall('^From .* ([\d][\d]):', line)
    if len(x) > 0 :
        print(x)

# escape
x = 'We just received $10.00 for cookies.'
y = re.findall('^[\S\s]*\$([\d.]+)', x) # \s: [\f\n\r\t\v] space, tab enter... \S: !\s
print('here is $', y)

'''
^ 匹配行的开头。
$ 匹配线的末尾。
. 匹配任何字符（通配符）。
\s 匹配空白字符。
\S 匹配非空白字符（与\ s相反）。
* 适用于前一个字符，表示匹配零次或多次。
*? 适用于前一个字符，并指示在“非贪婪模式”下匹配零次或多次。
+ 适用于前一个字符并指示匹配一次或多次。
+? 适用于前一个字符，并指示在“非贪婪模式”下匹配一次或多次。
? 适用于前一个字符，表示匹配零次或一次。
?? 适用于前一个字符，表示在“非贪婪模式”下匹配零次或一次。
[aeiou]只要该字符在指定的集合中，就匹配单个字符。在此示例中，它将匹配“a”，“e”，“i”，“o”或“u”，但不匹配其他字符。
[a-z0-9]您可以使用减号指定字符范围。此示例是单个字符，必须是小写字母或数字。
[^A-Za-z]当集合表示法中的第一个字符是插入符号时，它会反转逻辑。此示例匹配单个字符，该字符不是大写或小写字母。
( )将括号添加到正则表达式时，为了匹配，将忽略它们，但允许您在使用时提取匹配字符串的特定子集而不是整个字符串findall()。
\b 匹配空字符串，但仅匹配单词的开头或结尾。
\B 匹配空字符串，但不匹配单词的开头或结尾。
\d匹配任何十进制数字; 相当于集合[0-9]。
\D匹配任何非数字字符; 相当于集[^ 0-9]。
'''

# debug
help(re.search)
help(re.findall)