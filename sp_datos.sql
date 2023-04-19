IF OBJECT_ID('dbo.sp_datos') IS NOT NULL
BEGIN
	DROP PROCEDURE dbo.sp_datos

	IF OBJECT_ID('dbo.sp_datos') IS NOT NULL
		PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_datos >>>'
	ELSE
		PRINT '<<< DROPPED PROCEDURE dbo.sp_datos >>>'
END
GO
create  procedure sp_datos(
@tipo_documento int =null,
@documento int = null,
@nombres varchar(50)= null,
@apellidos varchar(50)= null,
@correo    varchar(50)= null,
@telefono  int= null,
@fecha datetime= null,
@estado int= null,
@parametro int= null 
)
as

SET NOCOUNT ON

begin

if(@parametro = 1)
  begin
    select * from  pacientes
  end

  if(@parametro = 2)
  begin
      update pacientes set tipo_documento = @tipo_documento, nombres= @nombres,apellidos= @apellidos,correo= @correo,
	                      telefono= @telefono, fecha_nacimiento = @fecha, estado_afiliacion = @estado 
						  where numero_documento=  @documento
  end

 if(@parametro = 3)
  begin
    delete  pacientes where numero_documento = @documento
  end

   if(@parametro = 4)
  begin
    if exists(select * from pacientes where numero_documento = @documento)
	   begin
	      select 'Este numero '+@documento+ 'de cedula ya existe'
	   end
    insert into  pacientes values(@tipo_documento,@documento,@nombres,@apellidos,@correo,@telefono,@fecha,@estado) 
  end
end

GO

--====================================================================
--Permisos del objeto
GO

IF OBJECT_ID('dbo.sp_datos') IS NOT NULL
	PRINT '<<< CREATED PROCEDURE dbo.sp_datos  >>>'
ELSE
	PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_datos >>>'
GO

IF @@ERROR != 0
	SELECT '*** ERROR en Script ***'
ELSE
	SELECT 'Finalizo OK ' + RTRIM(CAST(GETDATE() AS NVARCHAR(30)))

