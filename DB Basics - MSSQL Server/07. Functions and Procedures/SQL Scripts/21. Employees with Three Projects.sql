/* 21. Employees with Three Projects */
USE [SoftUni]
GO

CREATE PROCEDURE usp_AssignProject(@employeeID INT, @projectID INT)
AS
BEGIN

	IF(@employeeID IS NULL OR @projectID IS NULL)
	BEGIN
		RAISERROR('Missing value', 16, 1); 
		RETURN;
	END

	BEGIN TRANSACTION

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID) 
       VALUES (@employeeID, @projectID);
	
	IF(@@ROWCOUNT < 1)
	BEGIN
		ROLLBACK;
		RAISERROR('EmployeeID or ProjectID is incorrect', 16, 1); 
		RETURN;	
	END
	
	DECLARE @EmployeeProjectCount INT;
	SET @EmployeeProjectCount = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @employeeID);	

	IF(@EmployeeProjectCount > 3)
	BEGIN
		ROLLBACK;
		RAISERROR('The employee has too many projects!', 16, 1);
		RETURN;
	END;

	COMMIT TRANSACTION;
END

EXEC dbo.usp_AssignProject 1, 1;