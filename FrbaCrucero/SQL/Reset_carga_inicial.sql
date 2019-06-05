USE GD1C2019;
GO
-- Borrado de FKS, INDICES Y CONSTRAINS del script de creacion
ALTER TABLE [DSW].[Funcion_x_Rol]  DROP CONSTRAINT [FK_Funcion_x_Rol_Funcion] 
GO
ALTER TABLE [DSW].[Funcion_x_Rol]  DROP CONSTRAINT [FK_Funcion_x_Rol_Rol] 
GO
ALTER TABLE [DSW].[Rol_x_Usuario]  DROP CONSTRAINT [FK_Rol_x_Usuario_Rol]
GO
ALTER TABLE [DSW].[Rol_x_Usuario]  DROP CONSTRAINT [FK_Rol_x_Usuario_Usuario] 
GO
ALTER TABLE [DSW].[Viaje]  DROP CONSTRAINT [FK_Viaje_Crucero] 
GO
ALTER TABLE [DSW].[Viaje]  DROP CONSTRAINT [FK_Viaje_Recorrido] 
GO
ALTER TABLE [DSW].[Tramo]  DROP CONSTRAINT [FK_Tramo_Puerto] 
GO
ALTER TABLE [DSW].[Tramo]  DROP CONSTRAINT [FK_Tramo_Puerto1] 
GO
ALTER TABLE [DSW].[Recorridos_x_tramos]  DROP CONSTRAINT [FK_Recorridos_x_tramos_Recorrido] 
GO
ALTER TABLE [DSW].[Recorridos_x_tramos]  DROP CONSTRAINT [FK_Recorridos_x_tramos_Tramo] 
GO
ALTER TABLE [DSW].[Pasaje]  DROP CONSTRAINT [FK_Pasaje_Cabina] 
GO
ALTER TABLE [DSW].[Pasaje]  DROP CONSTRAINT [FK_Pasaje_Cliente] 
GO
ALTER TABLE [DSW].[Pasaje]  DROP CONSTRAINT [FK_Pasaje_Pago] 
GO
ALTER TABLE [DSW].[Pasaje]  DROP CONSTRAINT [FK_Pasaje_Reserva] 
GO
ALTER TABLE [DSW].[Pasaje]  DROP CONSTRAINT [FK_Pasaje_Viaje] 
GO
ALTER TABLE [DSW].[Pago]  DROP CONSTRAINT [FK_Pago_Medio_Pago] 
GO
ALTER TABLE [DSW].[Cabina]  DROP CONSTRAINT [FK_Cabina_Crucero] 
GO
ALTER TABLE [DSW].[Cabina]  DROP CONSTRAINT [FK_Cabina_Tipo_cabina] 
GO
ALTER TABLE [DSW].[Crucero]  DROP CONSTRAINT [FK_Crucero_Marca] 
GO


-- SPs
IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Funciones_x_Rol')
	DROP PROCEDURE [DSW].P_Obtener_Funciones_x_Rol
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Roles_x_Usuario')
	DROP PROCEDURE [DSW].P_Obtener_Roles_x_Usuario
GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Login')
	DROP PROCEDURE [DSW].P_Login
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Roles')
	DROP PROCEDURE [DSW].P_Obtener_Roles
GO 

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Funciones')
	DROP PROCEDURE [DSW].P_Obtener_Funciones
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Rol')
	DROP PROCEDURE [DSW].P_Guardar_Rol
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Funcion_x_Rol')
	DROP PROCEDURE [DSW].P_Guardar_Funcion_x_Rol
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Puerto')
	DROP PROCEDURE [DSW].P_Obtener_Puerto
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Tramos')
	DROP PROCEDURE [DSW].P_Obtener_Tramos
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Tramo_x_Recorrido')
	DROP PROCEDURE [DSW].P_Guardar_Tramo_x_Recorrido
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Tramos_x_Recorrido')
	DROP PROCEDURE [DSW].P_Obtener_Tramos_x_Recorrido
GO 

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Recorridos')
	DROP PROCEDURE [DSW].P_Obtener_Recorridos
GO 	

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Recorrido')
	DROP PROCEDURE [DSW].P_Guardar_Recorrido
GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Recorrido')
	DROP PROCEDURE [DSW].P_Obtener_Recorrido
GO 

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Marca')
	DROP PROCEDURE [DSW].P_Obtener_Marca
GO 

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Crucero')
	DROP PROCEDURE [DSW].P_Obtener_Crucero
GO 

--- TABLAS
-- Limpieza de datos (TRUNCATE)
TRUNCATE TABLE [DSW].Cabina
TRUNCATE TABLE [DSW].Cliente
TRUNCATE TABLE [DSW].Marca
TRUNCATE TABLE [DSW].Crucero
GO

TRUNCATE TABLE [DSW].Funcion
TRUNCATE TABLE [DSW].Funcion_x_Rol
TRUNCATE TABLE [DSW].Medio_Pago
GO

TRUNCATE TABLE [DSW].Pago
TRUNCATE TABLE [DSW].Pasaje
TRUNCATE TABLE [DSW].Puerto
TRUNCATE TABLE [DSW].Recorrido
GO
TRUNCATE TABLE [DSW].Recorridos_x_tramos
TRUNCATE TABLE [DSW].Reserva
TRUNCATE TABLE [DSW].Rol
GO
TRUNCATE TABLE [DSW].Rol_x_Usuario
TRUNCATE TABLE [DSW].Tipo_cabina
TRUNCATE TABLE [DSW].Tramo
GO
TRUNCATE TABLE [DSW].Usuario
TRUNCATE TABLE [DSW].Viaje
GO

-- Borrado de tablas (DROP)
DROP TABLE [DSW].Cabina
DROP TABLE [DSW].Cliente
DROP TABLE [DSW].Crucero
DROP TABLE [DSW].Marca
GO

DROP TABLE [DSW].Funcion
DROP TABLE [DSW].Funcion_x_Rol
DROP TABLE [DSW].Medio_Pago
GO

DROP TABLE [DSW].Pago
DROP TABLE [DSW].Pasaje
DROP TABLE [DSW].Puerto
DROP TABLE [DSW].Recorrido
GO
DROP TABLE [DSW].Recorridos_x_tramos
DROP TABLE [DSW].Reserva
DROP TABLE [DSW].Rol
GO
DROP TABLE [DSW].Rol_x_Usuario
DROP TABLE [DSW].Tipo_cabina
DROP TABLE [DSW].Tramo
GO
DROP TABLE [DSW].Usuario
DROP TABLE [DSW].Viaje
GO

-- Borrado de ESQUEMA (DROP)
DROP SCHEMA DSW; 
GO

