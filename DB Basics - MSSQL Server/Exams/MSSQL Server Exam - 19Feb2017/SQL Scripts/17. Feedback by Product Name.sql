/* 17. Feedback by Product Name */
USE [Bakery]
GO

CREATE FUNCTION udf_GetRating(@name VARCHAR(50))
RETURNS VARCHAR(10)
AS
	BEGIN
		DECLARE @rating VARCHAR(10) = 
		( 
				     SELECT CASE 
        						  WHEN AVG(f.Rate) < 5 THEN 'Bad'
        						  WHEN AVG(f.Rate) BETWEEN 5 AND 8 THEN 'Average'
        						  WHEN AVG(f.Rate) > 8 THEN 'Good'
        						  WHEN AVG(f.Rate) IS NULL THEN 'No rating'
					          END			
			         FROM Products AS p
		LEFT OUTER JOIN Feedbacks AS f ON f.ProductId = p.Id
		          WHERE p.Name = @name
		       GROUP BY p.Name	
		)
		
		RETURN @rating;	     
    END

-- Example
   SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
	   FROM Products
 ORDER BY Id
