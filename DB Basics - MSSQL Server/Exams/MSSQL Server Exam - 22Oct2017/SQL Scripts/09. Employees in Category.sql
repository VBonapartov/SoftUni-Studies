/* 09. Employees in Category */
USE [ReportService]
GO

		     SELECT c.Name AS CategoryName, 
				        ISNULL(COUNT(e.Id), 0) AS [Employees Number] 
		       FROM Categories AS c
LEFT OUTER JOIN Departments AS d ON d.Id = c.DepartmentId
LEFT OUTER JOIN Employees AS e ON e.DepartmentId = d.Id
	     GROUP BY c.Name
	     ORDER BY c.Name
