/* 03. Find First Names of All Employees */
USE [SoftUni]
GO

SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3, 10) AND 
	     DATEPART(YYYY, HireDate) BETWEEN 1995 AND 2005
