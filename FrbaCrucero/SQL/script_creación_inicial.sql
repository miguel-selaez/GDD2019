USE GD1C2019;
GO

CREATE SCHEMA DSW; 
GO

print (CONCAT('Creacion de tablas ', CONVERT(VARCHAR, GETDATE(), 114)))

CREATE TABLE [DSW].[Puerto] (
  [pt_id] int,
  [pt_descripcion] nvarchar(255),
  PRIMARY KEY ([pt_id])
);

GO

CREATE TABLE [DSW].[Tramo] (
  [t_id] int,
  [t_id_origen] int,
  [t_id_destino] int,
  [t_precio] decimal(18,2),
  PRIMARY KEY ([t_id])
);

GO

CREATE TABLE [DSW].[Recorrido] (
  [rc_id] int,
  [rc_codigo] char(20), -- Verificar el tipo en el enunciado
  [rc_baja] bit,
  PRIMARY KEY ([rc_id])
);

GO

CREATE TABLE [DSW].[Recorridos_x_tramos] (
  [rxt_id_recorrido] int,
  [rxt_id_tramo] int,
  [rxt_orden] int,
  PRIMARY KEY ([rxt_id_recorrido], [rxt_id_tramo], [rxt_orden])
);

GO

CREATE TABLE [DSW].[Pago] (
  [p_id] int,
  [p_cant_cuotas] int,
  [p_cuotas_pagas] int,
  [p_total_pagado] decimal(18,2),
  [p_id_cliente] int,
  [p_id_medio_pago] int,
  PRIMARY KEY ([p_id])
);

GO

CREATE TABLE [DSW].[Viaje] (
  [v_id] int,
  [v_id_crucero] int,
  [v_id_recorrido] int,
  [v_fecha_salida] datetime2(3),
  [v_fecha_llegada] datetime2(3),
  [v_fecha_llegada_estimada] datetime2(3),
  PRIMARY KEY ([v_id])
);

GO

CREATE TABLE [DSW].[Cliente] (
  [c_id] int,
  [c_nombre] nvarchar(255),
  [c_apellido] nvarchar(255),
  [c_dni] decimal(18,0),
  [c_direccion] nvarchar(255),
  [c_telefono] int,
  [c_mail] nvarchar(255),
  [c_fecha_nacimiento] datetime2(3),
  PRIMARY KEY ([c_id])
);

GO

CREATE TABLE [DSW].[Pasaje] (
  [pa_codigo] decimal(18,0),
  [pa_fecha_compra] datetime2(3),
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
  [cr_id] int,
  [cr_codigo] nvarchar(50),
  [cr_modelo] nvarchar(50),
  [cr_fabricante] nvarchar(255),
  [cr_fecha_alta] datetime2(3),
  [cr_baja] bit,
  [cr_fecha_fuera_servicio] datetime2(3),
  [cr_fecha_reinicio_servicio] datetime2(3),
  [cr_fecha_baja_definitiva] datetime2(3),
  PRIMARY KEY ([cr_id])
);

GO

CREATE TABLE [DSW].[Cabina] (
  [ca_id] int,
  [ca_numero] decimal(18,0),
  [ca_piso] decimal(18,0),
  [ca_id_crucero] int,
  [ca_id_tipo_cabina] int,
  PRIMARY KEY ([ca_id])
);

GO

CREATE TABLE [DSW].[Tipo_cabina] (
  [tc_id] int,
  [tc_descripcion] nvarchar(255),
  [tc_porcentaje_recargo] decimal(18,2),
  PRIMARY KEY ([tc_id])
);

GO

CREATE TABLE [DSW].[Medio_Pago] (
  [mp_id] int,
  [mp_descripcion] nvarchar(100),
  PRIMARY KEY ([mp_id])
);

GO

CREATE TABLE [DSW].[Reserva] (
  [r_codigo] decimal(18,0),
  [r_fecha] datetime2(3),
  [r_estado] bit,
  [r_id_cliente] int,
  PRIMARY KEY ([r_codigo])
);

GO

CREATE TABLE [DSW].[Funcion] (
  [f_id] int,
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
  [r_id] int,
  [r_descripcion] nvarchar(100),
  [r_baja] bit,
  PRIMARY KEY ([r_id])
);

GO

CREATE TABLE [DSW].[Usuario] (
  [u_id] int,
  [u_nombre_usuario] nvarchar(100),
  [u_password] varbinary,
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




--------------------FIN CREACION DE SPS --------------------------------------------

print (CONCAT('INSERTS ', CONVERT(VARCHAR, GETDATE(), 114)))

--BEGIN TRY
--BEGIN TRANSACTION

-- Todos los insert se ejecutan con exito o ninguno, esto para que no queden relaciones rotas si se rompe 

--COMMIT TRANSACTION

--END TRY
--BEGIN CATCH
--	SELECT  
--    ERROR_NUMBER() AS ErrorNumber  
--    ,ERROR_SEVERITY() AS ErrorSeverity  
--    ,ERROR_STATE() AS ErrorState  
--    ,ERROR_PROCEDURE() AS ErrorProcedure  
--    ,ERROR_LINE() AS ErrorLine  
--    ,ERROR_MESSAGE() AS ErrorMessage;  
--	ROLLBACK TRANSACTION
--END CATCH
--GO

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


--------------- FKS, INDICES Y CONSTRAINS ------------------
print (CONCAT('Fin del Script Inicial', CONVERT(VARCHAR, GETDATE(), 114)))