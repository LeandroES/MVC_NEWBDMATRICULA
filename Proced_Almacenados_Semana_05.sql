use NEWBDMATRICULA2020
go

select * from Alumnos
go
select * from Matricula
go

select * from Especialidad
go
select * from Cursos
go

-- procedimiento almacenado para listar especialidades
create or alter procedure pa_listar_especialidad
as
	select e.CODESP, e.NOMESP from Especialidad e
go

-- procedimiento almacenado para listar los cursos de acuerdo
-- a un codigo de especialidad
create or alter procedure pa_cursos_especialidad
@codesp char(3)
as
	select c.CODCUR, c.NOMCUR, c.COSTO, c.NROVAC 
	from Cursos c where c.CODESP=@codesp
go

execute pa_listar_especialidad
go

execute pa_cursos_especialidad ''
go

-- pueden ser modelos en MVC
select * from alumnos
go

select APENOM
from Alumnos
go

select *
from Alumnos where CODALU='A0001'
go

-- No puede ser modelo en MVC
select APENOM
from Alumnos where CODALU='A0001'
go


create or alter procedure pa_cursos_por_costo
@costo numeric(6,2)
as
	select c.CODCUR, c.NOMCUR, c.COSTO, c.NROVAC 
	from Cursos c where COSTO >= @costo
go

execute pa_cursos_por_costo 0
go

create or alter procedure pa_cursos_por_rango_vacantes
@vac1 int, @vac2 int
as
	select c.CODCUR, c.NOMCUR, c.COSTO, c.NROVAC 
	from Cursos c where NROVAC between  @vac1 and @vac2
go

execute pa_cursos_por_rango_vacantes 8, 10
go



