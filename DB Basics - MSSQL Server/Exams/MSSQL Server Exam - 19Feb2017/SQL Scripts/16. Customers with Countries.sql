/* 16. Customers with Countries */
USE [Bakery]
GO

CREATE VIEW v_UserWithCountries 
AS
(
	    SELECT CONCAT(cust.FirstName, ' ', cust.LastName) AS CustomerName,
    			   cust.Age,
    			   cust.Gender,
    			   c.Name AS CountryName
	      FROM Customers AS cust
	INNER JOIN Countries AS c ON c.Id = cust.CountryId
)

-- Example
   SELECT TOP 5 *
     FROM v_UserWithCountries
 ORDER BY Age
