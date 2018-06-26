/* 02. All User in Games */
USE [Diablo]
GO

	  SELECT g.Name AS [Game], 
		       gt.Name AS [Game Type], 
		       u.Username, 
		       ug.Level, 
		       ug.Cash, 
		       ch.Name AS [Character] 
	    FROM Users AS u
INNER JOIN UsersGames AS ug ON ug.UserId = u.Id
INNER JOIN Games AS g ON g.Id = ug.GameId
INNER JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
INNER JOIN [Characters] AS ch ON ch.Id = ug.CharacterId
  ORDER BY ug.Level DESC, u.Username ASC, [Game] ASC