/* 18. *Highest Peak Name and Elevation by Country */
USE [Geography]
GO

WITH CTE_PeaksRank (CountryName, PeakName, Elevation, Mountain, PeakRank)
AS
(
      		 SELECT c.CountryName,				    
      				    p.PeakName,
      				    p.Elevation,
      				    m.MountainRange,
					        DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank
			       FROM Countries AS c
	LEFT OUTER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT OUTER JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT OUTER JOIN Peaks AS p ON p.MountainId = m.Id
)

  SELECT TOP (5) 
	       pr.CountryName AS [Country],
         ISNULL(pr.PeakName, '(no highest peak)') AS [HighestPeakName],
         ISNULL(pr.Elevation, 0) AS [HighestPeakElevation],
         ISNULL(pr.Mountain, '(no mountain)') AS [Mountain]
    FROM (SELECT * FROM CTE_PeaksRank) AS pr		
   WHERE pr.PeakRank = 1
ORDER BY pr.CountryName, pr.PeakName;
