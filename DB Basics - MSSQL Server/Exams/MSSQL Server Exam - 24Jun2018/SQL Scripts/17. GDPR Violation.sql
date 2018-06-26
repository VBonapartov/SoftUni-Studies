/* 17. GDPR Violation */
USE [TripService]
GO

	  SELECT t.Id,
    		   CONCAT(a.FirstName,' ', ISNULL(MiddleName + ' ', ''), a.LastName) AS [Full Name],
    		   c.Name AS [From],
    		   hc.Name AS [To],
    		   CASE
    			   WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
    			   ELSE CONCAT(CONVERT(VARCHAR, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)), ' days')
    		   END AS [Duration]
      FROM Trips AS t
INNER JOIN AccountsTrips AS atr ON atr.TripId = t.Id
INNER JOIN Accounts AS a ON a.Id = atr.AccountId
INNER JOIN Cities AS c ON c.Id = a.CityId
INNER JOIN Rooms AS r ON r.Id = t.RoomId
INNER JOIN Hotels AS h ON h.Id = r.HotelId
INNER JOIN Cities AS hc ON hc.Id = h.CityId
  ORDER BY [Full Name] ASC, t.Id ASC