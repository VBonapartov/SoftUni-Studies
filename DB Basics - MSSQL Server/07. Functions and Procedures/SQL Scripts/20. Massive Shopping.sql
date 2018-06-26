/* 20. *Massive Shopping */
USE [Diablo]
GO

DECLARE @gameName NVARCHAR(50) = 'Safflower';
DECLARE @userName NVARCHAR(50) = 'Stamat';
DECLARE @userGameId INT;

	  SELECT @userGameId = ug.Id 
	    FROM UsersGames AS ug
INNER JOIN Users AS u ON u.Id = ug.UserId
INNER JOIN Games AS g ON g.Id = ug.GameId
	   WHERE u.Username = @userName AND g.Name = @gameName

DECLARE @userGameLevel INT = (SELECT Level FROM UsersGames WHERE Id = @userGameId);
DECLARE @itemsCost DECIMAL(15, 4), @availableCash DECIMAL(15, 4)
DECLARE @minLevel INT;
DECLARE @maxLevel INT;

-- Items LEVEL 11-12
SET @minLevel = 11; 
SET @maxLevel = 12;

SET @availableCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
SET @itemsCost = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel);

IF (@availableCash >= @itemsCost AND @userGameLevel >= @maxLevel) 
BEGIN 
	BEGIN TRANSACTION  
		UPDATE UsersGames 
		   SET Cash -= @itemsCost 
		 WHERE Id = @userGameId; 

		IF (@@ROWCOUNT <> 1) 
		BEGIN
			ROLLBACK; 
			RAISERROR('Could not make payment', 16, 1); 
		END
		ELSE
		BEGIN
			INSERT INTO UserGameItems (ItemId, UserGameId) 
				   SELECT Id, @userGameId 
				     FROM Items 
				    WHERE MinLevel BETWEEN @minLevel AND @maxLevel; 
    
			IF ((SELECT COUNT(*) FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel) <> @@ROWCOUNT)
			BEGIN
				ROLLBACK; 
				RAISERROR('Could not buy items', 16, 1); 
			END	
			ELSE 
				COMMIT;
		END
END

-- Items LEVEL 19-21
SET @minLevel = 19; 
SET @maxLevel = 21;

SET @availableCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
SET @itemsCost = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel);

IF (@availableCash >= @itemsCost AND @userGameLevel >= @maxLevel) 
BEGIN 
	BEGIN TRANSACTION  
		UPDATE UsersGames 
		   SET Cash -= @itemsCost 
		 WHERE Id = @userGameId; 
	
		IF (@@ROWCOUNT <> 1) 
		BEGIN
			ROLLBACK; 
			RAISERROR('Could not make payment', 16, 1); 
		END
		ELSE
		BEGIN
			INSERT INTO UserGameItems (ItemId, UserGameId) 
				   SELECT Id, @userGameId 
				     FROM Items 
				    WHERE MinLevel BETWEEN @minLevel AND @maxLevel;
			   
			IF ((SELECT COUNT(*) FROM Items WHERE MinLevel BETWEEN @minLevel AND @maxLevel) <> @@ROWCOUNT)
			BEGIN
				ROLLBACK; 
				RAISERROR('Could not buy items', 16, 1); 
			END	
			ELSE 
				COMMIT;
		END
END

    SELECT i.Name AS [Item Name]
      FROM UserGameItems AS ugi
INNER JOIN Items AS i ON i.Id = ugi.ItemId
     WHERE ugi.UserGameId = @userGameId
  ORDER BY [Item Name];