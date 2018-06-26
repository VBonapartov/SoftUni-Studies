/* 14. Model Repair Time */
USE [WMS]
GO

WITH
	CTE_ModelsWithAST (ModelId, [Name], [Average Service Time])
	AS
	(
			     SELECT m.ModelId, 
					        m.Name,
					        AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Service Time]
			       FROM Models AS m
	LEFT OUTER JOIN Jobs AS j ON j.ModelId = m.ModelId
			      WHERE j.Status = 'Finished'
		     GROUP BY m.ModelId, m.Name
	)

  SELECT mast.ModelId,
	       mast.Name,
	       CASE
        	 WHEN mast.[Average Service Time] = 1 THEN  CONCAT(mast.[Average Service Time], ' day')
        	 ELSE CONCAT(mast.[Average Service Time], ' days')
	       END
    FROM CTE_ModelsWithAST AS mast
ORDER BY mast.[Average Service Time] ASC