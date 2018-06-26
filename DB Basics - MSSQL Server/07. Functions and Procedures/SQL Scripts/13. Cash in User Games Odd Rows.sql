/* 13. Cash in User Games Odd Rows */
USE [Diablo]
GO

CREATE FUNCTION ufn_CashInUsersGames  
(	
	@gameName VARCHAR(MAX)
)
RETURNS @ResultTable TABLE (SumCash MONEY)
AS
BEGIN
	DECLARE @CashSum MONEY;

	SET @CashSum = 
	(
		SELECT SUM(ug.Cash) AS 'SumCash'
		  FROM (
    				SELECT GameId,
    				       Cash, 					    
    					     ROW_NUMBER() OVER (ORDER BY Cash DESC) AS [RowNumber]
    				  FROM UsersGames
    				 WHERE GameId = (SELECT Id FROM Games WHERE Name = @gameName)
				   ) AS ug
		 WHERE ug.RowNumber % 2 != 0
	)

	INSERT @ResultTable 
	SELECT @CashSum
	RETURN
END
GO

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist');

SELECT * 
  INTO TestTable 
  FROM dbo.ufn_CashInUsersGames('Love in a mist');

SELECT * FROM TestTable;

DROP TABLE TestTable;

  		