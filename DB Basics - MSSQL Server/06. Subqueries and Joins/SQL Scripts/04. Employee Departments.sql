/* 04. Employee Departments */
USE [SoftUni]
GO

    SELECT TOP(5)
    		   e.EmployeeID,
    		   e.FirstName, 
    		   e.Salary,
    		   d.Name AS [DepartmentName]
      FROM Employees AS e
INNER JOIN Departments AS d 
        ON d.DepartmentID = e.DepartmentID
	   WHERE e.Salary > 15000
  ORDER BY e.DepartmentID;