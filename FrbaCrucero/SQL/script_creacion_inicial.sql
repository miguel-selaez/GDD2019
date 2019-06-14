USE GD1C2019;
GO

CREATE SCHEMA DSW; 
GO

print (CONCAT('Creacion de tablas ', CONVERT(VARCHAR, GETDATE(), 114)))

CREATE TABLE [DSW].[Puerto] (
  [pt_id] int IDENTITY (1,1),
  [pt_descripcion] nvarchar(255),
  PRIMARY KEY ([pt_id])
);

GO

CREATE TABLE [DSW].[Tramo] (
  [t_id] int IDENTITY(1,1),
  [t_id_origen] int,
  [t_id_destino] int,
  [t_precio] decimal(18,2),
  PRIMARY KEY ([t_id])
);

GO

CREATE TABLE [DSW].[Recorrido] (
  [rc_id] decimal(18,0) IDENTITY(43820864, 1),
  [rc_codigo] char(20), -- Verificar el tipo en el enunciado
  [rc_baja] bit,
  PRIMARY KEY ([rc_id])
);

GO

CREATE TABLE [DSW].[Recorridos_x_tramos] (
  [rxt_id_recorrido] decimal(18,0),
  [rxt_id_tramo] int,
  [rxt_orden] int,
  PRIMARY KEY ([rxt_id_recorrido], [rxt_id_tramo], [rxt_orden])
);

GO

CREATE TABLE [DSW].[Pago] (
  [p_id] int IDENTITY(1,1),
  [p_total] decimal(18,2),
  [p_fecha_compra] datetime2(3),
  [p_cant_cuotas] int,
  [p_id_cliente] int,
  [p_id_medio_pago] int,
  PRIMARY KEY ([p_id])
);

GO

CREATE TABLE [DSW].[Viaje] (
  [v_id] int IDENTITY(1,1),
  [v_id_crucero] int,
  [v_id_recorrido] decimal(18,0),
  [v_fecha_salida] datetime2(3),
  [v_fecha_llegada] datetime2(3),
  [v_fecha_llegada_estimada] datetime2(3),
  PRIMARY KEY ([v_id])
);

GO

CREATE TABLE [DSW].[Cliente] (
  [c_id] int IDENTITY(1,1),
  [c_nombre] nvarchar(255),
  [c_apellido] nvarchar(255),
  [c_dni] decimal(18,0),
  [c_direccion] nvarchar(255),
  [c_telefono] int,
  [c_mail] nvarchar(255),
  [c_fecha_nacimiento] datetime2(3),
  [c_inconsistente] bit,
  PRIMARY KEY ([c_id])
);

GO

CREATE TABLE [DSW].[Pasaje] (
  [pa_codigo] decimal(18,0) IDENTITY(28797566, 1),
  --[pa_fecha_compra] datetime2(3),
  [pa_precio] decimal(18,2),
  [pa_id_viaje] int,
  [pa_id_cabina] int,
  [pa_id_reserva] decimal(18,0),
  [pa_id_cliente] int,
  [pa_id_pago] int,
  PRIMARY KEY ([pa_codigo])
);

GO

CREATE TABLE [DSW].[Crucero] (
  [cr_id] int IDENTITY (1,1),
  [cr_codigo] nvarchar(50),
  [cr_modelo] nvarchar(50),
  [cr_id_marca] int,
  [cr_fecha_alta] datetime2(3),
  [cr_baja] bit,  
  [cr_fecha_baja] datetime2(3),
  PRIMARY KEY ([cr_id])
);

GO

CREATE TABLE [DSW].[Fuera_Servicio_Crucero] (
	[fs_id] int IDENTITY (1,1),
	[fs_id_crucero] int,
	[fs_fecha_inicio] datetime2(3),
    [fs_fecha_fin] datetime2(3),
    [fs_motivo] nvarchar(50),
	PRIMARY KEY ([fs_id])
)

GO

CREATE TABLE [DSW].[Cabina] (
  [ca_id] int IDENTITY (1,1),
  [ca_numero] decimal(18,0),
  [ca_piso] decimal(18,0),
  [ca_baja] bit,
  [ca_id_crucero] int,
  [ca_id_tipo_cabina] int,
  PRIMARY KEY ([ca_id])
);

GO

CREATE TABLE [DSW].[Tipo_cabina] (
  [tc_id] int IDENTITY (1,1),
  [tc_descripcion] nvarchar(255),
  [tc_porcentaje_recargo] decimal(18,2),
  PRIMARY KEY ([tc_id])
);

GO

CREATE TABLE [DSW].[Marca] (
  [m_id] int IDENTITY (1,1),
  [m_descripcion] nvarchar(255),
  PRIMARY KEY ([m_id])
);

GO

CREATE TABLE [DSW].[Medio_Pago] (
  [mp_id] int IDENTITY(1,1),
  [mp_descripcion] nvarchar(100),
  PRIMARY KEY ([mp_id])
);

GO

CREATE TABLE [DSW].[Reserva] (
  [r_codigo] decimal(18,0) IDENTITY(53930108, 1),
  [r_fecha] datetime2(3),
  [r_estado] bit,
  [r_id_cliente] int,
  PRIMARY KEY ([r_codigo])
);

GO

CREATE TABLE [DSW].[Funcion] (
  [f_id] int IDENTITY (1,1),
  [f_descripcion] nvarchar(100),
  [f_baja] bit,
  PRIMARY KEY ([f_id])
);

GO

CREATE TABLE [DSW].[Funcion_x_Rol] (
  [fxr_id_funcion] int,
  [fxr_id_rol] int
);

GO

CREATE TABLE [DSW].[Rol] (
  [r_id] int IDENTITY (1,1),
  [r_descripcion] nvarchar(100),
  [r_baja] bit,
  PRIMARY KEY ([r_id])
);

GO

CREATE TABLE [DSW].[Usuario] (
  [u_id] int IDENTITY (1,1),
  [u_nombre_usuario] nvarchar(100),
  [u_password] varbinary(256),
  [u_baja] bit,
  [u_intentos_fallidos] int,
  PRIMARY KEY ([u_id])
);

GO

CREATE TABLE [DSW].[Rol_x_Usuario] (
  [rxu_id_usuario] int,
  [rxu_id_rol] int
);

GO

--------------------FIN TABLAS ----------------------------------------------------
print (CONCAT('Creacion de SPs ', CONVERT(VARCHAR, GETDATE(), 114)))

GO

