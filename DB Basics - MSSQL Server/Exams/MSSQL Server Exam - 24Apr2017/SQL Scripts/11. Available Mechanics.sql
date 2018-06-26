/* 11. Available Mechanics */
USE [WMS]
GO

	       SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Available
	         FROM Mechanics AS m
LEFT OUTER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	        WHERE j.Status = 'Finished' OR j.Status IS NULL
       GROUP BY m.MechanicId, m.FirstName, m.LastName
       ORDER BY m.MechanicId ASC
