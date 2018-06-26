/* 13. Find 5 Best Paid Employees */
USE [SoftUni]
GO

  SELECT TOP(5) FirstName, LastName
    FROM Employees
ORDER BY Salary DESC;