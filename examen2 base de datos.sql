use Examen2

create table author(
	id int not null identity(1,1) primary key,
	name varchar(150) not null
);

create table book(
	id int not null identity(1,1) primary key,
	id_author int not null,
	title varchar(100) not null,
	chapters int not null,
	pages int not null,
	price float not null
	foreign key (id_author) references author(id)
);