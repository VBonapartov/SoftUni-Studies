/* 14. The Most Positive Country */
USE [Bakery]
GO

	  SELECT TOP(1) WITH TIES
		       co.Name AS CountryName, 
		       AVG(f.Rate) AS FeedbackRate
	    FROM Feedbacks AS f
INNER JOIN Customers AS c ON c.Id = f.CustomerId
INNER JOIN Countries AS co ON co.Id = c.CountryId
  GROUP BY co.Name
  ORDER BY FeedbackRate DESC