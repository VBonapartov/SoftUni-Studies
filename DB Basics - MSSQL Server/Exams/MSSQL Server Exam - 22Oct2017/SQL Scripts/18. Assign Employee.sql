/* 18. Assign Employee */
USE [ReportService]
GO

CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT) 
AS
BEGIN
	
	DECLARE @EmployeeDepartment INT = 
	(	
		SELECT e.DepartmentId 
		  FROM Employees AS e
		 WHERE e.Id = @employeeId
	)

	DECLARE @ReportDepartment INT =
	(
		    SELECT c.DepartmentId 
			    FROM Categories AS c
		INNER JOIN Reports AS r ON r.CategoryId = c.Id
		     WHERE r.Id = @reportId
	)

	IF (@EmployeeDepartment != @ReportDepartment)
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END

	UPDATE Reports
	   SET EmployeeId = @employeeId
	 WHERE Id = @reportId
	
END

-- Example
EXEC usp_AssignEmployeeToReport 17, 2;

SELECT EmployeeId 
  FROM Reports 
 WHERE id = 2

