/* 10. Longest and Shortest Trips */
USE [TripService]
GO

  	SELECT a.Id AS AccountId, 
    		   CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
    		   MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
    		   MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
  	  FROM Accounts AS a
INNER JOIN AccountsTrips AS atr ON atr.AccountId = a.Id
INNER JOIN Trips AS t ON t.Id = atr.TripId
	   WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
  GROUP BY a.Id, a.FirstName, a.LastName
  ORDER BY LongestTrip DESC, a.Id ASC