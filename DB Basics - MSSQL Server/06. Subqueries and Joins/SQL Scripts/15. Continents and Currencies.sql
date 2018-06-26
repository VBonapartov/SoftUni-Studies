/* 15. *Continents and Currencies */
USE [Geography]
GO

WITH CTE_CurrenciesUsage (ContinentCode, CurrencyCode, CurrencyUsage)
	 AS
	 (
		  SELECT c.ContinentCode,
    				 c.CurrencyCode, 
    				 COUNT(*) AS [CurrencyUsage]
			  FROM Countries AS c
		   WHERE c.CurrencyCode IS NOT NULL
		GROUP BY c.ContinentCode, c.CurrencyCode
		  HAVING COUNT(c.CurrencyCode) > 1
	 ),

	 CTE_MostUsedCurrency (ContinentCode, MaxUsage)
	 AS
	 (
	    SELECT currencies.ContinentCode, 
		         MAX(currencies.CurrencyUsage) AS MaxUsage 
	      FROM (SELECT * FROM CTE_CurrenciesUsage) AS currencies
		GROUP BY currencies.ContinentCode
	 )

    SELECT cu.ContinentCode, cu.CurrencyCode, cu.CurrencyUsage 
      FROM (SELECT * FROM CTE_CurrenciesUsage) AS cu
INNER JOIN (SELECT * FROM CTE_MostUsedCurrency) AS muc
		    ON cu.ContinentCode = muc.ContinentCode 
	     AND cu.CurrencyUsage = muc.MaxUsage
  ORDER BY cu.ContinentCode;