/* 10. People with Balance Higher Than */
USE [Bank]
GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@minBalance DECIMAL(15, 4))
AS
BEGIN
  WITH CTE_AccountHolderBalance(AccountHolderId, Balance)
  AS
  (
    SELECT AccountHolderId, SUM(Balance) AS TotalBalance
      FROM Accounts
  GROUP BY AccountHolderId 
  )  

       SELECT FirstName, LastName
         FROM AccountHolders AS ah
   INNER JOIN CTE_AccountHolderBalance AS cab ON cab.AccountHolderId = ah.Id
        WHERE cab.Balance > @minBalance
     ORDER BY ah.LastName, ah.FirstName;
END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 1000000;
