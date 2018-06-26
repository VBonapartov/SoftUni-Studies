/* 05. All Items with Greater than Average Statistics */
USE [Diablo]
GO

WITH CTE_AboveAverageStats (Id) 
AS 
(  
  SELECT Id 
    FROM [Statistics]
   WHERE Mind > (SELECT AVG(Mind  * 1.0) FROM [Statistics]) AND
         Luck > (SELECT AVG(Luck  * 1.0) FROM [Statistics]) AND
         Speed > (SELECT AVG(Speed * 1.0) FROM [Statistics])
)

	  SELECT i.Name,
		       i.Price,
		       i.MinLevel,
		       s.Strength,
		       s.Defence,
		       s.Speed,
		       s.Luck,
		       s.Mind
	    FROM Items AS i
INNER JOIN [Statistics] AS s ON s.Id = i.StatisticId
INNER JOIN CTE_AboveAverageStats AS av ON av.Id = s.Id
  ORDER BY i.Name 

