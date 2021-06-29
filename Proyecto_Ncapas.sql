CREATE TABLE libros (
	id integer primary key identity,
	Numeroejemplar integer,
	ISBN varchar(100),
	Titulo varchar(25),
	Autor varchar(150),
	Editorial varchar(25),
	AñoEdicion varchar(10),
	NumeroEdicion varchar(15),
	Pais varchar(20),
	idioma varchar(15),
	Materia varchar(15),
	NumeroPaginas integer,
	Ubicacion varchar(100),
	Descripcion varchar(200)
);

CREATE TABLE video(
	codigo integer primary key identity,
	Titulo varchar(20),
	Director varchar(40),
	Productora varchar (25),
	tipo varchar(10),
	Año varchar(10),
	Duracion varchar(10),
	Pais varchar(20),
	idioma varchar(15),
	subtitulos varchar (15),
	Clasificacion varchar(10),
	Genero varchar(10),
	sinopsis varchar (200),
	ubicacion varchar (100),
);


create table rol (
	idrol integer primary key identity,
	nombre varchar(30) not null,
	descripcion varchar(255) null,
	estado bit default(1)
);


CREATE TABLE usuario (
id integer primary key identity,
nombre varchar(40),
contraseña varchar(40),
idrol integer not null,
FOREIGN KEY (idrol) REFERENCES rol(idrol)
);


create table prestamo (
	idprestamo integer primary key identity,
	idusuario integer not null,
	idlibro integer not null,
	idvideo integer not null,
	fecha datetime not null,
	fechadev datetime not null,
	estado BIT NULL DEFAULT 1,
	FOREIGN KEY (idusuario) REFERENCES usuario(id),
	FOREIGN KEY (idvideo) REFERENCES video(codigo),
	FOREIGN KEY (idlibro) REFERENCES libros(id)
);

alter table usuario add apellido varchar(40);

