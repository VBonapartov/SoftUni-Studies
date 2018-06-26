/* 03. Update */
USE [ReportService]
GO

UPDATE Reports
   SET StatusId = 2
 WHERE StatusId = 1 AND CategoryId = 4
