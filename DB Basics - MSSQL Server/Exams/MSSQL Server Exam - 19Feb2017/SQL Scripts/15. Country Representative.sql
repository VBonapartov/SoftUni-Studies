/* 15. Country Representative */
USE [Bakery]
GO

  SELECT CountryName, DistributorName
    FROM (
    			    SELECT co.Name AS CountryName, 
          					 d.Name AS DistributorName, 
          					 COUNT(i.Id) AS IngredientsCount,
          					 DENSE_RANK() OVER (PARTITION BY co.Name ORDER BY COUNT(i.Id) DESC) AS DistributorRank 
    				    FROM Countries AS co
    		  INNER JOIN Distributors AS d ON d.CountryId = co.Id
    		  INNER JOIN Ingredients AS i ON i.DistributorId = d.Id
    			  GROUP BY d.Name, co.Name
		     ) AS CountryDistributorStats
   WHERE DistributorRank = 1
ORDER BY CountryName, DistributorName