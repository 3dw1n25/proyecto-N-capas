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

CREATE TABLE usuario (
nombre varchar(40) primary key,
contraseña varchar(40),
);

CREATE TABLE biblioteca(
idbib integer primary key identity,
nombreUsr varchar(40),
idlb integer,
foreign key (nombreUsr) references usuario (nombre),
foreign key (idlb) references libros (id)
);