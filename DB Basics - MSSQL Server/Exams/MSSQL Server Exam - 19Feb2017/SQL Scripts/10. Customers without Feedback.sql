/* 10. Customers without Feedback */
USE [Bakery]
GO

		     SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
				        c.PhoneNumber,
		            c.Gender
		       FROM Customers AS c
LEFT OUTER JOIN Feedbacks AS f ON f.CustomerId = c.Id 
		      WHERE f.Id IS NULL
	     ORDER BY c.Id ASC