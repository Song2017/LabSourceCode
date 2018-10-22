import socket
import re

try:
    url = input('Enter - ')  # http://data.pr4e.org/romeo.txt
    HOST = re.findall(r'http[s]?://([\S\d.]*)/.*?', url)
    mysock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    mysock.connect((HOST[0], 80))
    cmd = 'GET ' + url + ' HTTP/1.0\r\n\r\n'
    cmd = cmd.encode()
    mysock.send(cmd)

    while True:
        data = mysock.recv(512)
        if len(data) < 1:
            break
        print(data.decode(), end='')

    mysock.close()
except Exception as e:
    print('please input correct url', e)
