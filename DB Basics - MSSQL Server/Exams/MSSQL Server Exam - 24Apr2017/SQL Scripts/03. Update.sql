/* 03. Update */
USE [WMS]
GO

UPDATE Jobs
   SET MechanicId = 3, Status = 'In Progress'
 WHERE Status = 'Pending'
