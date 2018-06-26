/* 07. Employees & Reports */
USE [ReportService]
GO

	   SELECT e.FirstName, e.LastName, r.Description, FORMAT(r.OpenDate, 'yyyy-MM-dd') AS [OpenDate]
	     FROM Reports AS r
 INNER JOIN Employees AS e ON e.Id = r.EmployeeId
	    WHERE r.EmployeeId IS NOT NULL
   ORDER BY e.Id ASC, r.OpenDate ASC, r.Id ASC