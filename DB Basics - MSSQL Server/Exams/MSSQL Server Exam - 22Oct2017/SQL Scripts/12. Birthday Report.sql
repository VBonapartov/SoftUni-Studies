/* 12. Birthday Report */
USE [ReportService]
GO

	  SELECT DISTINCT c.Name AS [Category Name]
	    FROM Users AS u
INNER JOIN Reports AS r ON  r.UserId = u.Id
INNER JOIN Categories AS c ON c.Id = r.CategoryId
	   WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.BirthDate) AND
		       DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.BirthDate)
  ORDER BY [Category Name] ASC
