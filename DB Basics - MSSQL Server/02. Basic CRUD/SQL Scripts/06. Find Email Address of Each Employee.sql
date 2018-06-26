/* 06. Find Email Address of Each Employee */
USE [SoftUni]
GO

SELECT FirstName + '.' + Lastname + '@softuni.bg' AS [Full Email Address]
  FROM Employees;