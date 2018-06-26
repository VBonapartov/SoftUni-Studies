/* 07. Spacious Office */
USE [RentACar]
GO

	  SELECT t.Name AS TownName,
		       o.Name AS OfficeName,
		       o.ParkingPlaces
      FROM Offices AS o
INNER JOIN Towns AS t ON t.Id = o.TownId
     WHERE o.ParkingPlaces > 25
  ORDER BY TownName ASC, o.Id ASC

