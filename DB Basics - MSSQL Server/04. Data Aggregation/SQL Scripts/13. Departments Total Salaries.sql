/* 13. Departments Total Salaries */
USE [SoftUni]
GO

  SELECT DepartmentID, SUM(Salary) AS [TotalSalary]
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID