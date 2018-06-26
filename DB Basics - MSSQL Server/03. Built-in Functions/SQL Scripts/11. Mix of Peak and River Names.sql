/* 11. Mix of Peak and River Names */
USE [Geography]
GO

  SELECT p.PeakName,
         r.RiverName,
         LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName)-1), r.RiverName)) AS Mix
    FROM Peaks AS p
    JOIN Rivers AS r 
      ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix;