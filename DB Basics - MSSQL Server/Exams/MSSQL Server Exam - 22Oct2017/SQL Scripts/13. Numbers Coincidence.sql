/* 13. Numbers Coincidence */
USE [ReportService]
GO

	  SELECT DISTINCT u.Username
	    FROM Users AS u
INNER JOIN Reports AS r ON  r.UserId = u.Id
INNER JOIN Categories AS c ON c.Id = r.CategoryId
	   WHERE (ISNUMERIC(LEFT(u.Username, 1)) = 1 AND
		        TRY_CAST(LEFT(u.Username, 1) AS INT) = c.Id) OR
		       (ISNUMERIC(RIGHT(RTRIM(u.Username), 1)) = 1 AND
		        TRY_CAST(RIGHT(u.Username, 1) AS INT) = c.Id)
  ORDER BY u.Username ASC
