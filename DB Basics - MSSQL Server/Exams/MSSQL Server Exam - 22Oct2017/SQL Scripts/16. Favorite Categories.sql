/* 16. Favorite Categories */
USE [ReportService]
GO

WITH 
	CTE_TotalReportsByDepartment (DepartmentId, TotalReports) AS
	(
			  SELECT d.Id, 
				       COUNT(r.Id) 
			    FROM Departments AS d
		INNER JOIN Categories AS c ON c.DepartmentId = d.Id
		INNER JOIN Reports AS r ON r.CategoryId = c.Id
		  GROUP BY d.Id
	)

	  SELECT d.Name AS [Department Name], 
		       c.Name AS [Category Name], 
		       CAST(ROUND(CEILING(CAST(COUNT(r.Id) AS DECIMAL(7,2)) * 100)/tr.TotalReports, 0) AS INT) AS Percentage 
	    FROM Departments AS d
INNER JOIN CTE_TotalReportsByDepartment AS tr ON tr.DepartmentId = d.Id
INNER JOIN Categories AS c ON c.DepartmentId = d.Id
INNER JOIN Reports AS r ON r.CategoryId = c.Id
  GROUP BY d.Name, c.Name, tr.TotalReports
  ORDER BY [Department Name] ASC, [Category Name] ASC, [Percentage] ASC