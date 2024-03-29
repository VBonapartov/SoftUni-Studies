/* 07. Ingredients from Bulgaria and Greece */
USE [Bakery]
GO

    SELECT TOP 15
		       i.[Name], 
		       i.[Description], 
		       c.[Name] AS [CountryName]
      FROM Ingredients AS i
INNER JOIN Countries AS c ON c.Id = i.OriginCountryId
	   WHERE c.[Name] IN ('Bulgaria', 'Greece')
  ORDER BY i.[Name] ASC, c.[Name] ASC