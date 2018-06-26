/* 15. Top Travelers */
USE [TripService]
GO

  SELECT ht.Id,
    		 ht.Email,
    		 ht.CountryCode,
    		 ht.Trips
    FROM (
  					  SELECT a.Id, 
      						   a.Email, 
      						   c.CountryCode, 
      						   COUNT(t.Id) AS [Trips],
      						   DENSE_RANK() OVER (PARTITION BY c.CountryCode ORDER BY COUNT(t.Id) DESC, a.Id) AS Rank
  					    FROM Accounts AS a
  				INNER JOIN AccountsTrips atr ON atr.AccountId = a.Id
  				INNER JOIN Trips AS t ON t.Id = atr.TripId
  				INNER JOIN Rooms AS r ON r.Id = t.RoomId
  				INNER JOIN Hotels AS h ON h.Id = r.HotelId
  				INNER JOIN Cities AS c ON c.Id = h.CityId
  				  GROUP BY a.Id, a.Email, c.CountryCode
  		   ) AS ht
   WHERE ht.Rank = 1
ORDER BY ht.Trips DESC, ht.Id ASC

