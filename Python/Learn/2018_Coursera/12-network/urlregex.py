import urllib.request, urllib.parse, urllib.error
import re
import ssl

# ignore ssl certificatate errors
ctx = ssl.create_default_context()
ctx.check_hostname = False
#ctx.verify_mode = ssl.CERT_NONE

url = input('Enter - ')
html = urllib.request.urlopen(url).read()
links = re.findall('href="(http[s]?://.*?)"'.encode(), html)
for link in links:
    print(link.decode())
