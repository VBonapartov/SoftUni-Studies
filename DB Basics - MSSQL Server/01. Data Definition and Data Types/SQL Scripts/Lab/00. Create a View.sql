/* 4. Create a View */
USE [Bank]
GO

CREATE VIEW v_ClientBalances AS
				SELECT	(FirstName + ' ' + LastName) AS [Name], 
						(AccountTypes.Name) AS [Account Type], 
						Balance 
FROM Clients
JOIN Accounts ON Clients.Id = Accounts.ClientId
JOIN AccountTypes ON AccountTypes.Id = Accounts.AccountTypeId
GO

SELECT * FROM v_ClientBalances;
GO
