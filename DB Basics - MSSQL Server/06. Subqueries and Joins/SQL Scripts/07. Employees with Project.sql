/* 07. Employees with Project */
USE [SoftUni]
GO

    SELECT TOP(5)
    		   e.EmployeeID,
    		   e.FirstName,
    		   p.Name AS [ProjectName]
      FROM Employees AS e
INNER JOIN EmployeesProjects AS ep 
        ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p 
        ON p.ProjectID = ep.ProjectID
	   WHERE p.StartDate > CONVERT(DATE, '13.08.2002', 103)
	     AND p.EndDate IS NULL
  ORDER BY e.EmployeeID;