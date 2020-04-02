#
# Dockerfile for Django
#
FROM ubuntu:16.04
MAINTAINER Azure App Service Container Images <appsvc-images@microsoft.com>

#
ENV DOCKER_BUILD_HOME "/dockerbuild"
WORKDIR $DOCKER_BUILD_HOME

# nginx
ENV NGINX_LOG_DIR "/home/LogFiles/nginx"
ENV NGINX_DATA_DIR "/home/data/nginx"
RUN set -ex \
	&& apt-get update \
	&& apt-get install -y -V --no-install-recommends nginx \
	&& rm -r /var/lib/apt/lists/*


# postgresql
ENV POSTGRESQL_DATA_DIR "/home/data/postgresql"
ENV POSTGRESQL_LOG_DIR "/home/LogFiles/postgresql"
ENV POSTGRESQL_SOURCE "/usr/local/postgresql"
RUN set -ex \
	&& mkdir -p $POSTGRESQL_SOURCE \
	&& apt-get update \
	&& apt-get install -y -V --no-install-recommends postgresql  \
	&& rm -r /var/lib/apt/lists/*

# phppgadmin
RUN set -ex \
	&& apt-get update \
	&& apt-get install -y -V --no-install-recommends phppgadmin php7.0-fpm \
	&& rm -r /var/lib/apt/lists/*

# python
RUN set -ex \
	&& apt-get update \
	&& apt-get install -y -V --no-install-recommends python3 python3-pip \
	&& pip3 install --upgrade pip \
	&& pip3 install -U setuptools \
	&& rm -r /var/lib/apt/lists/*

# django
ENV DJANGO_HOME "/home/site/wwwroot"
RUN set -ex \
	&& apt-get update \
	&& apt-get install -y -V --no-install-recommends build-essential python3-dev \
	&& pip3 install uwsgi \
	&& pip3 install django
# ssh
ENV SSH_PASSWD "root:Docker!"
RUN set -ex \
	&& apt-get update \
	&& apt-get install -y --no-install-recommends openssh-server \
	&& echo "$SSH_PASSWD" | chpasswd 

# install Postgres adapter for Python
RUN set -ex \
        && pip3 install psycopg2

# post-install
RUN set -ex \
	##
	&& rm -rf /var/log/nginx \
	&& ln -s $NGINX_LOG_DIR /var/log/nginx \
	&& test ! -d /etc/nginx/uwsgi && mkdir -p /etc/nginx/uwsgi \
	##
	&& rm -rf /var/log/postgresql \
	&& ln -s $POSTGRESQL_LOG_DIR /var/log/postgresql \
	##
	&& ln -s  /usr/share/phppgadmin /var/www \
	##
	&& rm -rf /var/www/default \
	&& ln -s $DJANGO_HOME /var/www/default
	
# setup nginx default conf
COPY nginx-sites-default /etc/nginx/sites-available/default
# postgresql scripts: create default user
COPY init.sql $POSTGRESQL_SOURCE/
# uWSGI config
COPY uwsgi.ini /etc/nginx/uwsgi/
# ssh
COPY sshd_config /etc/ssh/

# =====
# final
# =====
COPY entrypoint.sh /usr/local/bin/
RUN chmod u+x /usr/local/bin/entrypoint.sh
EXPOSE 2222 80
ENTRYPOINT ["entrypoint.sh"]
