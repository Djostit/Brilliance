create database if not exists db_brilliance;
create table db_brilliance.roles
(
	id int not null primary key auto_increment,
    name varchar(50) not null
);
create table db_brilliance.users
(
	 id int not null primary key auto_increment,
     id_role int not null default 1,
     username varchar(16) not null,
     password varchar(128) not null,
     regDate datetime not null default current_timestamp,
     
     foreign key (id_role)
     references db_brilliance.roles(id)
);
create table db_brilliance.categories
(
	id int not null primary key auto_increment,
    name varchar(50) not null
);
create table db_brilliance.posts
(
	id int not null primary key auto_increment,
    id_user int not null,
    id_category int not null,
    title varchar(50) not null,
    description text not null,
    date datetime not null default current_timestamp,
    
    foreign key (id_user)
    references db_brilliance.users(id),
    
    foreign key (id_category)
    references db_brilliance.categories(id)
);
create table db_brilliance.comments
(
	id int not null primary key auto_increment,
    id_user int not null,
    id_post int not null,
    name varchar(100) not null,
    
    foreign key (id_user)
    references db_brilliance.users(id),
    
    foreign key (id_post)
    references db_brilliance.posts(id)
);