CREATE PROCEDURE [DSW].P_Obtener_Funciones_x_Rol 
	@id int
AS
BEGIN 
	SELECT 
		f.*
	FROM 
		[DSW].Funcion as f
		INNER JOIN [DSW].Funcion_x_Rol as fr
			ON f.f_id = fr.fxr_id_funcion
	WHERE 
		fr.fxr_id_rol = @id
		AND f.f_baja = 0
	ORDER BY
		f.f_descripcion

END

GO

CREATE PROCEDURE [DSW].P_Obtener_Roles_x_Usuario  
	@id int
AS
BEGIN 
	SELECT 
		r.*
	FROM 
		[DSW].Rol as r
		INNER JOIN [DSW].Rol_x_Usuario as ru
			ON r.r_id = ru.rxu_id_rol
	WHERE 
		ru.rxu_id_usuario = @id
		AND r.r_baja = 0
	ORDER BY
		r.r_descripcion
END

GO

CREATE PROCEDURE [DSW].P_Login  
	@user nvarchar(255),
	@pass nvarchar(50)
AS
BEGIN 
	DECLARE @pass_enc varbinary(256)
	SELECT @pass_enc = HASHBYTES('SHA2_256', @pass);

	SELECT 
		u.u_id,
		u.u_nombre_usuario,
		'' as pass,
		u.u_baja,
		u.u_intentos_fallidos
	FROM
		[DSW].Usuario as u
	WHERE
		UPPER(u.u_nombre_usuario) = UPPER(@user)
		AND u.u_password = @pass_enc
		AND u.u_baja = 0
	 	
END

GO

CREATE PROCEDURE [DSW].P_Obtener_Roles  
	@descripcion nvarchar(255),
	@baja bit
AS
BEGIN 
	SELECT 
		r.*
	FROM 
		[DSW].Rol as r
	WHERE
		(r.r_descripcion like '%'+ @descripcion + '%' OR @descripcion IS NULL)
		AND (r.r_baja = @baja OR @baja IS NULL)
	ORDER BY
		r.r_descripcion

END

GO

CREATE PROCEDURE [DSW].P_Obtener_Funciones 
	@baja bit
AS
BEGIN 
	SELECT 
		f.*
	FROM 
		[DSW].Funcion as f
	WHERE 
		f.f_baja = @baja
	ORDER BY
		f.f_descripcion

END

GO

CREATE PROCEDURE [DSW].P_Guardar_Rol 
	@id int, 
	@descripcion nvarchar(255),
	@baja bit
AS
BEGIN 
	IF @id = 0
	BEGIN 
		INSERT INTO [DSW].Rol (r_descripcion, r_baja)
		VALUES (@descripcion, @baja)

		SELECT id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE [DSW].Rol 
		SET 
			r_descripcion = @descripcion,
			r_baja = @baja
		WHERE 
			r_id = @id;

		SELECT id_out = @id;

		DELETE [DSW].Funcion_x_Rol
		WHERE 
			fxr_id_rol = @id;
	END
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Funcion_x_Rol 
	@id_funcion int, 
	@id_rol int
AS
BEGIN 
	INSERT INTO [DSW].Funcion_x_Rol(fxr_id_funcion, fxr_id_rol)
	VALUES (@id_funcion, @id_rol)
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Puerto
	@id_puerto int
AS
BEGIN
	SELECT * FROM [DSW].Puerto WHERE pt_id = @id_puerto;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Tramos_x_Recorrido
	@id_recorrido int
AS
BEGIN
	SELECT t_id, t_id_origen, t_id_destino, t_precio FROM [DSW].Tramo as t 
	INNER JOIN [DSW].Recorridos_x_tramos as rt ON t_id = rxt_id_tramo
	WHERE rxt_id_recorrido = @id_recorrido ORDER BY rt.rxt_orden ASC;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Tramos
AS
BEGIN
	SELECT t_id, t_id_origen, t_id_destino, t_precio FROM [DSW].Tramo;
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Tramo_x_Recorrido
	@id_tramo int,
	@id_recorrido int,
	@orden int
AS
BEGIN
	INSERT INTO [DSW].Recorridos_x_tramos VALUES (@id_recorrido, @id_tramo, @orden);
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Recorridos
	@codigo char(20),
	@baja bit
AS
BEGIN
	SELECT * FROM [DSW].Recorrido WHERE (rc_codigo = @codigo OR @codigo IS NULL) AND (rc_baja = @baja OR @baja IS NULL) ORDER BY rc_codigo;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Recorrido
	@id_recorrido decimal
AS
BEGIN
	SELECT * FROM [DSW].Recorrido WHERE rc_id = @id_recorrido;
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Recorrido
	@id_recorrido int,
	@codigo char(20),
	@baja bit
AS
BEGIN
	IF @id_recorrido = 0
	BEGIN 
		INSERT INTO [DSW].Recorrido VALUES (@codigo, @baja);
		SELECT id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE [DSW].Recorrido 
		SET 
			rc_codigo = @codigo,
			rc_baja = @baja
		WHERE 
			rc_id = @id_recorrido;

		SELECT id_out = @id_recorrido;

		DELETE [DSW].Recorridos_x_tramos
		WHERE 
			rxt_id_recorrido = @id_recorrido;
	END
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Viaje
	@id_viaje int,
	@codigo_crucero int,
	@codigo_recorrido decimal,
	@fecha_salida datetime2,
	@fecha_llegada datetime2,
	@fecha_llegada_estimada datetime2
AS
BEGIN
	IF @id_viaje = 0
	BEGIN 
		INSERT INTO [DSW].Viaje VALUES (@codigo_crucero, @codigo_recorrido, @fecha_salida, @fecha_llegada, @fecha_llegada_estimada);
		SELECT id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE [DSW].Viaje 
		SET 
			v_id_crucero = @codigo_crucero,
			v_id_recorrido = @codigo_recorrido,
			v_fecha_llegada = @fecha_llegada,
			v_fecha_salida = @fecha_salida,
			v_fecha_llegada_estimada = @fecha_llegada_estimada
		WHERE 
			v_id = @id_viaje;

		SELECT id_out = @id_viaje;
	END
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Viaje
	@id_viaje decimal
AS
BEGIN
	SELECT * FROM [DSW].Viaje WHERE v_id = @id_viaje;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Viajes
	@codigo_crucero nvarchar(255),
	@codigo_recorrido char(20),
	@page int,
	@offset int
