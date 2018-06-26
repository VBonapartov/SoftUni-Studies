/* 14. Trip Revenues */
USE [TripService]
GO

	  SELECT t.Id, 
    		   h.Name AS HotelName, 
    		   r.Type AS RoomType,
    		   CASE
    			   WHEN t.CancelDate IS NOT NULL THEN 0
    			   ELSE COUNT(atr.AccountId) * (r.Price + h.BaseRate)
    		   END AS Revenue
	    FROM Trips AS t
INNER JOIN Rooms AS r ON r.Id = t.RoomId
INNER JOIN Hotels AS h ON h.Id = r.HotelId
INNER JOIN AccountsTrips atr ON atr.TripId = t.Id
  GROUP BY t.Id, h.Name, r.Type, t.CancelDate, r.Price, h.BaseRate
  ORDER BY r.Type ASC, t.Id ASC