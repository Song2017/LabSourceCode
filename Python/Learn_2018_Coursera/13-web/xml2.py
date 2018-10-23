import xml.etree.ElementTree as ET
# file name xml2.py cannot name 'xml',otherwises, there is a name conflict with module xml 


data = '''
<person>
  <name>Chuck</name>
  <phone type="intl">
    +1 734 303 4456
  </phone>
  <email hide="yes" />
</person>'''
tree = ET.fromstring(data)
#print('root:', tree.find('person').text) #AttributeError: 'NoneType' object has no attribute 'text'
print('Name:', tree.find('name').text)
print('Attr:', tree.find('email').get('hide'))

# xml2
data2 = '''
<stuff>
  <users>
    <user x="2">
      <id>001</id>
      <name>Chuck</name>
    </user>
    <user x="7">
      <id>009</id>
      <name>Brent</name>
    </user>
  </users>
</stuff>'''
stuff = ET.fromstring(data2)
lst = stuff.findall('users/user')
print('User count:', len(lst))

for item in lst:
    print('Name:', item.find('name').text)
    print('Id:', item.find('id').text)
    print('Attr:', item.get('x'))

# findall 只能查找直接子级元素
stuff = ET.fromstring(data2)
lst = stuff.findall('users/user')
print('User count:', len(lst))

lst2 = stuff.findall('user')
print('User count:', len(lst2))