AS
BEGIN
	SELECT v.* FROM [DSW].Viaje v
	INNER JOIN [DSW].Crucero AS c ON c.cr_id = v.v_id_crucero
	INNER JOIN [DSW].Recorrido AS r ON r.rc_id = v.v_id_recorrido
	WHERE (c.cr_codigo = @codigo_crucero OR @codigo_crucero IS NULL) AND (r.rc_codigo = @codigo_recorrido OR @codigo_recorrido IS NULL) 
	ORDER BY v.v_fecha_salida DESC
	OFFSET (@page * @offset) ROWS FETCH NEXT @offset ROWS ONLY;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Cantidad_Viajes
	@codigo_crucero nvarchar(255),
	@codigo_recorrido char(20)
AS
BEGIN
	SELECT count(*) as "count" FROM [DSW].Viaje v
	INNER JOIN [DSW].Crucero AS c ON c.cr_id = v.v_id_crucero
	INNER JOIN [DSW].Recorrido AS r ON r.rc_id = v.v_id_recorrido
	WHERE (c.cr_codigo = @codigo_crucero OR @codigo_crucero IS NULL) AND (r.rc_codigo = @codigo_recorrido OR @codigo_recorrido IS NULL);
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Marca
	@id_marca int
AS
BEGIN
	SELECT * FROM [DSW].Marca WHERE m_id = @id_marca;
END

GO

CREATE PROCEDURE [DSW].P_Obtener_Crucero
	@id_crucero int
AS
BEGIN
	SELECT * FROM [DSW].Crucero WHERE cr_id = @id_crucero;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Cruceros
	@codigo_crucero nvarchar(50),
	@id_marca int,
	@modelo nvarchar(50),
	@estado nvarchar(50),
	@fecha_actual datetime2(3)
AS
BEGIN
	
	SELECT
		*
	FROM (
		SELECT 
			c.*,
			CASE 
				WHEN c.cr_baja = 1 THEN 'No Vigente'
				WHEN EXISTS(
					SELECT * FROM DSW.Fuera_Servicio_Crucero as f 
					WHERE f.fs_id_crucero = c.cr_id
						AND @fecha_actual >= f.fs_fecha_inicio  
						AND @fecha_actual <= f.fs_fecha_fin) THEN 'Fuera de Servicio'
				ELSE 'Vigente' 
			END as 'cr_estado'  
		FROM [DSW].Crucero as c
		WHERE 
			(cr_codigo like '%' + @codigo_crucero + '%' OR @codigo_crucero IS NULL)
			AND (cr_id_marca = @id_marca OR @id_marca = 0)
			AND (cr_modelo = @modelo OR @modelo IS NULL)
	) as t
	WHERE (@estado = 'Todos' OR t.cr_estado = @estado)
	ORDER BY t.cr_id_marca, t.cr_modelo

END
GO

CREATE PROCEDURE [DSW].P_Obtener_Cruceros_Disponibles
	@fechaSalida nvarchar(50),
	@fechaLlegada nvarchar(50)
AS
BEGIN
	SELECT * FROM
		[DSW].Crucero as c
		WHERE cr_id NOT IN (SELECT v_id_crucero FROM [dsw].Viaje 
						WHERE (v_fecha_salida BETWEEN @fechaSalida AND @fechaLlegada
						OR v_fecha_llegada BETWEEN @fechaSalida AND @fechaLlegada)
						AND v_id_crucero = cr_id)
		AND cr_baja = 0 
		AND NOT EXISTS(
			SELECT * FROM DSW.Fuera_Servicio_Crucero as f 
			WHERE f.fs_id_crucero = c.cr_id
				AND (f.fs_fecha_inicio BETWEEN @fechaSalida AND @fechaLlegada
				OR f.fs_fecha_fin BETWEEN @fechaSalida AND @fechaLlegada) 
		)
		ORDER BY cr_id_marca, cr_modelo
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Marcas
AS
BEGIN
	SELECT * FROM [DSW].Marca
	ORDER BY m_descripcion
END 

GO

CREATE PROCEDURE [DSW].P_Obtener_Cabinas_x_Crucero
@id_crucero int
AS
BEGIN
	SELECT 
		c.*
	FROM 
		[DSW].Cabina as c
	WHERE 
		c.ca_id_crucero = @id_crucero
		AND c.ca_baja = 0
	ORDER BY
		c.ca_piso,
		c.ca_numero
END 
GO

CREATE PROCEDURE [DSW].P_Obtener_Tipo_Cabina
@id_tipo_cabina int
AS
BEGIN
	SELECT * FROM [DSW].Tipo_cabina
	WHERE tc_id = @id_tipo_cabina
END 

GO
CREATE PROCEDURE [DSW].P_Validar_Dni_CLiente
	@v_dni decimal,
	@v_flag bit OUT
AS
BEGIN
	SELECT TOP 1 @v_flag = 1 FROM DSW.Cliente WHERE c_dni = @v_dni

	SET @v_flag = ISNULL(@v_flag, 0)
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Cliente
	@v_c_id int OUT,
	@v_c_nombre nvarchar(255),
	@v_c_apellido nvarchar(255),
	@v_c_dni decimal(18,0),
	@v_c_direccion nvarchar(255),
	@v_c_telefono int,
	@v_c_mail nvarchar(255),
	@v_c_fecha_nacimiento	datetime2
AS
BEGIN
	IF @v_c_id = 0
	BEGIN
		INSERT INTO [DSW].Cliente(c_nombre,c_apellido,c_dni,c_direccion,c_telefono,c_mail,c_fecha_nacimiento) VALUES(@v_c_nombre, @v_c_apellido, @v_c_dni, @v_c_direccion, @v_c_telefono, @v_c_mail, @v_c_fecha_nacimiento)
		SET @v_c_id = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE [DSW].Cliente SET
			c_nombre = @v_c_nombre, 
			c_apellido = @v_c_apellido, 
			c_dni = @v_c_dni, 
			c_direccion = @v_c_direccion, 
			c_telefono = @v_c_telefono, 
			c_mail = @v_c_mail, 
			c_fecha_nacimiento = @v_c_fecha_nacimiento
		WHERE
			c_id = @v_c_id

		SET @v_c_id = @v_c_id
	END
	RETURN @v_c_id
END	
GO

CREATE PROCEDURE [DSW].P_Obtener_Clientes
	@v_c_dni decimal(18,0),
	@v_c_nombre nvarchar(255),
	@v_c_apellido nvarchar(255),
	@v_c_inconsistente bit,
	@page int,
	@offset int
