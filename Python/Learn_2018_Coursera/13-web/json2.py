import json

data = '''
[
  { "id" : "001",
    "x" : "2",
    "name" : "Chuck"
  } ,
  { "id" : "009",
    "x" : "7",
    "name" : "Brent"
  }
]
'''

info = json.loads(data)
print(type(info))
print('User count:', len(info))

for item in info:
    print("name",item['name'])
    print("x",item['x'])
    print("id",item['id'])
