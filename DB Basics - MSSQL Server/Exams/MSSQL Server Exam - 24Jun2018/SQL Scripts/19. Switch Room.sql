/* 19. Switch Room */
USE [TripService]
GO

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN

	DECLARE @targetRoomHotelId INT =
	( 
		SELECT HotelId
		  FROM Rooms 
		 WHERE Id = @TargetRoomId
	)

	DECLARE @tripHotelId INT =
	( 
		  SELECT r.HotelId
		    FROM Trips AS t
	INNER JOIN Rooms AS r ON r.Id = t.RoomId
		   WHERE t.Id = @TripId
	)

	IF (@targetRoomHotelId <> @tripHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!', 16, 1);
		RETURN;
	END

	DECLARE @targetRoomBeds INT =
	(
		SELECT Beds
		  FROM Rooms 
		 WHERE Id = @TargetRoomId
	)

	DECLARE @bedsRequired INT =
	(
		SELECT COUNT(*)
		  FROM AccountsTrips
		 WHERE TripId = @TripId
	)

	IF @bedsRequired > @targetRoomBeds
	BEGIN
		RAISERROR('Not enough beds in target room!', 16, 1);
		RETURN;
	END

	UPDATE Trips
	   SET RoomId = @TargetRoomId
	 WHERE Id = @TripId

END

--Example
EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

--Example
EXEC usp_SwitchRoom 10, 7

--Example
EXEC usp_SwitchRoom 10, 8
