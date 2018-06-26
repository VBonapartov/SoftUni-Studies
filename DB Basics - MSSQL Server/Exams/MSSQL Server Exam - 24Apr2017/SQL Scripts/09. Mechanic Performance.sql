/* 09. Mechanic Performance */
USE [WMS]
GO

	  SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
		       AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
	    FROM Mechanics AS m
INNER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	   WHERE j.FinishDate IS NOT NULL
  GROUP BY m.MechanicId, m.FirstName, m.LastName
  ORDER By m.MechanicId ASC

    