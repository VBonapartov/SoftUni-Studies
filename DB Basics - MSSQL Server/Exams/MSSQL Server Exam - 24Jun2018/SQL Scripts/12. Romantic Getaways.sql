/* 12. Romantic Getaways */
USE [TripService]
GO

  	SELECT a.Id, 
    		   a.Email,		
    		   c.Name AS City, 
    		   COUNT(t.Id) AS Trips 
  	  FROM Accounts AS a
INNER JOIN Cities c ON c.Id = a.CityId
INNER JOIN AccountsTrips AS atr ON atr.AccountId = a.Id
INNER JOIN Trips AS t ON t.Id = atr.TripId
INNER JOIN Rooms AS r ON r.Id = t.RoomId
INNER JOIN Hotels AS h ON h.Id = r.HotelId
	   WHERE h.CityId = a.CityId
  GROUP BY a.Id, a.Email, c.Name
  ORDER BY Trips DESC, a.Id ASC
