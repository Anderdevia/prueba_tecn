--     create database prueba_anderson

IF OBJECT_ID('dbo.Pacientes') IS NOT NULL
BEGIN
	DROP TABLE dbo.Pacientes

	IF OBJECT_ID('dbo.Pacientes') IS NOT NULL
		PRINT '<<< FAILED DROPPING TABLE dbo.Pacientes >>>'
	ELSE
		PRINT '<<< DROPPED TABLE dbo.Pacientes >>>'
END
GO


create  table Pacientes(
tipo_documento varchar(50),
numero_documento int primary key,
nombres varchar(50),
apellidos varchar(50),
correo varchar(50),
telefono int,
fecha_nacimiento datetime,
estado_afiliacion varchar(20)
)


IF OBJECT_ID('dbo.Pacientes') IS NOT NULL
	PRINT '<<< CREATED TABLE dbo.Pacientes  >>>'
ELSE
	PRINT '<<< FAILED CREATING TABLE dbo.Pacientes >>>'
GO

IF @@ERROR != 0
	SELECT '*** ERROR en Script ***'
ELSE
	SELECT 'Finalizo OK ' + RTRIM(CAST(GETDATE() AS NVARCHAR(30)))