AS
BEGIN	
	SELECT 
		c_id,
		c_nombre,
		c_apellido,
		c_dni,
		c_direccion,
		c_telefono,
		c_mail,
		c_fecha_nacimiento,
		c_inconsistente
	FROM DSW.Cliente
	WHERE
		(c_dni = @v_c_dni OR ISNULL(@v_c_dni, 0) = 0)
		AND (c_nombre LIKE '%' + @v_c_nombre + '%' OR ISNULL(@v_c_nombre, '') = '')
		AND (c_apellido LIKE '%' + @v_c_apellido + '%' OR ISNULL(@v_c_apellido, '') = '')
		AND (c_inconsistente =  @v_c_inconsistente OR @v_c_inconsistente IS NULL)
	ORDER BY
		c_apellido,
		c_nombre,
		c_dni,
		c_fecha_nacimiento
	OFFSET (@page * @offset) ROWS FETCH NEXT @offset ROWS ONLY;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Cliente
	@id int
AS
BEGIN	
	SELECT 
		c_id,
		c_nombre,
		c_apellido,
		c_dni,
		c_direccion,
		c_telefono,
		c_mail,
		c_fecha_nacimiento,
		c_inconsistente
	FROM DSW.Cliente
	WHERE
		c_id = @id;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Cantidad_Clientes
	@v_c_dni decimal(18,0),
	@v_c_nombre nvarchar(255),
	@v_c_apellido nvarchar(255),
	@v_c_inconsistente bit
AS
BEGIN	
	SELECT 
		count(*) as "count"
	FROM DSW.Cliente
	WHERE
		(c_dni = @v_c_dni OR ISNULL(@v_c_dni, 0) = 0)
		AND (c_nombre LIKE '%' + @v_c_nombre + '%' OR ISNULL(@v_c_nombre, '') = '')
		AND (c_apellido LIKE '%' + @v_c_apellido + '%' OR ISNULL(@v_c_apellido, '') = '')
		AND (c_inconsistente =  @v_c_inconsistente OR @v_c_inconsistente IS NULL);
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Pago
	@id int OUT,
	@cantidad_cuotas int,
	@fecha_compra datetime2,
	@total decimal(18,2),
	@id_cliente int, 
	@id_medio_pago int
AS
BEGIN
	IF @id = 0
	BEGIN
		INSERT INTO [DSW].Pago VALUES(@cantidad_cuotas, @fecha_compra, @total, @id_cliente, @id_medio_pago)
		SET @id = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE [DSW].Pago SET
			p_cant_cuotas = @cantidad_cuotas, 
			p_fecha_compra = @fecha_compra, 
			p_total = @total, 
			p_id_cliente = @id_cliente, 
			p_id_medio_pago = @id_medio_pago
		WHERE
			p_id = @id

		SET @id = @id
	END
	RETURN @id
END	
GO

CREATE PROCEDURE [DSW].P_Obtener_Pago
	@id int
AS
BEGIN	
	SELECT * FROM DSW.Pago WHERE p_id = @id;
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Reserva
	@codigo decimal OUT,
	@fecha datetime2,
	@estado bit,
	@id_cliente int
AS
BEGIN
	IF @codigo = 0
	BEGIN
		INSERT INTO [DSW].Reserva VALUES(@fecha, @estado, @id_cliente)
		SET @codigo = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE [DSW].Reserva SET
			r_fecha = @fecha, 
			r_estado = @estado, 
			r_id_cliente = @id_cliente
		WHERE
			r_codigo = @codigo

		SET @codigo = @codigo
	END
	RETURN @codigo
END	
GO

CREATE PROCEDURE [DSW].P_Obtener_Reserva
	@codigo decimal
AS
BEGIN	
	SELECT * FROM DSW.Reserva WHERE r_codigo = @codigo;
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Medio_Pago
	@id int OUT,
	@descripcion nvarchar(255)
AS
BEGIN
	IF @id = 0
	BEGIN
		INSERT INTO [DSW].Medio_Pago VALUES(@descripcion)
		SET @id = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE [DSW].Medio_Pago SET
			mp_descripcion = @descripcion
		WHERE
			mp_id = @id

		SET @id = @id
	END
	RETURN @id
END	
GO

CREATE PROCEDURE [DSW].P_Obtener_Medio_Pago
	@id int
AS
BEGIN	
	SELECT * FROM DSW.Medio_Pago WHERE mp_id = @id;
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Pasajes_x_Reserva
@codigo_reserva decimal
AS
BEGIN
	SELECT 
		*
	FROM 
		[DSW].Pasaje
	WHERE 
		pa_id_reserva = @codigo_reserva
END 
GO

CREATE PROCEDURE [DSW].P_Obtener_Pasajes_x_Pago
@id_pago int
AS
BEGIN
	SELECT 
		*
	FROM 
		[DSW].Pasaje
	WHERE 
		pa_id_pago = @id_pago
END 
GO

CREATE PROCEDURE [DSW].P_Guardar_Crucero 
	@id int, 
	@codigo nvarchar(50),
	@modelo nvarchar(50),
	@id_marca nvarchar(50),
	@fecha_alta datetime2(3),
	@fecha_baja datetime2(3),
	@baja bit
AS
BEGIN 
	IF @id = 0
	BEGIN 
		INSERT INTO [DSW].Crucero (cr_codigo, cr_modelo, cr_id_marca, cr_fecha_alta, cr_fecha_baja, cr_baja)
		VALUES (@codigo, @modelo, @id_marca, @fecha_alta, null, 0)

		SELECT id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE [DSW].Crucero 
		SET 
			cr_codigo = @codigo,
			cr_modelo = @modelo,
			cr_id_marca = @id_marca,
			cr_fecha_baja = @fecha_baja,
			cr_baja = @baja
		WHERE 
			cr_id = @id;

		SELECT id_out = @id;
	END
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Cabina
	@id int, 
	@numero decimal(18,0),
	@piso decimal(18, 0),
	@baja bit,
	@id_crucero int,
	@id_tipo_cabina int
AS
BEGIN 
	IF @id = 0
	BEGIN 
		INSERT INTO [DSW].Cabina (ca_numero, ca_piso, ca_baja, ca_id_crucero, ca_id_tipo_cabina)
		VALUES (@numero, @piso, 0, @id_crucero, @id_tipo_cabina)

		SELECT id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE [DSW].Cabina 
		SET 
			ca_numero = @numero,
			ca_piso = @piso,
			ca_baja = @baja,
			ca_id_crucero = @id_crucero,
			ca_id_tipo_cabina = @id_tipo_cabina
		WHERE 
			ca_id = @id;

		SELECT id_out = @id;
	END
