/* 10. Find Names of All Employees */
USE [SoftUni]
GO

SELECT CONCAT(FirstName, ' ',  MiddleName, ' ', LastName) AS [Full Name]
  FROM Employees
 WHERE Salary IN (25000, 14000, 12500, 23600);