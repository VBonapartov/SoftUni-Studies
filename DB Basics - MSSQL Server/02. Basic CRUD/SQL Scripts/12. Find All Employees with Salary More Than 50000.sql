/* 12. Find All Employees with Salary More Than 50000 */
USE [SoftUni]
GO

  SELECT FirstName, LastName, Salary
    FROM Employees
   WHERE Salary > 50000
ORDER BY Salary DESC;