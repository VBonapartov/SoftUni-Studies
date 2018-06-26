/* 09. Expensive First-Class Rooms */
USE [TripService]
GO

    SELECT r.Id, 
    		   r.Price, 
    		   h.Name AS Hotel, 
    		   c.Name AS City 
	    FROM Rooms AS r
INNER JOIN Hotels AS h ON h.Id = r.HotelId
INNER JOIN Cities AS c ON c.Id = h.CityId
	   WHERE r.Type = 'First Class'
  ORDER BY r.Price DESC, r.Id ASC