/* 10. Users per Employee */
USE [ReportService]
GO

  SELECT Name, 
	       SUM([Users Number]) AS [Users Number]
	  FROM (
    					     SELECT e.Id, 
    						  	      CONCAT(e.FirstName, ' ', e.LastName) AS Name, 
    							        COUNT(r.UserId) AS [Users Number] 
    					       FROM Employees AS e
    			LEFT OUTER JOIN Reports AS r ON r.EmployeeId = e.Id
    				     GROUP BY e.Id, e.FirstName, e.LastName, r.UserId
    		 ) AS t
GROUP BY Id, Name
ORDER BY SUM([Users Number]) DESC, Name ASC
