/* 12. Age Groups Revenue */
USE [RentACar]
GO

WITH
	CTE_AgeGroups (OrderId, VehicleId, Bill, TotalMileage,AgeGroup) AS
	(
		  SELECT o.Id,
    			   o.VehicleId,
    			   o.Bill,
    			   o.TotalMileage,
    			   CASE
    				   WHEN DATEPART(YEAR, BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
    				   WHEN DATEPART(YEAR, BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
    				   WHEN DATEPART(YEAR, BirthDate) BETWEEN 1990 AND 1999 THEN '90''s' 
    			   ELSE 'Others'
    			   END AS [AgeGroup]
		    FROM Clients AS c
	INNER JOIN Orders AS o ON o.ClientId = c.Id
	)

    SELECT ag.AgeGroup	  AS [AgeGroup], 
    		   SUM(ag.Bill)	  AS [Revenue],
    		   AVG(ag.TotalMileage) AS [AverageMileage]
	    FROM CTE_AgeGroups AS ag
  GROUP BY ag.AgeGroup
  ORDER BY [AgeGroup] ASC

