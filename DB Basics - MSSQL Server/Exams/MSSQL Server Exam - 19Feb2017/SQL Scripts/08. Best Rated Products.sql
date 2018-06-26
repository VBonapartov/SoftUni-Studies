/* 08. Best Rated Products */
USE [Bakery]
GO

    SELECT TOP 10  
           p.[Name], 
		       p.[Description], 
		       AVG(Rate) AS AverageRate,
		       COUNT(*) AS FeedbacksAmount
      FROM Feedbacks AS f
INNER JOIN Products AS p ON p.Id = f.ProductId
  GROUP BY p.[Name], p.[Description]
  ORDER BY AverageRate DESC, FeedbacksAmount DESC