END
GO

CREATE PROCEDURE [DSW].P_Obtener_Tipos_Cabina
AS
BEGIN
	SELECT * FROM [DSW].Tipo_cabina
	ORDER BY tc_descripcion
END 
GO

CREATE PROCEDURE [DSW].P_Guardar_Pasaje
	@codigo decimal(18, 0),
	@precio decimal(18, 2),
	@id_viaje decimal(18,0),
	@id_cabina int,
	@codigo_reserva decimal(18,0),
	@id_cliente int,
	@id_pago decimal(18,0)
AS
BEGIN 
	IF @codigo = 0
	BEGIN 
		INSERT INTO [DSW].Pasaje
		VALUES (@precio, @id_viaje, @id_cabina, @codigo_reserva, @id_cliente, @id_pago)
		SELECT id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE [DSW].Pasaje 
		SET 
			pa_precio = @precio,
			pa_id_viaje = @id_viaje,
			pa_id_cabina = @id_cabina,
			pa_id_reserva = @codigo_reserva,
			pa_id_cliente = @id_cliente,
			pa_id_pago = @id_pago
		WHERE 
			pa_codigo = @codigo;

		SELECT id_out = @codigo;
	END
END
GO

CREATE PROCEDURE [DSW].P_Guardar_Fuera_Servicio 
	@id_crucero int, 
	@fecha_inicio datetime2(3),
	@fecha_fin datetime2(3),
	@motivo nvarchar(50)
AS
BEGIN 
	INSERT INTO [DSW].Fuera_Servicio_Crucero(fs_id_crucero, fs_fecha_inicio, fs_fecha_fin, fs_motivo)
	VALUES (@id_crucero, @fecha_inicio, @fecha_fin, @motivo)
END
GO

CREATE PROCEDURE [DSW].P_Top_Recorridos_Pasajes_Comprados
	@fecha_desde datetime2,
	@fecha_hasta datetime2
AS
BEGIN 
	SELECT TOP 5 rc_id, count(*) cantidad FROM [DSW].Recorrido
	INNER JOIN [DSW].Viaje ON v_id_recorrido = rc_id 
	INNER JOIN [DSW].Pasaje ON pa_id_viaje = v_id AND pa_id_pago IS NOT NULL
	WHERE (v_fecha_llegada BETWEEN @fecha_desde AND @fecha_hasta
		AND v_fecha_llegada BETWEEN @fecha_desde AND @fecha_hasta)
	GROUP BY rc_id
	ORDER BY cantidad DESC
END
GO

CREATE PROCEDURE [DSW].P_Top_Recorridos_Cabinas_Libres
	@fecha_desde datetime2,
	@fecha_hasta datetime2
AS
BEGIN 
	SELECT TOP 5 rc.rc_id, vi.v_id, COUNT(*) cantidad FROM [DSW].Recorrido as rc
	INNER JOIN [DSW].Viaje as vi ON vi.v_id_recorrido = rc.rc_id 
	INNER JOIN [DSW].Crucero as cr ON cr.cr_id = vi.v_id_crucero
	INNER JOIN [DSW].Cabina as ca ON ca.ca_id_crucero = cr.cr_id
	WHERE (vi.v_fecha_llegada BETWEEN @fecha_desde AND @fecha_hasta
		AND vi.v_fecha_llegada BETWEEN @fecha_desde AND @fecha_hasta)
	AND ca.ca_id NOT IN (SELECT pa.pa_id_cabina FROM [DSW].Pasaje as pa WHERE pa.pa_id_viaje = vi.v_id)
	GROUP BY rc.rc_id, vi.v_id
	ORDER BY cantidad DESC
	;
END
GO

CREATE PROCEDURE [DSW].P_Top_Cruceros_Fuera_Servicio
	@fecha_desde datetime2,
	@fecha_hasta datetime2
AS
BEGIN 
	SELECT TOP 5 cr.cr_id, 
		(SELECT SUM(DATEDIFF(day, fs_fecha_inicio, fs_fecha_fin)) FROM [DSW].Fuera_Servicio_Crucero AS fsc 
		WHERE fsc.fs_id_crucero = cr.cr_id
		AND (fsc.fs_fecha_inicio BETWEEN @fecha_desde AND @fecha_hasta
		AND fsc.fs_fecha_fin BETWEEN @fecha_desde AND @fecha_hasta)) cantidad
		FROM [DSW].Crucero AS cr
	GROUP BY cr.cr_id
	ORDER BY cantidad DESC
END
GO

--------------------FIN CREACION DE SPS --------------------------------------------

print (CONCAT('INSERTS ', CONVERT(VARCHAR, GETDATE(), 114)))
--VARIABLES
DECLARE @fecha_actual datetime2(3) = GETDATE()

BEGIN TRANSACTION
BEGIN TRY
--Todos los insert se ejecutan con exito o ninguno, esto para que no queden relaciones rotas si se rompe 

--Rol
INSERT INTO [DSW].Rol VALUES 
('Administrador General',0),
('Cliente',0)

--Funcion
INSERT INTO [DSW].Funcion VALUES
('ABM ROL', 0),
('ABM USUARIO', 0),
('ABM PUERTO', 0),
('ABM RECORRIDO', 0),
('ABM CRUCERO', 0),
('ABM VIAJE', 0),
('COMPRAS Y RESERVAS', 0),
('PAGOS', 0),
('LISTADO ESTADISTICO', 0)

--Funcion_x_Rol
INSERT INTO [DSW].Funcion_x_Rol
SELECT
	f_id, r_id
FROM 
	[DSW].Rol,
	[DSW].Funcion
WHERE
	r_id = 1

INSERT INTO [DSW].Funcion_x_Rol
SELECT
	f_id, r_id
FROM 
	[DSW].Rol,
	[DSW].Funcion
WHERE
	r_id = 2
	AND f_descripcion IN ('COMPRAS Y RESERVAS', 'PAGOS')

--Usuario
INSERT INTO [DSW].Usuario VALUES
('admin', HASHBYTES('SHA2_256', CONVERT(nvarchar(50), 'w23e')), 0, 0),
('clienteGenerico', HASHBYTES('SHA2_256', CONVERT(nvarchar(50), 'w23e')), 0, 0)

