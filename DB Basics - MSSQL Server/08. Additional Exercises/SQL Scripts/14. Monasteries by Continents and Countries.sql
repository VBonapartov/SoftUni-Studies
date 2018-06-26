/* 14. Monasteries by Continents and Countries */
USE [Geography]
GO

UPDATE Countries
   SET CountryName = 'Burma' 
 WHERE CountryName = 'Myanmar'
GO

INSERT INTO Monasteries (Name, CountryCode)
(
SELECT 'Hanga Abbey', CountryCode
  FROM Countries AS c 
 WHERE CountryName = 'Tanzania'
)
GO

INSERT INTO Monasteries (Name, CountryCode)
(
SELECT 'Myin-Tin-Daik', CountryCode
  FROM Countries AS c 
 WHERE CountryName = 'Myanmar'
)
GO

		     SELECT cont.ContinentName,
				        c.CountryName,
				        COUNT(m.Id) AS [MonasteriesCount]
		       FROM Continents AS cont
LEFT OUTER JOIN Countries AS c ON cont.ContinentCode = c.ContinentCode
LEFT OUTER JOIN Monasteries AS m ON m.CountryCode = c.CountryCode
		      WHERE c.IsDeleted = 0
	     GROUP BY cont.ContinentName, c.CountryName
	     ORDER BY [MonasteriesCount] DESC, c.CountryName ASC