/* 05. Bulgarian Cities */
USE [TripService]
GO

  SELECT Id, [Name] 
    FROM Cities
   WHERE CountryCode = 'BG'
ORDER BY [Name]
 

