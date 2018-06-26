/* 11. Count of Countries by Currency */
USE [Geography]
GO

		     SELECT curr.CurrencyCode,
			          curr.Description AS [Currency],
			          COUNT(c.CountryCode) AS [NumberOfCountries]
		       FROM Currencies AS curr
LEFT OUTER JOIN Countries AS c ON c.CurrencyCode = curr.CurrencyCode
	     GROUP BY curr.CurrencyCode,curr.Description 
	     ORDER BY [NumberOfCountries] DESC, [Currency] ASC 

