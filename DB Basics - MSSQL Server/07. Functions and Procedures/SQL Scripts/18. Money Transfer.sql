/* 18. Money Transfer */
USE [Bank]
GO

CREATE PROCEDURE usp_TransferMoney
(
	@senderId INT, 
	@receiverId INT, 
	@amount DECIMAL(15, 4)
)
AS
BEGIN
  IF(@amount < 0)
    BEGIN
		  RAISERROR('Cannot transfer negative amount', 16, 1);
		  RETURN;
    END;

    DECLARE @SenderBalance DECIMAL(15, 4);
	  SET @SenderBalance = (SELECT Balance FROM Accounts WHERE Id = @senderId);

	  IF(@SenderBalance - @amount >= 0)
      BEGIN
		    EXEC dbo.usp_WithdrawMoney @senderId, @amount;
		    EXEC dbo.usp_DepositMoney @receiverId, @amount;				
	    END;
    ELSE
		  RAISERROR('Insufficient Funds', 16, 1);
END;

EXEC dbo.usp_TransferMoney 1, 2, 20;




