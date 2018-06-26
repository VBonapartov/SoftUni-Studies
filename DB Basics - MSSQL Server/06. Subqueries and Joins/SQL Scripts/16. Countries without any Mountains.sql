/* 16. Countries without any Mountains */
USE [Geography]
GO

         SELECT COUNT(*) AS [CountryCode]
           FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
		      WHERE mc.MountainId IS NULL;