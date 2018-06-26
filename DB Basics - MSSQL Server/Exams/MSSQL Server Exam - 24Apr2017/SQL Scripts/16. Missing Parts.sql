/* 16. Missing Parts */
USE [WMS]
GO

WITH
	CTE_PartsNeededForJobs(PartId, [Required]) AS
	(
		    SELECT pn.PartId, 
				       SUM(pn.Quantity) AS [Required]
			    FROM Jobs AS j
		INNER JOIN PartsNeeded AS pn ON pn.JobId = j.JobId
			   WHERE Status <> 'Finished'
			GROUP BY pn.PartId
	),

	CTE_OrderPartsQuantity(PartId, Ordered) AS
	(
		    SELECT op.PartId, 
				       SUM(op.Quantity) AS Ordered
			    FROM OrderParts AS op
		INNER JOIN Orders AS o ON o.OrderId = op.OrderId
			   WHERE o.Delivered = 0
		  GROUP BY op.PartId
	)

		     SELECT p.PartId, 
                p.Description, 
			          pj.Required, 
                p.StockQty AS [In Stock], 
                ISNULL(op.Ordered, 0) AS Ordered
		       FROM Parts AS p
	   INNER JOIN CTE_PartsNeededForJobs AS pj ON pj.PartId = p.PartId
LEFT OUTER JOIN CTE_OrderPartsQuantity AS op ON op.PartId = pj.PartId
		      WHERE (p.StockQty + ISNULL(op.Ordered, 0)) < pj.Required
	     ORDER BY p.PartId ASC

