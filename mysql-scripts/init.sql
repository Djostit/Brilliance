create table db_brilliance.user_roles
(
	id int not null primary key auto_increment,
	name varchar(50) not null
);

insert into db_brilliance.user_roles(name)
values
("Пользователь"), ("Администратор");

create table db_brilliance.users
(
	id int not null primary key auto_increment,
    role_id int not null,
    username varchar(16) not null,
    password varchar(128) not null,
    
    constraint fk_role_id
    foreign key (role_id)
    references db_brilliance.user_roles(id)
);