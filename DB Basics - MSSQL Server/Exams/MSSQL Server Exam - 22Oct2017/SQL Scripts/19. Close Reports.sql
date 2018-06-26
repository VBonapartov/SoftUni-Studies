/* 19. Close Reports */
USE [ReportService]
GO

CREATE TRIGGER tr_CloseReport
ON Reports
AFTER UPDATE 
AS
BEGIN
	DECLARE @statusId INT = (SELECT Id FROM Status WHERE Label = 'completed')
	
	    UPDATE Reports
		   SET StatusId = @statusId
		  FROM deleted AS d
	INNER JOIN inserted AS i ON d.Id = i.Id
		 WHERE i.CloseDate IS NOT NULL		
END

-- Example
UPDATE Reports
   SET CloseDate = GETDATE()
 WHERE EmployeeId = 5;


