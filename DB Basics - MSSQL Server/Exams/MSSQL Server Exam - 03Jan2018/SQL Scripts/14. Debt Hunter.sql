/* 14. Debt Hunter */
USE [RentACar]
GO

WITH 
	CTE_Ranked (ClientName, Bill, Email, TownName, Rank, ClientId) AS
	(
    	SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [Category Name],
    			   o.Bill,
    			   c.Email,
    			   t.Name,
    			   DENSE_RANK() OVER (PARTITION BY t.Id ORDER BY o.Bill DESC) AS Rank,
			       c.Id
		    FROM Towns AS t
	INNER JOIN Orders AS o ON o.TownId = t.Id
	INNER JOIN Clients AS c ON c.Id = o.ClientId
		   WHERE DATEDIFF(DAY, c.CardValidity, o.CollectionDate) > 0 AND o.Bill IS NOT NULL
	  GROUP BY t.Id, o.Bill, CONCAT(c.FirstName, ' ', c.LastName), t.Name, c.Email, c.Id
	)

  SELECT cte.ClientName AS [Category Name],
    		 cte.Email      AS [Email],
    		 cte.Bill       AS [Bill],
    		 cte.TownName   AS [Town]
	  FROM CTE_Ranked AS cte
   WHERE cte.Rank = 1 OR cte.Rank = 2
ORDER BY cte.TownName ASC, cte.Bill ASC, cte.ClientId ASC

