import sqlite3


conn = sqlite3.connect('music.sqlite')
cur = conn.cursor()

# create table
# cur.execute('drop table if exists Tracks')
# cur.execute('create table Tracks(title TEXT, plays INTEGER)')

# insert records
cur.execute('insert into Tracks (title, plays) values (?, ?)',
('Thunderstruck', 20))
cur.execute('insert into Tracks (title, plays) values (?, ?)',
('My Way', 15))
conn.commit()

# select 
print('Tracks:')
print('cur', cur, 'type(cur)',type(cur))
cur.execute('select title, plays from Tracks')
for row in cur:
    print(row)
print('cur', cur, 'type(cur)',type(cur))

# delete
cur.execute('delete from Tracks where plays < 0')
print('cur', cur, 'type(cur)',type(cur))
conn.commit() 

cur.close()

conn.close()

 