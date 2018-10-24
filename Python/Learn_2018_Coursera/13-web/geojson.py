import urllib.request, urllib.parse, urllib.error
import json

# Note that Google is increasingly requiring keys for this API
# quota only 1, change to baidu map
# serviceurl = 'https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyD_S1RtMm4iUCTEngdZIpqucqe4xD9_CCY&'
serviceurl = 'http://api.map.baidu.com/place/v2/search?output=json&ak=oNKbXOrfDFpUDWPuqdHpDFeHWeDMS4EK&'

while True:
    address = input('Enter location:')
    if len(address) < 1 : break
    region = input('Enter region:')
    if len(region) < 1 : break
    url = serviceurl + urllib.parse.urlencode({'query':address})
    url = url + '&' +urllib.parse.urlencode({'region':region})

    print('retrieve URL:', url)
    uh = urllib.request.urlopen(url)
    data = uh.read().decode()
    print('retrieved:', len(data), 'characters')

    try:
        js = json.loads(data)
    except Exception as e:
        js = None
    
    # google if not js or 'status' not in js or js['status'] != 'OK':
    if not js or 'message' not in js or js['message'].upper() != 'OK':
        print('==== Failure To Retrieve ====')
        print(data)
        continue
    
    # handle locations that are not in any country 
    if not js['results'] or len(js['results']) < 0:
        continue

    #print(js['results'][0])
    print(json.dumps(js,indent=4))

    lat = js['results'][0]['location']['lat']
    lng = js['results'][0]['location']['lng']
    print('lat',lat, 'lng',lng)
    location = js['results'][0]['address']
    print('location',location)

    for r in js['results']:
        if len(r['name']) == 2:
            print(r['name'])