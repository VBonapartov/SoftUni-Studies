/* 06. Display All Items with Information about Forbidden Game Type */
USE [Diablo]
GO

		     SELECT i.Name AS [Item], 
				        i.Price,
				        i.MinLevel,
				        gt.Name AS [Forbidden Game Type]
		       FROM Items AS i
LEFT OUTER JOIN GameTypeForbiddenItems AS fi ON fi.ItemId = i.Id
LEFT OUTER JOIN GameTypes AS gt ON gt.Id = fi.GameTypeId
	     ORDER BY [Forbidden Game Type] DESC, [Item] ASC


