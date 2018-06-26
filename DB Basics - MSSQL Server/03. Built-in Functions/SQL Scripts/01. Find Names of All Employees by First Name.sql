/* 01. Find Names of All Employees by First Name */
USE [SoftUni]
GO

SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'SA%';