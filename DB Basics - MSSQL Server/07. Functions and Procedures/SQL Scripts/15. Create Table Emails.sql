/* 15. Create Table Emails */
USE [Bank]
GO

CREATE TABLE NotificationEmails
(
  Id        INT NOT NULL IDENTITY,
  Recipient	VARCHAR(100) NOT NULL,
  Subject		VARCHAR(100) NOT NULL,
  Body		  VARCHAR(MAX) NOT NULL
    
	CONSTRAINT PK_NotificationEmails PRIMARY KEY(Id)
)
GO

CREATE TRIGGER tr_EmailNotification
ON Logs
AFTER INSERT
AS
BEGIN
	INSERT NotificationEmails (Recipient, Subject, Body)
	SELECT inserted.AccountId, 
         CONCAT('Balance change for account: ', inserted.AccountId), 
		     CONCAT('On ', GETDATE(), ' your balance was changed from ', inserted.OldSum, ' to ', inserted.NewSum)
	  FROM inserted
END
GO

UPDATE Accounts
   SET Balance += 10
 WHERE Id = 1;
GO

SELECT * FROM Logs;
SELECT * FROM NotificationEmails;





