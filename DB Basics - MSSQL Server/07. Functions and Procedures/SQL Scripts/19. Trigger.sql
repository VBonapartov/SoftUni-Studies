/* 19. Trigger */
USE [Diablo]
GO

/* Trigget for validating user's level when buying items */
CREATE TRIGGER tr_UserGameItems_LevelRestriction 
ON UserGameItems
INSTEAD OF INSERT
AS
	BEGIN
		DECLARE @UserGameId INT = (SELECT UserGameId FROM inserted);
		DECLARE @ItemId INT = (SELECT ItemId FROM inserted);

		IF(
			(SELECT Level FROM UsersGames WHERE Id = @UserGameId) <
			(SELECT MinLevel FROM Items WHERE Id = @ItemId)
		  )
		BEGIN
			RAISERROR('Your current level is not enough', 16, 1);
			RETURN;
		END;

		/* Assign the new item when the exception isn't thrown */
		INSERT INTO UserGameItems
			   VALUES (@ItemId, @UserGameId);

		/* Add bonus cash */
		  UPDATE ug
		     SET ug.Cash += 50000
		    FROM UsersGames AS ug
	INNER JOIN Users AS u ON u.Id = ug.UserId
	INNER JOIN Games AS g ON g.Id = ug.GameId
		   WHERE u.FirstName IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
		     AND g.Name = 'Bali';

		/* ...  */
     END;