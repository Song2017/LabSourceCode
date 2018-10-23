import urllib.request, urllib.parse, urllib.error
import re
import ssl


try:
    url = input('Enter - ')  # http://data.pr4e.org/romeo.txt
    size = 0
    ctx = ssl.create_default_context()
    ctx.check_hostname =False

    fhand = urllib.request.urlopen(url).read()
    for w in fhand:
        size += 1 

    print(fhand.decode()[:3000], end='')
    print('\nrecv size: ',size)
except Exception as e:
    print('please input correct url', e)
