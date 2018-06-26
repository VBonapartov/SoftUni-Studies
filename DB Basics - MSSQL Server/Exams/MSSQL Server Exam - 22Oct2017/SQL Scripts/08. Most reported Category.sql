/* 08. Most reported Category */
USE [ReportService]
GO

	   SELECT c.Name AS CategoryName, 
			      COUNT(*) AS ReportsNumber
	     FROM Categories AS c
 INNER JOIN Reports AS r ON r.CategoryId = c.Id
   GROUP BY c.Name
   ORDER BY ReportsNumber DESC, CategoryName ASC
