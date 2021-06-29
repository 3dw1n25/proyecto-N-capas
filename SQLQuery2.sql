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
select codigo as Código, Titulo as Tituo, Director, Productora
from video
where Titulo like '%' + @valor + '%' or Director like '%' +@valor + '%' or Productora like '%' +@valor + '%'
order by codigo desc
go


