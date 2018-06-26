/* 06. Y Generation */
USE [RentACar]
GO

  SELECT FirstName, LastName
    FROM Clients
   WHERE DATEPART(YEAR, BirthDate) BETWEEN 1977 AND 1994
ORDER BY FirstName ASC, LastName ASC, Id ASC

