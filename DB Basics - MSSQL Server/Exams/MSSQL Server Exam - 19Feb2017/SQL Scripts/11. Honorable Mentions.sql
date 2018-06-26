/* 11. Honorable Mentions */
USE [Bakery]
GO

WITH CTE_CustomersWithMoreThan3Feedbacks (CustomerId)
AS
(
    SELECT CustomerId
      FROM Feedbacks
  GROUP BY CustomerId
    HAVING COUNT(Id) >= 3
)

	  SELECT f.ProductId, 
    		   CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
     		   ISNULL(f.Description, '') AS FeedbackDescription
	    FROM Feedbacks AS f
INNER JOIN CTE_CustomersWithMoreThan3Feedbacks AS topCust ON topCust.CustomerId = f.CustomerId
INNER JOIN Customers AS c ON c.Id = topCust.CustomerId
  ORDER BY f.ProductId, CustomerName, f.Id
