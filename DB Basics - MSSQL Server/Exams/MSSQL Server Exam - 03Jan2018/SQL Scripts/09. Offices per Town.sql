/* 09. Offices per Town */
USE [RentACar]
GO

    		 SELECT t.Name	 AS [TownName],
    				    COUNT(*) AS [OfficesNumber]
    		   FROM Towns AS t
LEFT OUTER JOIN Offices AS o ON o.TownId = t.Id
  	   GROUP BY t.Name
  	   ORDER BY OfficesNumber  DESC, TownName ASC


