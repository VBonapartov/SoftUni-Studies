/* 12. Highest Peaks in Bulgaria */
USE [Geography]
GO

    SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
      FROM Countries AS c
INNER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m ON m.Id = mc.MountainId
INNER JOIN Peaks AS p ON p.MountainId = m.Id
     WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
  ORDER BY p.Elevation DESC;

