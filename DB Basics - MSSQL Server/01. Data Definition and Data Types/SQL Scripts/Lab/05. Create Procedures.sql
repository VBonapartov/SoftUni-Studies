/* 6. Create Procedures */
USE [Bank]
GO

/* Add Account Procedure */
CREATE PROC p_AddAccount @ClientId INT, @AccountTypeId INT 
AS
BEGIN
	INSERT INTO Accounts (ClientId, AccountTypeId) 
	VALUES (@ClientId, @AccountTypeId)
END
GO

EXEC p_AddAccount 2, 2;
GO

EXEC p_AddAccount 2, 2;
GO

SELECT * FROM Accounts
GO

/* Deposit Procedure */
CREATE PROC p_Deposit @AccountId INT, @Amount DECIMAL(15, 2) 
AS
BEGIN
	UPDATE Accounts
	   SET Balance += @Amount
	 WHERE Id = @AccountId
END
GO

EXEC p_Deposit 7, 50;
GO

/* Withdraw Procedure */
CREATE PROC p_Withdraw @AccountId INT, @Amount DECIMAL(15, 2) 
AS
BEGIN
	DECLARE @OldBalance DECIMAL(15, 2)
	SELECT @OldBalance = Balance FROM Accounts WHERE Id = @AccountId
	IF (@OldBalance - @Amount >= 0)
	BEGIN
		UPDATE Accounts
		   SET Balance -= @Amount
		 WHERE Id = @AccountId
	END
	ELSE
	BEGIN
		RAISERROR('Insufficient funds', 10, 1)
	END
END
GO

EXEC p_Withdraw 7, 50;
GO


