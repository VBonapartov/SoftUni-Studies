/* 14. Open/Closed Statistics */
USE [ReportService]
GO

WITH 
	CTE_EmployeeOpenReports (EmployeeId, OpenReports)
	AS
	(
			  SELECT e.Id, COUNT(r.Id) 
			    FROM Employees AS e
		INNER JOIN Reports AS r ON e.Id = r.EmployeeId
			   WHERE DATEPART(YEAR, r.OpenDate) = 2016
		  GROUP BY e.Id
	),

	CTE_EmployeeClosedReports (EmployeeId, ClosedReports)
	AS
	(
			  SELECT e.Id, COUNT(*)
			    FROM Employees AS e
		INNER JOIN Reports AS r ON r.EmployeeId = e.Id
			   WHERE DATEPART(YEAR, r.CloseDate) = 2016
		  GROUP BY e.Id
	)

	  SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Name,
		       CONCAT(ISNULL(ecr.ClosedReports, 0), '/', ISNULL(eor.OpenReports, 0))
	    FROM CTE_EmployeeClosedReports AS ecr 
 FULL JOIN CTE_EmployeeOpenReports AS eor ON eor.EmployeeId = ecr.EmployeeId
INNER JOIN Employees AS e ON e.Id = ecr.EmployeeId OR e.Id = eor.EmployeeId
  ORDER BY Name ASC, e.Id ASC


