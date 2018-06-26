/* 14. Find All Employees Except Marketing */
USE [SoftUni]
GO

SELECT FirstName, LastName
  FROM Employees
 WHERE DepartmentID <> 4;