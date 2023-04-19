create database prueba_anderson

create  table pacientes(
tipo_documento int ,
numero_documento int,
nombres varchar(50),
apellidos varchar(50),
correo varchar(50),
telefono int,
fecha_nacimiento datetime,
estado_afiliacion char

)

create table documento(
id int,
descripcion varchar(50)
)

create index tipo_documento_pk on pacientes ( numero_documento ) 

create index pacientes_pk on documento ( id ) 