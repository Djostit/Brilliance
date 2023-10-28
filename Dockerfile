FROM mysql:latest

COPY /mysql-scripts/init.sql /docker-entrypoint-initdb.d/

ENV MYSQL_ROOT_PASSWORD=1234
ENV MYSQL_DATABASE=db_brilliance

ENV MYSQL_CHARSET=utf8mb4
ENV MYSQL_COLLATION=utf8mb4_unicode_ci

ENV MYSQL_PORT=3306

EXPOSE $MYSQL_PORT