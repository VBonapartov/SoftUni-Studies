/* 09. *Peaks in Rila */
USE [Geography]
GO

    SELECT m.MountainRange, p.PeakName, p.Elevation
      FROM Peaks AS p
INNER JOIN Mountains AS m ON m.Id = p.MountainId
     WHERE m.MountainRange = 'Rila'
  ORDER BY p.Elevation DESC;
	