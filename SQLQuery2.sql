-- Listar
create proc persona_listar
as
select id as Código, nombre as Nombre, apellido as Apellido
from usuario
order by id desc
go

create proc libro_listar
as
select id as Código, Titulo, Autor
from libros 
order by id desc
go

create proc prestamo_listar
as
select prestamo.idusuario as Profesor, libros.Titulo as Libro, video.Titulo as Video, prestamo.fecha as 'Fecha prestamo', prestamo.fechadev as 'Fecha devolucion'
from prestamo INNER JOIN libros  
On prestamo.idlibro = libros.id
 Inner JOIN video
 on prestamo.idvideo = video.codigo
order by prestamo.idusuario desc
go


-- Buscar
create proc bucar_profesor
@valor varchar(50)
as
select id as Código, nombre as Nombre, apellido as Apellido
from usuario
where nombre like '%' + @valor + '%' or apellido like '%' +@valor + '%'
order by nombre asc
go

create proc bucar_libros
@valor varchar(50)
as
select id as Código, Titulo, Autor
from libros 
where Titulo like '%' + @valor + '%' or Autor like '%' +@valor + '%'
order by id desc
go

create proc bucar_video
@valor varchar(50)
as
select codigo as Código, Titulo as Tituo, Director
from video
where Titulo like '%' + @valor + '%' or Director like '%' +@valor + '%' 
order by codigo desc
go


--insertar
create proc libro_insertar
@Numeroej integer,
@ISBN varchar(100),
@Titulo varchar(25),
@Autor varchar(150),
@Editorial varchar(25),
@AñoEdicion varchar(10),
@NumeroEdicion varchar(15),
@Pais varchar(20),
@idioma varchar(15),
@Materia varchar(15),
@NumeroPaginas integer,
@Ubicacion varchar(100),
@Descripcion varchar(200)
as
insert into libros (Numeroejemplar,ISBN,Titulo,Autor,Editorial,AñoEdicion,NumeroEdicion,Pais,idioma,Materia,NumeroPaginas,Ubicacion,Descripcion)
values (@Numeroej,@ISBN,@Titulo,@Autor,@Editorial,@AñoEdicion,@NumeroEdicion,@Pais,@idioma,@Materia,@NumeroPaginas,@Ubicacion,@Descripcion)
go

create proc video_insertar
	@Titulo varchar(20),
	@Director varchar(40),
	@Productora varchar (25),
	@tipo varchar(10),
	@Año varchar(10),
	@Duracion varchar(10),
	@Pais varchar(20),
	@idioma varchar(15),
	@subtitulos varchar (15),
	@Clasificacion varchar(10),
	@Genero varchar(10),
	@sinopsis varchar (200),
	@ubicacion varchar (100)
	as
	insert into video (Titulo,Director,Productora,tipo,Año,Duracion,Pais,idioma,subtitulos,Clasificacion,Genero,sinopsis,ubicacion)
	values (@Titulo,@Director,@Productora,@tipo,@Año,@Duracion,@Pais,@idioma,@subtitulos,@Clasificacion,@Genero,@sinopsis,@ubicacion)
	go

create procedure usr_insertar
@nombre varchar(40),
@contraseña varchar(40),
@apellido varchar(40)
as
insert into usuario (nombre,apellido,contraseña)
values (@nombre,@apellido,@contraseña)