USE GD2C2019;
GO

--CREATE SCHEMA MANG; 
--GO

print (CONCAT('Creacion de tablas ', CONVERT(VARCHAR, GETDATE(), 114)))



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



--------------- FKS, INDICES Y CONSTRAINS ------------------
print (CONCAT('Fin del Script Inicial', CONVERT(VARCHAR, GETDATE(), 114)))