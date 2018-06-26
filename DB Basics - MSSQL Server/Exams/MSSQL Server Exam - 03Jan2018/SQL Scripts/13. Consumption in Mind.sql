/* 13. Consumption in Mind */
USE [RentACar]
GO

WITH
	CTE_SevenMostOrderedModels (ModelId, Manufacturer, Consumption, ModelsCount) AS
	(
			       SELECT m.Id AS [ModelId], 
        						m.Manufacturer AS [Manufacturer], 
        						m.Consumption AS [Consumption], 
        						COUNT(m.Id) AS [ModelsCount]
    				   FROM Models AS m
			   INNER JOIN Vehicles AS v ON v.ModelId = m.Id
		LEFT OUTER JOIN Orders AS o ON o.VehicleId = v.Id
			     GROUP BY m.Id, m.Manufacturer, m.Consumption 
	)

  SELECT mom.Manufacturer	    AS [Manufacturer],
		     AVG(mom.Consumption) AS [AverageConsumption]
    FROM 
    		 (
    			  SELECT TOP (7) * 
    				  FROM CTE_SevenMostOrderedModels 
    			ORDER BY ModelsCount DESC
    		 ) AS mom
GROUP BY mom.Manufacturer, mom.ModelsCount
  HAVING AVG(mom.Consumption) BETWEEN 5 AND 15
ORDER BY [Manufacturer] ASC, [AverageConsumption] ASC
