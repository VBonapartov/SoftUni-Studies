/* 20. Last 7 Hired Employees */
USE [SoftUni]
GO

  SELECT TOP(7) FirstName, LastName, HireDate
    FROM Employees
ORDER BY HireDate DESC;