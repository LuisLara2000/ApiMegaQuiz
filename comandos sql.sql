/* BASE DE DATOS TEMPORAL */
/* CREACION DE LA BASE DE DATOS*/
create database dbMegaQuiz;

/* SELECCIONAMOS LA BASE DE DATOS */
use dbMegaQuiz;

/* CREACION DE LA TABLA*/
/* TIENE UNA RESPUESTA INCORRECTA DE MAS*/
create table preguntas(
	idPregunta smallint NOT NULL IDENTITY(1,1) PRIMARY KEY,
	pregunta varchar(255),
	rCorrecta varchar(100),
	rIncorrecta1 varchar(100),
	rIncorrecta2 varchar(100),
	rIncorrecta3 varchar(100),
	rIncorrecta4 varchar(100),
	rIncorrecta5 varchar(100),
	rIncorrecta6 varchar(100),
	estado tinyint,
	dificultad tinyint
);

/* INSERTAR LA INFORMACION EN LA BASE DE DATOS */

insert into preguntas (pregunta,rCorrecta,rIncorrecta1,rIncorrecta2,rIncorrecta3,rIncorrecta4,rIncorrecta5,rIncorrecta6,estado,dificultad) values ('¿A cuantos robots tiene que derrotar megaman para llegar con el dr wily ?','8',	'xd',	'xd',	'xd',	'xd',	'xd',	'xd',	0,	1);
insert into preguntas (pregunta,rCorrecta,rIncorrecta1,rIncorrecta2,rIncorrecta3,rIncorrecta4,rIncorrecta5,rIncorrecta6,estado,dificultad) values ('¿En que año salio el primer juego de megaman?', '1987',	'xd',	'xd',	'xd',	'xd',	'xd',	'xd',	1,	1);
insert into preguntas (pregunta,rCorrecta,rIncorrecta1,rIncorrecta2,rIncorrecta3,rIncorrecta4,rIncorrecta5,rIncorrecta6,estado,dificultad) values ('¿Con que nombre se le conoce a megaman en japon?','rock man',	'xd',	'xd',	'xd',	'xd',	'xd',	'xd',	0,	1);
insert into preguntas (pregunta,rCorrecta,rIncorrecta1,rIncorrecta2,rIncorrecta3,rIncorrecta4,rIncorrecta5,rIncorrecta6,estado,dificultad) values ('¿Cuál robot master aparece en megaman 1?','cut man',	'xd',	'xd',	'xd',	'xd',	'xd',	'xd',	2,	1);
insert into preguntas (pregunta,rCorrecta,rIncorrecta1,rIncorrecta2,rIncorrecta3,rIncorrecta4,rIncorrecta5,rIncorrecta6,estado,dificultad) values ('¿Como se llama el juego de megaman donde juega futbol?','Mega Mans Soccer',	'xd',	'xd',	'xd',	'xd',	'xd',	'xd',	2,	1);


/* CREACION DE LOS PROCEDIMIENTOS ALMACENADOS */

/* Ver todas las preguntas */
create procedure sp_mostrarTodasPreguntas
as
	begin
		select idPregunta, 
		       pregunta, 
			   estado 
	    from preguntas
	end
go
/* ESTE PROCEDIMIENTO ESTA MAL*/
/* DEBE MOSTRARTE TODAS LAS PREGUNTAS DEL ESTADO QUE SELECCIONASTE */
/* Ver solo las preguntas, no vistas, correctas, incorrectas*/
create procedure sp_mostrarPreguntasEspecificas
	@estado tinyint
as
	begin
		select idPregunta, 
		       pregunta, 
			   estado 
	    from preguntas 
		where estado = @estado
	end
go

/* Ver una pregunta en especifico */
create procedure sp_mostrarUnaPregunta
	@idPregunta smallint
as
	begin
		select pregunta, 
			   rCorrecta,
			   rIncorrecta1,
			   rIncorrecta2,
			   rIncorrecta3,
			   rIncorrecta4,
			   rIncorrecta5,
			   rIncorrecta6 
	    from preguntas 
		where idPregunta = @idPregunta
	end
go

/* PROBANDO LOS PROCEDIMIENTOS ALMACENADOS */
exec sp_mostrarTodasPreguntas









