/* 08. Peaks and Mountains */
USE [Geography]
GO

	  SELECT p.PeakName, 
		       m.MountainRange AS [Mountain],
		       p.Elevation
      FROM Peaks AS p
INNER JOIN Mountains AS m ON m.Id = p.MountainId
  ORDER BY p.Elevation DESC, p.PeakName ASC