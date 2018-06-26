/* 20. Categories Revision */
USE [ReportService]
GO

WITH 
	CTE_MostCommonProgress (CategoryId, ProgressReports) AS
	(
			SELECT c.Id AS CategoryId, 
				   CASE
					   WHEN COUNT(r.StatusId) = 0 THEN NULL
					   ELSE COUNT(r.StatusId)
				   END AS ProgressReports 
			  FROM Categories AS c
		INNER JOIN Reports AS r ON r.CategoryId = c.Id
		INNER JOIN Status AS s ON s.Id = r.StatusId
			 WHERE s.Label = 'in progress'
		  GROUP BY c.Id
	),

	CTE_MostCommonWaiting (CategoryId, WaitingReports) AS
	(
			SELECT c.Id AS CategoryId,
				   CASE
					   WHEN COUNT(r.StatusId) = 0 THEN NULL
					   ELSE COUNT(r.StatusId)
				   END AS WaitingReports 
			  FROM Categories AS c
		INNER JOIN Reports AS r ON c.Id = r.CategoryId
		INNER JOIN Status AS s ON s.Id = r.StatusId
			 WHERE s.Label = 'waiting'
		  GROUP BY c.Id
	)

		 SELECT c.Name AS [Category Name],
				ISNULL(SUM(cp.ProgressReports), 0) + ISNULL(SUM(cw.WaitingReports), 0) AS [Reports Number],
				CASE
					WHEN ISNULL(SUM(cp.ProgressReports), 0) > ISNULL(SUM(cw.WaitingReports), 0) THEN 'in progress'
					WHEN ISNULL(SUM(cp.ProgressReports), 0) < ISNULL(SUM(cw.WaitingReports), 0) THEN 'waiting'
					ELSE 'equal'
				END [Main Status]
		   FROM Categories AS c
LEFT OUTER JOIN CTE_MostCommonProgress as cp ON cp.CategoryId = c.Id
LEFT OUTER JOIN CTE_MostCommonwaiting as cw ON cw.CategoryId = c.Id
	   GROUP BY c.Id, c.Name
		 HAVING ISNULL(SUM(cp.ProgressReports), 0) + ISNULL(SUM(cw.WaitingReports), 0) > 0
	   ORDER BY c.Name, [Reports Number], [Main Status]



