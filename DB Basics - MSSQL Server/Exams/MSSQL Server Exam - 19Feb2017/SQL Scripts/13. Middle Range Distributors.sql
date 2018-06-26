/* 13. Middle Range Distributors */
USE [Bakery]
GO

	  SELECT d.Name AS DistributorName, 
    		   i.Name AS IngredientName,
    		   p.Name AS ProductName,
    		   ratedProducts.AverageRate
	    FROM (
    				  SELECT ProductId, AVG(Rate) AS AverageRate
    				    FROM Feedbacks 
    			  GROUP BY ProductId
    				  HAVING AVG(Rate) BETWEEN 5 AND 8
		       ) AS ratedProducts
INNER JOIN Products AS p ON p.Id = ratedProducts.ProductId
INNER JOIN ProductsIngredients AS pi ON pi.ProductId = ratedProducts.ProductId
INNER JOIN Ingredients AS i ON i.Id = pi.IngredientId
INNER JOIN Distributors AS d ON d.Id = i.DistributorId
  ORDER BY DistributorName, IngredientName, ProductName