--Rol_x_Usuario
INSERT INTO [DSW].Rol_x_Usuario
SELECT 
	u_id,
	r_id
FROM 
	[DSW].Usuario,
	[DSW].Rol
WHERE
	u_id = 1
	AND r_id = 1

INSERT INTO [DSW].Rol_x_Usuario
SELECT 
	u_id,
	r_id
FROM 
	[DSW].Usuario,
	[DSW].Rol
WHERE
	u_id = 2
	AND r_id = 2

--Puerto
INSERT INTO [DSW].Puerto
SELECT DISTINCT PUERTO_DESDE 
FROM gd_esquema.Maestra m1
UNION 
SELECT PUERTO_HASTA
FROM gd_esquema.Maestra m1

--Tramo
;WITH tramo_maestra as(SELECT DISTINCT PUERTO_DESDE as desde, PUERTO_HASTA as hasta, RECORRIDO_PRECIO_BASE precio FROM gd_esquema.Maestra)
INSERT INTO DSW.Tramo
SELECT
	p_desde.pt_id,
	p_hasta.pt_id,
	precio
FROM
	tramo_maestra 
	INNER JOIN DSW.Puerto as p_desde ON p_desde.pt_descripcion = desde
	INNER JOIN DSW.Puerto as p_hasta ON p_hasta.pt_descripcion = hasta

--Recorrido
INSERT INTO [DSW].Recorrido VALUES 
('43820864',0),
('43820865',0),
('43820866',0),
('43820867',0),
('43820868',0),
('43820869',0),
('43820870',0),
('43820871',0),
('43820872',0),
('43820873',0),
('43820874',0),
('43820875',0),
('43820876',0),
('43820877',0),
('43820878',0),
('43820879',0),
('43820880',0),
('43820881',0),
('43820882',0),
('43820883',0),
('43820884',0),
('43820885',0),
('43820886',0),
('43820887',0),
('43820888',0),
('43820889',0),
('43820890',0),
('43820891',0),
('43820892',0),
('43820893',0),
('43820894',0),
('43820895',0),
('43820896',0),
('43820897',0),
('43820898',0),
('43820899',0),
('43820900',0),
('43820901',0),
('43820902',0),
('43820903',0),
('43820904',0),
('43820905',0),
('43820906',0),
('43820907',0),
('43820908',0)

--Reoccidos_x_tramos
DECLARE @recorrido TABLE (cod decimal(18,0), desde nvarchar(510), hasta nvarchar(510))

INSERT INTO @recorrido
SELECT DISTINCT RECORRIDO_CODIGO cod, PUERTO_DESDE desde, PUERTO_HASTA hasta FROM gd_esquema.Maestra

INSERT INTO DSW.Recorridos_x_tramos
SELECT r1.cod, (SELECT t_id FROM DSW.Tramo INNER JOIN DSW.Puerto desde ON t_id_origen = desde.pt_id INNER JOIN DSW.Puerto hasta ON t_id_destino = hasta.pt_id WHERE desde.pt_descripcion = r2.desde AND hasta.pt_descripcion = r2.hasta ), 2 FROM @recorrido r1 INNER JOIN @recorrido r2 ON r1.hasta = r2.desde WHERE r1.cod = r2.cod ORDER BY 2

INSERT INTO DSW.Recorridos_x_tramos
SELECT r1.cod, (SELECT t_id FROM DSW.Tramo INNER JOIN DSW.Puerto desde ON t_id_origen = desde.pt_id INNER JOIN DSW.Puerto hasta ON t_id_destino = hasta.pt_id WHERE desde.pt_descripcion = r1.desde AND hasta.pt_descripcion = r1.hasta ), 1 FROM @recorrido r1 INNER JOIN @recorrido r2 ON r1.hasta = r2.desde WHERE r1.cod = r2.cod ORDER BY 2

INSERT INTO DSW.Recorridos_x_tramos
SELECT DISTINCT RECORRIDO_CODIGO cod, (SELECT t_id FROM DSW.Tramo INNER JOIN DSW.Puerto desde ON t_id_origen = desde.pt_id INNER JOIN DSW.Puerto hasta ON t_id_destino = hasta.pt_id WHERE desde.pt_descripcion = PUERTO_DESDE AND hasta.pt_descripcion = PUERTO_HASTA ) , 1 FROM gd_esquema.Maestra WHERE RECORRIDO_CODIGO IN (43820864,43820908)

--Tipo_cabina
INSERT INTO DSW.Tipo_cabina
SELECT DISTINCT CABINA_TIPO, CABINA_TIPO_PORC_RECARGO FROM gd_esquema.Maestra

-- Marca/Fabricante
INSERT INTO DSW.Marca
SELECT DISTINCT CRU_FABRICANTE FROM gd_esquema.Maestra

--Crucero
INSERT INTO DSW.Crucero
SELECT DISTINCT 
	CRUCERO_IDENTIFICADOR, 
	CRUCERO_MODELO, 
	(select m_id from DSW.Marca where m_descripcion = CRU_FABRICANTE),
	@fecha_actual,
	0,
	NULL
FROM gd_esquema.Maestra

--Cabina
INSERT INTO DSW.Cabina
SELECT DISTINCT 
	CABINA_NRO, 
	CABINA_PISO, 
	0,
	(SELECT cr_id FROM DSW.Crucero WHERE cr_codigo = CRUCERO_IDENTIFICADOR),
	(SELECT tc_id FROM DSW.Tipo_cabina WHERE tc_descripcion = RTRIM(LTRIM(CABINA_TIPO))) 
FROM 
	gd_esquema.Maestra 

--Viaje
INSERT INTO DSW.Viaje
SELECT DISTINCT 
	(SELECT cr_id FROM DSW.Crucero WHERE cr_codigo = CRUCERO_IDENTIFICADOR) , 
	CONVERT(decimal(18,0),RECORRIDO_CODIGO), 
	FECHA_SALIDA, 
	FECHA_LLEGADA, 
	FECHA_LLEGADA_ESTIMADA 
FROM 
	gd_esquema.Maestra

--Cliente
SELECT CLI_DNI INTO #cliente_inconsistente FROM (SELECT DISTINCT CLI_NOMBRE, CLI_APELLIDO, CLI_DNI FROM gd_esquema.Maestra) M_AUX GROUP BY CLI_DNI HAVING COUNT(1) > 1

