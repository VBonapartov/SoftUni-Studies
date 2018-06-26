/* 17. Withdraw Money */
USE [Bank]
GO

CREATE PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN
	IF(@moneyAmount < 0)
    BEGIN
		  RAISERROR('Cannot withdraw negative value', 16, 1);
		  RETURN;
    END;
	ELSE
    BEGIN
		IF(@accountId IS NULL OR @moneyAmount IS NULL)
      BEGIN
        RAISERROR('Missing value', 16, 1);
			  RETURN;
      END;
    END;

    BEGIN TRANSACTION;
		  UPDATE Accounts
         SET Balance -= @moneyAmount
       WHERE Id = @accountId;

      IF(@@ROWCOUNT < 1)
        BEGIN
          ROLLBACK;
          RAISERROR('Account doesn''t exists', 16, 1);
			    RETURN;
        END;

      DECLARE @CurrentBalance DECIMAL(15, 4);
		  SET @CurrentBalance = (SELECT Balance FROM Accounts WHERE Id = @accountId);

		  IF(@CurrentBalance < 0)
		    BEGIN
          ROLLBACK;
          RAISERROR('Insufficient Funds', 16, 1);
			    RETURN;
        END;

    COMMIT TRANSACTION;
END;

EXEC dbo.usp_WithdrawMoney 1, 20;




