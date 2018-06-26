/* 24. Countries and Currency (Euro/Not Euro) */
USE Geography
GO

  SELECT CountryName, CountryCode,
         CASE CurrencyCode
             WHEN 'EUR' THEN 'Euro'
             ELSE 'Not Euro'
         END AS [Currency]
    FROM Countries
ORDER BY CountryName;