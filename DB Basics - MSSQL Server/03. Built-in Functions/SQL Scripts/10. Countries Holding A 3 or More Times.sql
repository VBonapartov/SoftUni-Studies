/* 10. Countries Holding A 3 or More Times */
USE [Geography]
GO

  SELECT CountryName AS [Country Name], IsoCode AS [ISO Code]
    FROM Countries
   WHERE CountryName LIKE '%a%a%a%'
ORDER BY [ISO Code]