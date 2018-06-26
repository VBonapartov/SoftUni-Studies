/* 02. Find Names of All employees by Last Name */
USE [SoftUni]
GO

SELECT FirstName, LastName
  FROM Employees
 WHERE LastName LIKE '%ei%';