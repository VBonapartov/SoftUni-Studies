/* 11. Emergency Patrol */
USE [ReportService]
GO

	  SELECT r.OpenDate, 
		       r.Description, 
		       u.Email AS [Reporter Email]
	    FROM Users AS u
INNER JOIN Reports AS r ON u.Id = r.UserId
INNER JOIN Categories AS c ON r.CategoryId = c.Id
INNER JOIN Departments AS d ON c.DepartmentId = d.Id
	   WHERE r.CloseDate IS NULL AND 
		       LEN(r.Description) > 20 AND 
		       r.Description LIKE '%str%' AND 
		       d.Name IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
  ORDER BY r.OpenDate ASC, u.Email ASC, r.Id ASC