/* 18. Available Room */
USE [TripService]
GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN

	DECLARE @RoomId INT;
	DECLARE @Price DECIMAL(20, 2);
	DECLARE @Type NVARCHAR(20);
	DECLARE @Beds INT;

		  SELECT TOP(1)
    			   @RoomId = r.Id,
    			   @Price = (r.Price + h.BaseRate) * @People,
    			   @Type = r.Type,
    			   @Beds = r.Beds
		    FROM Rooms AS r
	INNER JOIN Hotels AS h ON h.Id = r.HotelId
	INNER JOIN Trips AS t ON t.RoomId = r.Id
		   WHERE h.Id = @HotelId AND 
    			   r.Id NOT IN
    			   (
    					   SELECT r.Id
    						   FROM Rooms r
    				 INNER JOIN Trips t ON t.RoomId = r.Id
    						  WHERE @Date BETWEEN t.ArrivalDate AND t.ReturnDate
    			   ) AND
			       r.Beds >= @People
	  ORDER BY (r.Price + h.BaseRate) * @People DESC
   		
	IF @RoomId IS NULL
	BEGIN
		RETURN 'No rooms available'
	END

	RETURN FORMATMESSAGE('Room %d: %s (%d beds) - $%s', @RoomId, @Type, @Beds, CONVERT(NVARCHAR, @Price))

END

--Example 
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

--Example
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
