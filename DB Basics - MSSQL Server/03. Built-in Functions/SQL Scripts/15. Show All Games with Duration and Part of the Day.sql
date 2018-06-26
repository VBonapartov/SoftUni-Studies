/* 15. Show All Games with Duration and Part of the Day */
USE [Diablo]
GO

  SELECT [Name], 
    		 CASE
    			WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
    			WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
    			ELSE 'Evening'
    		 END AS [Part of the Day],
    		 CASE
    			WHEN Duration IS NULL THEN 'Extra Long'
    			WHEN Duration <= 3 THEN 'Extra Short'
    			WHEN Duration BETWEEn 4 AND 6 THEN 'Short'
    			WHEN Duration > 6 THEN 'Long'	
    		 END AS [Duration]
    FROM Games
ORDER BY [Name], [Duration], [Part of the Day];