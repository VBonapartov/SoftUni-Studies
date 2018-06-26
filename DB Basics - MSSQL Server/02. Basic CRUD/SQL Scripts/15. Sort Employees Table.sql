/* 15. Sort Employees Table */
USE [SoftUni]
GO

  SELECT *
    FROM Employees
ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC;