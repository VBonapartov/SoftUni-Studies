/* 17. Employees Load */
USE [ReportService]
GO

CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
	DECLARE @reportsCount INT =
	(
		SELECT COUNT(*)
		  FROM Reports
		 WHERE EmployeeId = @employeeId AND StatusId = @statusId
	)

	RETURN @reportsCount;
END

-- Example
  SELECT Id, 
		     FirstName, 
		     Lastname, 
		     dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
    FROM Employees
ORDER BY Id
