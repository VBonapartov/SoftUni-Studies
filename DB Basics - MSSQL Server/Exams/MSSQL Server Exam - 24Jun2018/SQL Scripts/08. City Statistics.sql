/* 08. City Statistics */
USE [TripService]
GO

		     SELECT c.Name AS City,
				        COUNT(h.Id) AS Hotels
		       FROM Cities AS c
LEFT OUTER JOIN Hotels AS h ON h.CityId = c.Id
	     GROUP BY c.Id, c.Name
	     ORDER BY Hotels DESC, City ASC

