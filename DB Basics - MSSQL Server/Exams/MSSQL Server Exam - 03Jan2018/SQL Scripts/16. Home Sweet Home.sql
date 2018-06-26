/* 16. Home Sweet Home */
USE [RentACar]
GO

WITH 
	CTE_C (ReturnOfficeId, OfficeId, VehicleId, Manufacturer, Model) AS
	(
		SELECT w.ReturnOfficeId,
  			   w.OfficeId,
  			   w.Id,
  			   w.Manufacturer,
  			   w.Model
		  FROM (
    					  SELECT DENSE_RANK() OVER (PARTITION BY v.Id ORDER BY o.CollectionDate DESC) AS [RANK],
        						   o.ReturnOfficeId,
        						   v.OfficeId,
        						   v.Id,
        						   m.Manufacturer,
        						   m.Model
    					    FROM Models AS m
    				INNER JOIN Vehicles AS v ON m.Id = v.ModelId
    				 LEFT JOIN Orders AS o ON o.VehicleId = v.Id
			     ) AS w
		 WHERE w.RANK = 1
	)

  SELECT CONCAT(c.Manufacturer, ' - ', c.Model) AS [Vehicle],
    		 CASE
    			 WHEN (
        					SELECT COUNT(*)
        					  FROM Orders
        					 WHERE VehicleId = c.VehicleId
    				    ) = 0 OR c.OfficeId = c.ReturnOfficeId THEN 'home'
    			 WHEN c.ReturnOfficeId IS NULL THEN 'on a rent'
    			 WHEN c.OfficeId <> c.ReturnOfficeId THEN (
                        															  SELECT CONCAT([to].Name, ' - ', [of].Name)
                        															    FROM Offices AS [of]
                        														INNER JOIN Towns AS [to] ON [to].Id = [of].TownId
                        															   WHERE c.ReturnOfficeId = [of].Id
                        												    )
    		 END AS [Location]
    FROM CTE_C AS c
ORDER BY Vehicle, c.VehicleId
