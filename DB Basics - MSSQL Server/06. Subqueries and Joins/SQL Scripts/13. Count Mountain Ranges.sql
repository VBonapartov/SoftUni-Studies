/* 13. Count Mountain Ranges */
USE [Geography]
GO

  SELECT a.CountryCode, COUNT(a.MountainId) AS [MountainRanges]
    FROM (
    			         SELECT c.CountryCode, mc.MountainId 
    			           FROM Countries AS c
    		  LEFT OUTER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
    			          WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
	       ) AS a
GROUP BY a.CountryCode;
