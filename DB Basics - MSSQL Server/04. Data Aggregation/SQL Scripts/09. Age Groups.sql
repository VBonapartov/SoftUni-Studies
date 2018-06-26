/* 09. Age Groups */
USE [Gringotts]
GO

  SELECT Grouped.AgeGroups, COUNT(*) AS [WizardCount]
    FROM (
    		  SELECT 
    				CASE 
    					WHEN Age < 11 THEN '[0-10]'
    					WHEN Age < 21 THEN '[11-20]'
    					WHEN Age < 31 THEN '[21-30]'
    					WHEN Age < 41 THEN '[31-40]'
    					WHEN Age < 51 THEN '[41-50]'
    					WHEN Age < 61 THEN '[51-60]'
    					WHEN Age >= 61 THEN '[61+]'
    					ELSE 'n\a'
    				END AS AgeGroups
    			FROM WizzardDeposits
		     ) AS Grouped
GROUP BY Grouped.AgeGroups; 	