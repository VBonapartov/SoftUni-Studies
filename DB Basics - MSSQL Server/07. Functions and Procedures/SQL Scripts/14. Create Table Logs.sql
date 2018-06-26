/* 14. Create Table Logs */
USE [Bank]
GO

CREATE TABLE Logs
(
  LogId     INT NOT NULL IDENTITY,
  AccountId INT NOT NULL,
  OldSum    DECIMAL(15, 2) NOT NULL,
  NewSum    DECIMAL(15, 2) NOT NULL
    
	CONSTRAINT PK_Logs PRIMARY KEY(LogId)
)
GO

CREATE TRIGGER tr_LogBalanceChange
ON Accounts
AFTER UPDATE
AS
BEGIN
  INSERT INTO Logs (AccountId, OldSum, NewSum)
       SELECT i.AccountHolderId, d.Balance, i.Balance
         FROM inserted AS i, deleted AS d
END
GO

UPDATE Accounts
   SET Balance += 10
 WHERE Id = 1;
GO

SELECT * FROM Logs;





