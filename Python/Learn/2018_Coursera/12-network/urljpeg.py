import socket
import time

HOST = 'data.pr4e.org'
PORT = 80
mysock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
mysock.connect((HOST,PORT))
mysock.sendall('GET http://data.pr4e.org/cover3.jpg HTTP/1.0\r\n\r\n'.encode())
count = 0
picture = ''.encode()

while True:
    data = mysock.recv(5120)
    if len(data) < 1 : break
    time.sleep(0.2)
    count += len(data)
    print(len(data), count)
    picture = picture + data

mysock.close()

# look for the end if the header
pos = picture.find('\r\n\r\n'.encode())
print('header length', pos)
print(picture[:pos].decode())

#skip header and save pic
picture = picture[pos+4:]
fhand = open('stuff.jpg','wb')
fhand.write(picture)
fhand.close()