INSERT INTO DSW.Cliente
SELECT DISTINCT ma.CLI_NOMBRE, ma.CLI_APELLIDO, ma.CLI_DNI, ma.CLI_DIRECCION, ma.CLI_TELEFONO, ma.CLI_MAIL, ma.CLI_FECHA_NAC, ISNULL((SELECT TOP 1 1 FROM #cliente_inconsistente ci WHERE ci.CLI_DNI = ma.CLI_DNI), 0) FROM gd_esquema.Maestra ma 

DROP TABLE #cliente_inconsistente

--Medio_Pago
INSERT INTO DSW.Medio_Pago
VALUES('EFECTIVO'), ('CR�DITO'), ('D�BITO')

---- Pasaje
CREATE TABLE #main(
	[CRUCERO_IDENTIFICADOR] [nvarchar](50) NULL,
	[RECORRIDO_CODIGO] [decimal](18, 0) NULL,
	[FECHA_SALIDA] [datetime2](3) NULL,
	[FECHA_LLEGADA] [datetime2](3) NULL,
	[FECHA_LLEGADA_ESTIMADA] [datetime2](3) NULL,

	[CABINA_NRO] [decimal](18, 0) NULL,
	[CABINA_PISO] [decimal](18, 0) NULL,
	[CABINA_TIPO] [nvarchar](255) NULL,

	[CLI_NOMBRE] [nvarchar](255) NULL,
	[CLI_APELLIDO] [nvarchar](255) NULL,
	[CLI_DNI] [decimal](18, 0) NULL,

	[PASAJE_CODIGO] [decimal](18, 0) NULL,
	[PASAJE_FECHA_COMPRA] [datetime2](3) NULL,
	[PASAJE_PRECIO] [decimal](18, 2) NULL,
		
	[RESERVA_CODIGO] [decimal](18, 0) NULL,
	[RESERVA_FECHA] [datetime2](3) NULL,

	id_crucero int null,
	id_viaje int null, 
	id_cabina int null,
	id_reserva int null,
	id_cliente int null,
	id_pago int null
)

INSERT INTO #main
SELECT 
	CRUCERO_IDENTIFICADOR , 
	RECORRIDO_CODIGO, 
	FECHA_SALIDA, 
	FECHA_LLEGADA, 
	FECHA_LLEGADA_ESTIMADA,

	CABINA_NRO, 
	CABINA_PISO,
	CABINA_TIPO,

	CLI_NOMBRE,
	CLI_APELLIDO,
	CLI_DNI,

	PASAJE_CODIGO,
	PASAJE_FECHA_COMPRA,
	PASAJE_PRECIO,

	RESERVA_CODIGO,
	RESERVA_FECHA,
	0,
	0,
	0,
	0,
	0,
	0
FROM 
	gd_esquema.Maestra;

-- crucero
update m
set m.id_crucero = c.cr_id
from #main as m
inner join DSW.Crucero as c
	on m.CRUCERO_IDENTIFICADOR = c.cr_codigo;

-- viaje
update m
set m.id_viaje = v.v_id
from #main as m
inner join DSW.Viaje as v
	on m.RECORRIDO_CODIGO = v.v_id_recorrido
	and m.FECHA_SALIDA = v.v_fecha_salida
	and m.FECHA_LLEGADA = v.v_fecha_llegada
	and m.FECHA_LLEGADA_ESTIMADA = v.v_fecha_llegada_estimada
	and m.id_crucero = v.v_id_crucero;
 
 -- cabina
 update m
set m.id_cabina = c.ca_id
from #main as m
inner join DSW.Cabina as c
	on m.id_crucero = c.ca_id_crucero
	and m.CABINA_NRO = c.ca_numero
	and m.CABINA_PISO = c.ca_piso
inner join DSW.Tipo_cabina as t
	on c.ca_id_tipo_cabina = t.tc_id
	and m.CABINA_TIPO = t.tc_descripcion;

-- cliente
update m
set m.id_cliente = cl.c_id
from #main as m
inner join DSW.Cliente as cl
	on m.CLI_APELLIDO = cl.c_apellido
	and m.CLI_DNI = cl.c_dni
	and m.CLI_NOMBRE = cl.c_nombre;


-- pagos insert
INSERT INTO DSW.Pago
select 
	PASAJE_PRECIO,
	PASAJE_FECHA_COMPRA,
	1,
	id_cliente,
	1
from #main
where PASAJE_CODIGO IS NOT NULL;

-- pagos update
update m
set m.id_pago = p.p_id
from #main as m
inner join DSW.Pago as p
	on m.id_cliente = p.p_id_cliente
	and m.PASAJE_PRECIO = p.p_total
	and m.PASAJE_FECHA_COMPRA = p.p_fecha_compra;

-- reservas insert
INSERT INTO DSW.Reserva
select 
--RESERVA_CODIGO,
RESERVA_FECHA,
0,-- porque las reservas ya se pagaron y no vencieron
id_cliente
from #main
where RESERVA_CODIGO IS NOT NULL
order by RESERVA_CODIGO;

-- pasajes insert
INSERT INTO DSW.Pasaje
select 
	MAX(PASAJE_PRECIO),
	id_viaje,
	id_cabina,
	MAX(RESERVA_CODIGO),
	id_cliente,
	MAX(id_pago)
from #main
group by 
	id_viaje,
	id_cabina,
	id_cliente
order by MAX(PASAJE_CODIGO);

drop table #main

END TRY
BEGIN CATCH
	SELECT  
	  ERROR_NUMBER() AS ErrorNumber  
    , ERROR_SEVERITY() AS ErrorSeverity  
    , ERROR_STATE() AS ErrorState  
    , ERROR_PROCEDURE() AS ErrorProcedure  
    , ERROR_LINE() AS ErrorLine  
    , ERROR_MESSAGE() AS ErrorMessage;  
	ROLLBACK TRANSACTION
END CATCH

IF @@TRANCOUNT > 0  
    COMMIT TRANSACTION;  
GO  

--------------------FIN DE INSERTS --------------------------------------------

print (CONCAT('FKS, INDICES Y CONSTRAINS ', CONVERT(VARCHAR, GETDATE(), 114)))

-- USUARIO Y SEGURIDAD
ALTER TABLE [DSW].[Funcion_x_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Funcion_x_Rol_Funcion] FOREIGN KEY([fxr_id_funcion])
REFERENCES [DSW].[Funcion] ([f_id])
GO

ALTER TABLE [DSW].[Funcion_x_Rol] CHECK CONSTRAINT [FK_Funcion_x_Rol_Funcion]
GO

ALTER TABLE [DSW].[Funcion_x_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Funcion_x_Rol_Rol] FOREIGN KEY([fxr_id_rol])
REFERENCES [DSW].[Rol] ([r_id])
GO

ALTER TABLE [DSW].[Funcion_x_Rol] CHECK CONSTRAINT [FK_Funcion_x_Rol_Rol]
GO

ALTER TABLE [DSW].[Rol_x_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_x_Usuario_Rol] FOREIGN KEY([rxu_id_rol])
REFERENCES [DSW].[Rol] ([r_id])
GO

ALTER TABLE [DSW].[Rol_x_Usuario] CHECK CONSTRAINT [FK_Rol_x_Usuario_Rol]
GO

ALTER TABLE [DSW].[Rol_x_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_x_Usuario_Usuario] FOREIGN KEY([rxu_id_usuario])
REFERENCES [DSW].[Usuario] ([u_id])
GO

ALTER TABLE [DSW].[Rol_x_Usuario] CHECK CONSTRAINT [FK_Rol_x_Usuario_Usuario]
GO

-- NEGOCIO
ALTER TABLE [DSW].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Crucero] FOREIGN KEY([v_id_crucero])
REFERENCES [DSW].[Crucero] ([cr_id])
GO

