create table db_brilliance.roles
(
	id int not null primary key auto_increment,
    name varchar(50) not null
);

insert into db_brilliance.roles(name)
values
("User"), ("Admin");

create table db_brilliance.users
(
	 id int not null primary key auto_increment,
     id_role int not null default 1,
     username varchar(16) not null,
     password varchar(128) not null,
     regDate datetime not null default current_timestamp,
     
     constraint fk_role_id
     foreign key (id_role)
     references db_brilliance.roles(id)
);

insert into db_brilliance.users(id_role, username, password)
values
(1, 'Tom', '$2a$11$7S3lORTUmb6xs1E7mYQ3u.73Eh.6UFkR7MoUX9bnzlh591RvWufu6'),
(2, 'Bob', '$2a$11$H..8tQN1AAaYZLimZDULbeNN0eFcPNo6lvfueEitgIIpE8NSxHTLC');

create table db_brilliance.categories
(
	id int not null primary key auto_increment,
    name varchar(50) not null
);

insert into db_brilliance.categories(name)
values
('WPF'), ('WinForms'), ('MAUI');

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

insert into db_brilliance.posts(id_user, id_category, title, description)
values
(1, 1, 'WPF its bad or not?' , 'Empty'),
(1, 2, 'Dont use anymore winforms', 'empty'),
(1, 3, 'Its best framerwork in world', 'empty');


create table db_brilliance.comments
(
	id int not null primary key auto_increment,
    id_user int not null,
    name varchar(100) not null,
    
    foreign key (id_user)
    references db_brilliance.users(id)
);

create table db_brilliance.posts_comments
(
	id_post int not null,
    id_comment int not null,
    primary key (id_post, id_comment),
    
    foreign key (id_post)
	references db_brilliance.posts(id),
    
    foreign key (id_comment)
    references db_brilliance.comments (id)
)
