/* 02. Employees with Salary Above Number */
USE [SoftUni]
GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber @MinSalary DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName AS [First Name], 
		     LastName AS [Last Name]
	  FROM Employees
	 WHERE Salary >= @MinSalary
END

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 100000;