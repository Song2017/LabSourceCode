#!/usr/bin/python3
import psycopg2
import psycopg2.extras
import sys

def main():
	conn_string = "host='104.209.45.95' dbname='postgres' user='postgres' password='PDQ5gmadmgQC'"
	# print database connect string
	print("connect to database\n-> %s" % conn_string)
	
	conn = psycopg2.connect(conn_string)
	# server-side cursor, which prevent all of the records from being downlaod at once from server
	cursor = conn.cursor('cursor_unique_name', cursor_factory=psycopg2.extras.DictCursor)
	cursor.execute('select * from book limit 1000')
	
	row_count = 0
	for row in cursor:
		row_count += 1
		print("row: %s %s\n" % (row_count,row))

if __name__ == "__main__":
	main()
	