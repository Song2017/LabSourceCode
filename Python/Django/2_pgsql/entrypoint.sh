#!/bin/bash
log(){
	while read line ; do
		echo "`date '+%D %T'` $line"
	done
}

set -e
logfile=/home/LogFiles/entrypoint.log
test ! -f $logfile && mkdir -p /home/LogFiles && touch $logfile
exec > >(log | tee -ai $logfile)
exec 2>&1

set_var_if_null(){
	local varname="$1"
	if [ ! "${!varname:-}" ]; then
		export "$varname"="$2"
	fi
}

# Set password
set_var_if_null "DJANGO_HOST" "40.74.243.74"
set_var_if_null "DJANGO_DB_NAME" "django"
set_var_if_null "DJANGO_DB_USERNAME" "django"
set_var_if_null "DJANGO_DB_PASSWORD" "password"
set_var_if_null "DJANGO_ADMIN_PASSWORD" "password"

echo "INFO: DJANGO_HOST:" $DJANGO_HOST
echo "INFO: DJANGO_DB_NAME:" $DJANGO_DB_NAME
echo "INFO: DJANGO_DB_USERNAME:" $DJANGO_DB_USERNAME 

# Init postgresql
setup_postgresql(){
	test ! -d "$POSTGRESQL_DATA_DIR" && echo "INFO: $POSTGRESQL_DATA_DIR not found. creating ..." && mkdir -p "$POSTGRESQL_DATA_DIR"
	chown -R postgres:postgres $POSTGRESQL_DATA_DIR
	ln -s /var/lib/postgresql/9.5/main $POSTGRESQL_DATA_DIR
	test ! -d "$POSTGRESQL_LOG_DIR" && echo "INFO: $POSTGRESQL_LOG_DIR not found. creating ..." && mkdir -p "$POSTGRESQL_LOG_DIR"
	chown -R postgres:postgres $POSTGRESQL_LOG_DIR
	
	#set postgresql log
	sed -i "s|\#logging_collector|logging_collector|g" /etc/postgresql/9.5/main/postgresql.conf
	sed -i "s|\#logging_directory = \'pg\_log\'|logging_directory = \'var\/log\/postgresql\'|g" /etc/postgresql/9.5/main/postgresql.conf 
	sed -i "s|\#logging_filename|logging_filename|g" /etc/postgresql/9.5/main/postgresql.conf

	# start postgresql
	echo 'service postgresql start'
	service postgresql start & sleep 2s

	#Init postgres
	sed -i "s|dbdjango|$DJANGO_DB_NAME|g" $POSTGRESQL_SOURCE/init.sql	
	sed -i "s|dbuserdjango|$DJANGO_DB_USERNAME|g" $POSTGRESQL_SOURCE/init.sql
	sed -i "s|password|$DJANGO_DB_PASSWORD|g" $POSTGRESQL_SOURCE/init.sql
	su - postgres -c "psql -f $POSTGRESQL_SOURCE/init.sql"

}

#start phppgadmin
setup_phppgadmin(){		
	chown -R www-data:www-data /usr/share/phppgadmin
}

setup_nginx(){
	test ! -d "$NGINX_LOG_DIR" && echo "INFO: $NGINX_LOG_DIR not found. creating ..." && mkdir -p $NGINX_LOG_DIR
	chown -R www-data:www-data $NGINX_LOG_DIR
	test ! -d "$NGINX_DATA_DIR" && echo "INFO: $NGINX_DATA_DIR not found. creating ..." && mkdir -p $NGINX_DATA_DIR
	#ln -s /etc/nginx $NGINX_DATA_DIR 
	
}

setup_uwsgi(){
	echo "INFO: creating /tmp/uwsgi.sock ..."
	rm -f /tmp/uwsgi.sock
	touch /tmp/uwsgi.sock
	chown www-data:www-data /tmp/uwsgi.sock
	chmod 664 /tmp/uwsgi.sock
}

test ! -d "$DJANGO_HOME" && echo "INFO: $DJANGO_HOME not found, creating ..." && mkdir -p $DJANGO_HOME

setup_postgresql
setup_phppgadmin
setup_nginx
setup_uwsgi

# Start all the services
echo "Starting SSH ..."
service ssh start

echo "INFO: starting php7.0-fpm ..."
service php7.0-fpm start

echo "INFO: starting nginx ..."
#echo "daemon off;" >> /etc/nginx/nginx.conf
nginx -t
service nginx start

echo "INFO: starting uwsgi ..."
if [ -e "/etc/nginx/uwsgi/uwsgi.ini" ]; then 
	echo "INFO: /etc/nginx/uwsgi/uwsgi.ini exists ..."
fi

echo "INFO: starting uwsgi2 ..."
uwsgi --uid=www-data --gid=www-data --ini=/etc/nginx/uwsgi/uwsgi.ini
echo "INFO: ending ..."
#/usr/bin/supervisord -n
