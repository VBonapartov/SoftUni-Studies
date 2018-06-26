/* 20. Cancel Trip */
USE [TripService]
GO

CREATE TRIGGER tr_Tre
ON Trips
INSTEAD OF DELETE
AS
BEGIN

		   UPDATE Trips
	        SET CancelDate = GETDATE()
		     FROM deleted AS d
	 INNER JOIN Trips AS t ON t.Id = d.Id
		    WHERE t.CancelDate IS NULL

END

--Example 
DELETE FROM Trips
WHERE Id IN (48, 49, 50)