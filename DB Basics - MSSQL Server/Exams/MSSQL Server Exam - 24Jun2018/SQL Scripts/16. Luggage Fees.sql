/* 16. Luggage Fees */
USE [TripService]
GO

	  SELECT t.Id, 
    		   SUM(atr.Luggage) AS Luggage,
    		   CASE
    			   WHEN SUM(atr.Luggage) > 5 THEN '$' + CONVERT(NVARCHAR, 5 * SUM(atr.Luggage))
    		     ELSE '$0'
    		   END AS Fee
	    FROM Trips t
INNER JOIN AccountsTrips atr ON atr.TripId = t.Id
  GROUP BY t.Id
    HAVING SUM(atr.Luggage) > 0
  ORDER BY Luggage DESC
