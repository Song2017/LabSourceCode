import urllib.request
import urllib.parse
import urllib.error
from bs4 import BeautifulSoup
import ssl

# install bs4: pip install bs4
# https://pypi.python.org/pypi/beautifulsoup4
# http://www.py4e.com/code3/bs4.zip
# and unzip it in the same directory as this file

# ignore ssl cert error
ctx = ssl.create_default_context()
ctx.check_hostname = False
#ctx.verify_mode = ssl.CERT_NONE

url = input('Enter - ')
html = urllib.request.urlopen(url, context=ctx).read()
soup = BeautifulSoup(html, 'html.parser')

# retrieve all anchor tags
tags = soup('a')
for tag in tags:
    print('TAG:', tag)
    print('URL:', tag.get('href', None))
    print('Contents:', tag.contents[0].encode())
    print('Attrs:', tag.attrs)
