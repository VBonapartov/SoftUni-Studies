/* 11. Find All Employees Without Manager */
USE [SoftUni]
GO

SELECT FirstName, LastName
  FROM Employees
 WHERE ManagerID IS NULL;