/* 07. Buy Items for User in Game */
USE [Diablo]
GO

DECLARE @gameName NVARCHAR(50) = 'Edinburgh';
DECLARE @username NVARCHAR(50) = 'Alex';
DECLARE @userGameId INT = 
(
		    SELECT ug.Id 
			    FROM UsersGames AS ug
	  INNER JOIN Users AS u ON ug.UserId = u.Id
	  INNER JOIN Games AS g ON ug.GameId = g.Id
		     WHERE u.Username = @username AND g.Name = @gameName
);

DECLARE @availableCash DECIMAL(15, 4) = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
DECLARE @purchasePrice DECIMAL(15, 4) = 
(
  SELECT SUM(Price) 
    FROM Items 
   WHERE Name IN 
		  (
		  'Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
		  'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'
		  )
); 

IF (@availableCash >= @purchasePrice) 
BEGIN 
  BEGIN TRANSACTION  

  UPDATE UsersGames 
     SET Cash -= @purchasePrice 
   WHERE Id = @userGameId; 

  IF(@@ROWCOUNT <> 1) 
  BEGIN
    ROLLBACK; 
	  RAISERROR('Could not make payment', 16, 1); 
	RETURN;
  END

  INSERT INTO UserGameItems (ItemId, UserGameId) 
  (
	SELECT Id, @userGameId 
	  FROM Items 
	 WHERE Name IN 
		(
		'Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
		'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'
		)
   ) 

  IF((SELECT COUNT(*) FROM Items WHERE Name IN 
    ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 
	'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')) <> @@ROWCOUNT)
  BEGIN
    ROLLBACK; 
	  RAISERROR('Could not buy items', 16, 1); 
	  RETURN;
  END	

  COMMIT;

END
ELSE
BEGIN
	RAISERROR('Insufficient funds', 16, 1);
END

	  SELECT u.Username, 
		       g.Name, 
		       ug.Cash, 
		       i.Name AS [Item Name]
	    FROM UsersGames AS ug
INNER JOIN Games AS g ON ug.GameId = g.Id
INNER JOIN Users AS u ON ug.UserId = u.Id
INNER JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
INNER JOIN Items AS i ON i.Id = ugi.ItemId
	   WHERE g.Name = @gameName