ALTER TABLE [DSW].[Viaje] CHECK CONSTRAINT [FK_Viaje_Crucero]
GO

ALTER TABLE [DSW].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Recorrido] FOREIGN KEY([v_id_recorrido])
REFERENCES [DSW].[Recorrido] ([rc_id])
GO

ALTER TABLE [DSW].[Viaje] CHECK CONSTRAINT [FK_Viaje_Recorrido]
GO

ALTER TABLE [DSW].[Tramo]  WITH CHECK ADD  CONSTRAINT [FK_Tramo_Puerto] FOREIGN KEY([t_id_origen])
REFERENCES [DSW].[Puerto] ([pt_id])
GO

ALTER TABLE [DSW].[Tramo] CHECK CONSTRAINT [FK_Tramo_Puerto]
GO

ALTER TABLE [DSW].[Tramo]  WITH CHECK ADD  CONSTRAINT [FK_Tramo_Puerto1] FOREIGN KEY([t_id_destino])
REFERENCES [DSW].[Puerto] ([pt_id])
GO

ALTER TABLE [DSW].[Tramo] CHECK CONSTRAINT [FK_Tramo_Puerto1]
GO

ALTER TABLE [DSW].[Recorridos_x_tramos]  WITH CHECK ADD  CONSTRAINT [FK_Recorridos_x_tramos_Recorrido] FOREIGN KEY([rxt_id_recorrido])
REFERENCES [DSW].[Recorrido] ([rc_id])
GO

ALTER TABLE [DSW].[Recorridos_x_tramos] CHECK CONSTRAINT [FK_Recorridos_x_tramos_Recorrido]
GO

ALTER TABLE [DSW].[Recorridos_x_tramos]  WITH CHECK ADD  CONSTRAINT [FK_Recorridos_x_tramos_Tramo] FOREIGN KEY([rxt_id_tramo])
REFERENCES [DSW].[Tramo] ([t_id])
GO

ALTER TABLE [DSW].[Recorridos_x_tramos] CHECK CONSTRAINT [FK_Recorridos_x_tramos_Tramo]
GO

ALTER TABLE [DSW].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Cabina] FOREIGN KEY([pa_id_cabina])
REFERENCES [DSW].[Cabina] ([ca_id])
GO

ALTER TABLE [DSW].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Cabina]
GO

ALTER TABLE [DSW].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Cliente] FOREIGN KEY([pa_id_cliente])
REFERENCES [DSW].[Cliente] ([c_id])
GO

ALTER TABLE [DSW].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Cliente]
GO

ALTER TABLE [DSW].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Pago] FOREIGN KEY([pa_id_pago])
REFERENCES [DSW].[Pago] ([p_id])
GO

ALTER TABLE [DSW].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Pago]
GO

ALTER TABLE [DSW].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Reserva] FOREIGN KEY([pa_id_reserva])
REFERENCES [DSW].[Reserva] ([r_codigo])
GO

ALTER TABLE [DSW].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Reserva]
GO

ALTER TABLE [DSW].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Viaje] FOREIGN KEY([pa_id_viaje])
REFERENCES [DSW].[Viaje] ([v_id])
GO

ALTER TABLE [DSW].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Viaje]
GO

ALTER TABLE [DSW].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Medio_Pago] FOREIGN KEY([p_id_medio_pago])
REFERENCES [DSW].[Medio_Pago] ([mp_id])
GO

ALTER TABLE [DSW].[Pago] CHECK CONSTRAINT [FK_Pago_Medio_Pago]
GO

ALTER TABLE [DSW].[Cabina]  WITH CHECK ADD  CONSTRAINT [FK_Cabina_Crucero] FOREIGN KEY([ca_id_crucero])
REFERENCES [DSW].[Crucero] ([cr_id])
GO

ALTER TABLE [DSW].[Cabina] CHECK CONSTRAINT [FK_Cabina_Crucero]
GO

ALTER TABLE [DSW].[Cabina]  WITH CHECK ADD  CONSTRAINT [FK_Cabina_Tipo_cabina] FOREIGN KEY([ca_id_tipo_cabina])
REFERENCES [DSW].[Tipo_cabina] ([tc_id])
GO

ALTER TABLE [DSW].[Cabina] CHECK CONSTRAINT [FK_Cabina_Tipo_cabina]
GO

ALTER TABLE [DSW].[Crucero]  WITH CHECK ADD  CONSTRAINT [FK_Crucero_Marca] FOREIGN KEY([cr_id_marca])
REFERENCES [DSW].[Marca] ([m_id])
GO

ALTER TABLE [DSW].[Crucero] CHECK CONSTRAINT [FK_Crucero_Marca]
GO

ALTER TABLE [DSW].[Fuera_Servicio_Crucero]  WITH CHECK ADD CONSTRAINT [FK_Fuera_Servicio_Crucero] FOREIGN KEY([fs_id_crucero])
REFERENCES [DSW].[Crucero] ([cr_id])
GO

ALTER TABLE [DSW].[Fuera_Servicio_Crucero] CHECK CONSTRAINT [FK_Fuera_Servicio_Crucero]
GO

--------------- FKS, INDICES Y CONSTRAINS ------------------
print (CONCAT('Fin del Script Inicial', CONVERT(VARCHAR, GETDATE(), 114)))