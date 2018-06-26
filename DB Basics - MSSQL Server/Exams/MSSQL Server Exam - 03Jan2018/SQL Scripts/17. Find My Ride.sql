/* 17. Find My Ride */
USE [RentACar]
GO

CREATE FUNCTION udf_CheckForVehicle(@townName VARCHAR(50), @seatsNumber INT) 
RETURNS NVARCHAR(MAX)
AS
BEGIN
	
      DECLARE @result NVARCHAR(MAX) = 
      (
  		    SELECT TOP 1 
  			         o.Name + ' - ' + m.Model
            FROM Towns AS t
      INNER JOIN Offices AS o ON o.TownId = t.Id
      INNER JOIN Vehicles AS v ON v.OfficeId = o.Id
      INNER JOIN Models AS m ON m.Id = v.ModelId
  		     WHERE t.Name = @townName AND m.Seats = @seatsNumber
        GROUP BY o.Name, m.Model
        ORDER BY o.Name ASC
	   )

    IF (@result IS NULL)
    BEGIN
		  RETURN 'NO SUCH VEHICLE FOUND'
    END

    RETURN @result

END

--Example
SELECT dbo.udf_CheckForVehicle ('La Escondida', 9)
