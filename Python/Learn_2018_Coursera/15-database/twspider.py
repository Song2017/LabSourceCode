from urllib.request import urlopen
import urllib.error
import twurl
import json
import sqlite3
import ssl

# table     row     column
# relation  tuple   attribute
TWITTER_URL = 'https://api.twitter.com/1.1/friends/list.json'
conn = sqlite3.connect('spider.sqlite')
cur = conn.cursor()

cur.execute('''
create table if not exists Twitter
(name TEXT, retrieved INTEGER, friends INTEGER)''')

# ssl
ctx = ssl.create_default_context()
ctx.check_hostname = False
ctx.verify_mode = ssl.CERT_NONE

while True:
    acct = input('Enter a Twitter account, or quit:')
    if acct == 'quit':
        break
    if len(acct) < 1:
        cur.execute('select name from Twitter where retrieved = 0 limit 1')
        try:
            acct = cur.fetchone()[0]
        except:
            print('no twitter account found')
            continue
    url = twurl.argument(TWITTER_URL, {'screen_name': acct, 'count':'5'})
    print('retrieving', url)
    connection = urlopen(url, context=ctx)
    data = connection.read().decode()
    headers = dict(connection.getheaders())

    print('remaing', headers['x-rate-limit-remaining'])
    js = json.loads(data)

    cur.execute('update Twitter set retrieved=1 where name = ?', (acct,))

    countnew = 0
    countold = 0
    for u in js['users']:
        friend = u['screen_name']
        print(friend)
        cur.execute(
            'select friends from twitter where name = ? limit 1', (friend,))

        try:
            count = cur.fetchone()[0]
            cur.execute(
                'update Twitter set friends = ? where name = ?', (count+1, friend))
            countold = countold + 1
        except Exception as e:
            cur.execute(''' insert into Twitter (name, retrieved, friends) values 
                (?, 0, 1)''', (friend,))
            conn.commit()
            if cur.rowcount != 1 :
                print('Error inserting account:',friend)
                continue
    print('new counts=', countnew, 'revisited=', countold)

    conn.commit()

cur.close()
conn.close()
