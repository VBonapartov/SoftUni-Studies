/* 18. Move a Vehicle */
USE [RentACar]
GO

CREATE PROCEDURE usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
BEGIN
	
	BEGIN TRANSACTION
	
	  UPDATE Vehicles
       SET OfficeId = @officeId
     WHERE Id = @vehicleId

    DECLARE @officePlaces INT = 
    (
      SELECT ParkingPlaces
        FROM Offices
       WHERE Id = @officeId
    )

    DECLARE @currentPlaces INT =
	  (
		      SELECT COUNT(v.OfficeId)
			      FROM Vehicles AS v
      INNER JOIN Offices AS o ON o.Id = v.OfficeId
		       WHERE o.Id = @officeId
		    GROUP BY o.Name
    )

    IF (@currentPlaces > @officePlaces)
    BEGIN
		    ROLLBACK;
        RAISERROR ('Not enough room in this office!', 16, 1);
		    RETURN;
    END

    COMMIT;

END

--Example
EXEC usp_MoveVehicle 7, 32;

SELECT OfficeId 
  FROM Vehicles 
 WHERE Id = 7
