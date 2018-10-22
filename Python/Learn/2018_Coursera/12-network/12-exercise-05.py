#A socket is much like a file, except that a single socket provides a two-way connection between two programs. 
#You can both read from and write to the same socket. If you write something to a socket, it is sent to the application at the other end of the socket. 
#If you read from the socket, you are given the data which the other application has sent.

#A protocol is a set of precise rules that determine who is to go first, what they are to do, and then what the responses are to that message, and who sends next, and so on. 
#In a sense the two applications at either end of the socket are doing a dance and making sure not to step on each other's toes.

import socket

mysocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
mysocket.connect(('data.pr4e.org', 80))
# 'asdf'.encode() == b'asdf' 字节对象
cmd = 'GET http://data.pr4e.org/romeo.txt HTTP/1.0\r\n\r\n'.encode()
mysocket.send(cmd)
texts = []

while True:
    data = mysocket.recv(521)
    if not data: break
    texts.append(data.decode())

mysocket.close()
texts = "".join(texts)
texts = texts.strip(texts.split('\r\n\r\n')[0])
print(texts)