import urllib.request, urllib.parse, urllib.error
import json

# Note that Google is increasingly requiring keys
# for this API
serviceurl = 'https://maps.googleapis.com/maps/api/geocode/json?key=key=AIzaSyD_S1RtMm4iUCTEngdZIpqucqe4xD9_CCY&'

while True:
    address = input('Enter location:')
    if len(address) < 1 : break

