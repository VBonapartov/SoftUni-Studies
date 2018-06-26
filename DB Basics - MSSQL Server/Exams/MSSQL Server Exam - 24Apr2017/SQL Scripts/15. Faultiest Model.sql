/* 15. Faultiest Model */
USE [WMS]
GO

WITH 
	CTE_MostServicedModelCount(ServicesCount) AS
	(
		  SELECT TOP 1 WITH TIES COUNT(ModelId) 
			  FROM Jobs
		GROUP BY ModelId
		ORDER BY COUNT(ModelId) DESC
	),

	CTE_AllModelsPartsCost(ModelId, TotalCost) AS
	(
				     SELECT j.ModelId, 
						        ISNULL(SUM(p.Price * op.Quantity), 0) 
				       FROM Models AS m
		LEFT OUTER JOIN Jobs AS j ON m.ModelId = j.ModelId
		LEFT OUTER JOIN Orders AS o ON j.JobId = o.JobId
		LEFT OUTER JOIN OrderParts AS op ON o.OrderId = op.OrderId
		LEFT OUTER JOIN Parts AS p ON op.PartId = p.PartId
			     GROUP BY j.ModelId
	)

	  SELECT m.Name AS Model, 
		       COUNT(j.ModelId) AS [Times Serviced], 
		       am.TotalCost AS [Parts Total] 
	    FROM Jobs AS j
INNER JOIN CTE_AllModelsPartsCost AS am ON j.ModelId = am.ModelId
INNER JOIN Models AS m ON am.ModelId = m.ModelId
INNER JOIN CTE_MostServicedModelCount AS ms ON ms.ServicesCount >= 0
  GROUP BY j.ModelId, m.Name, ms.ServicesCount, am.TotalCost
    HAVING COUNT(j.ModelId) = ms.ServicesCount
  ORDER BY COUNT(j.ModelId)

