/* 04. Find All Employees Except Engineers */
USE [SoftUni]
GO

SELECT FirstName, LastName
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'