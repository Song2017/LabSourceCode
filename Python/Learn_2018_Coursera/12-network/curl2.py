import urllib.request, urllib.parse, urllib.error

# urllib handles all of the HTTP protocol and header details.
fhand = urllib.request.urlopen('http://data.pr4e.org/romeo.txt')
for line in fhand:
    print(line.decode().strip())

# urlib: regard url page as file
fhand = urllib.request.urlopen('http://data.pr4e.org/romeo.txt')
counts = dict()
for line in fhand:
    words = line.decode().strip().split()
    for word in words:
        counts[word] = counts.get(word,0) + 1
print(counts)

# Reading binary files using urllib
img = urllib.request.urlopen('http://data.pr4e.org/cover3.jpg').read()
fhand = open('cover3.jpg', 'wb')
fhand.write(img)
fhand.close()
# retrive large file via block
img = urllib.request.urlopen('http://data.pr4e.org/cover3.jpg')
fhand = open('cover31.jpg', 'wb')
size= 0
while True:
    info = img.read(100000)
    if len(info) < 1 : break
    size = size + len(info)
    fhand.write(info)
fhand.close()
print(size, 'copy done.')