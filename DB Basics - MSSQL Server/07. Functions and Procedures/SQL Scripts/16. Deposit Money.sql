/* 16. Deposit Money */
USE [Bank]
GO

CREATE PROCEDURE usp_DepositMoney(@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN
	IF(@moneyAmount < 0)
    BEGIN
		  RAISERROR('Cannot deposit negative value', 16, 1);
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
         SET Balance += @moneyAmount
       WHERE Id = @accountId;

      IF(@@ROWCOUNT < 1)
        BEGIN
          ROLLBACK;
          RAISERROR('Account doesn''t exists', 16, 1);
			    RETURN;
        END;
    COMMIT TRANSACTION;
END;

EXEC dbo.usp_DepositMoney 1, 20;



