/* 20. Vendor Preference */
USE [WMS]
GO

WITH 
	CTE_MechanicsAllParts(MechanicId, Count) AS
	(
		    SELECT m.MechanicId, 
			         SUM(op.Quantity) 
		      FROM Mechanics As m
		INNER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
		INNER JOIN Orders AS o ON o.JobId = j.JobId
		INNER JOIN OrderParts AS op ON op.OrderId = o.OrderId
		  GROUP BY m.MechanicId
	),

	CTE_PartsByVendorMechanic(MechanicId, VendorId, VendorCount) AS
	(
			  SELECT m.MechanicId, 
				       v.VendorId, 
				       SUM(op.Quantity) 
			    FROM Mechanics AS m
		INNER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
		INNER JOIN Orders AS o ON o.JobId = j.JobId
		INNER JOIN OrderParts AS op ON op.OrderId = o.OrderId
		INNER JOIN Parts as p ON p.PartId = op.PartId
		INNER JOIN Vendors AS v ON v.VendorId = p.VendorId
		  GROUP BY m.MechanicId, v.VendorId
	)

	  SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, 
		       v.Name AS Vendor, 
		       pv.VendorCount AS Parts, 
		       CONCAT((pv.VendorCount * 100)/ap.Count, '%') AS Preference  
	    FROM Mechanics AS m
INNER JOIN CTE_MechanicsAllParts AS ap ON ap.MechanicId = m.MechanicId
INNER JOIN CTE_PartsByVendorMechanic AS pv ON pv.MechanicId = ap.MechanicId
INNER JOIN Vendors AS v ON v.VendorId = pv.VendorId
  ORDER BY Mechanic, Parts DESC, Vendor