/* 5. Create a Function */
USE [Bank]
GO

CREATE FUNCTION f_CalculateTotalBalance (@ClientID INT)
RETURNS DECIMAL(15, 2)
BEGIN
	DECLARE @result AS DECIMAL(15, 2) = 
	(
	  SELECT SUM(Balance) 
	    FROM Accounts 
	   WHERE ClientId = @ClientID
	)	
	RETURN @result
END
Go

SELECT dbo.f_CalculateTotalBalance(4) AS Balance;
GO
