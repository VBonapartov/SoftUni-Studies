/* 15. Average Closing Time */
USE [ReportService]
GO

	  SELECT d.Name AS [Department Name], 
		       CASE
			       WHEN CAST(AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS VARCHAR(20)) IS NULL THEN 'no info'
			       ELSE CAST(AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS VARCHAR(20))
	         END AS [Average Duration]
	    FROM Departments AS d
INNER JOIN Categories AS c ON c.DepartmentId = d.Id
INNER JOIN Reports AS r ON r.CategoryId = c.Id
  GROUP BY d.Name
  ORDER BY d.Name ASC