/* 12. Population and Area by Continent */
USE [Geography]
GO

		   SELECT cont.ContinentName,
			        SUM(c.AreaInSqKm) AS [CountriesArea],
				      SUM(CAST(c.Population AS float)) AS [CountriesPopulation] 
		     FROM Countries AS c
	 INNER JOIN Continents AS cont ON cont.ContinentCode = c.ContinentCode
	   GROUP BY cont.ContinentName 
	   ORDER BY [CountriesPopulation] DESC

