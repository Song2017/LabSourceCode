import urllib.request, urllib.parse, urllib.error
from bs4 import BeautifulSoup
import ssl

#install bs4: pip install bs4
# https://pypi.python.org/pypi/beautifulsoup4
# http://www.py4e.com/code3/bs4.zip
# and unzip it in the same directory as this file

# ignore ssl cert error
ctx = ssl.create_default_context()
ctx.check_hostname = False
ctx.verify_mode = ssl.CERT_NONE

url = input('Enter - ')
html = urllib.request.urlopen(url).read()
soup = BeautifulSoup(html, 'html.parser')

#retrieve all anchor tags
size = 0
tags = soup('p')
for tag in tags:
    size += 1
print('count <p>:', size)