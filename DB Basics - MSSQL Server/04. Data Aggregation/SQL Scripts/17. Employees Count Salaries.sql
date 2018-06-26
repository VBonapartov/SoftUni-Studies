/* 17. Employees Count Salaries */
USE [SoftUni]
GO

SELECT COUNT(Salary)
  FROM Employees
 WHERE ManagerID IS NULL; 