/* 11. Kinda Person */
USE [RentACar]
GO

WITH 
	CTE_MostFrequentClass AS
	(
			     SELECT c.FirstName + ' ' + c.LastName AS [Name],
        					m.Class AS [Class],
        					DENSE_RANK() OVER (PARTITION BY c.FirstName + ' ' + c.LastName ORDER BY COUNT(m.Class) DESC) AS rn
    			   FROM Clients AS c
	LEFT OUTER JOIN Orders AS o ON c.Id = o.ClientId
	LEFT OUTER JOIN Vehicles AS v ON o.VehicleId = v.Id
	LEFT OUTER JOIN Models AS m ON v.ModelId = m.Id
         GROUP BY c.FirstName + ' ' + c.LastName, m.Class
	)

  SELECT mfc.Name  AS [Name],
		     mfc.Class AS [Class]
	  FROM CTE_MostFrequentClass AS mfc
   WHERE rn = 1 AND mfc.Class IS NOT NULL
ORDER BY mfc.Name ASC, mfc.Class ASC



