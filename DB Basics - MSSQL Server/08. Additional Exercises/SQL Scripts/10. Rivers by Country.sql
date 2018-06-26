/* 10. Rivers by Country */
USE [Geography]
GO    
		  
         SELECT c.CountryName,
				        cont.ContinentName, 
				        COUNT(cr.RiverId) AS [RiversCount],
				        ISNULL(SUM(r.Length), 0) AS [TotalLength]
		       FROM Countries AS c
LEFT OUTER JOIN Continents AS cont ON cont.ContinentCode = c.ContinentCode
LEFT OUTER JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers AS r ON r.Id = cr.RiverId
	     GROUP BY c.CountryName, cont.ContinentName
	     ORDER BY [RiversCount] DESC, [TotalLength] DESC, c.CountryName

