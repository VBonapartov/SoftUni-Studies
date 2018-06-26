/* 06. Employees by Salary Level */
USE [SoftUni]
GO

CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(10))
AS
BEGIN
	SELECT e.FirstName AS [First Name], 
		     e.LastName AS [Last Name]
	  FROM Employees AS e
	 WHERE dbo.ufn_GetSalaryLevel(e.Salary) LIKE @SalaryLevel
END

EXEC dbo.usp_EmployeesBySalaryLevel 'High';

