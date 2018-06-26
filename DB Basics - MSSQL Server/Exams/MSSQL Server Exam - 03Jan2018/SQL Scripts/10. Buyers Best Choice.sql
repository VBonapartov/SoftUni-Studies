/* 10. Buyers Best Choice */
USE [RentACar]
GO

    		 SELECT m.Manufacturer		  AS [Manufacturer], 
        				m.Model				      AS [Model],
        				COUNT(o.VehicleId)  AS [TimesOrdered]
    		   FROM Vehicles AS v
LEFT OUTER JOIN Orders AS o ON o.VehicleId = v.Id 
  	 INNER JOIN Models AS m ON m.Id = v.ModelId
  	   GROUP BY m.Manufacturer, m.Model
  	   ORDER BY [TimesOrdered] DESC, [Manufacturer] DESC, [Model] ASC


