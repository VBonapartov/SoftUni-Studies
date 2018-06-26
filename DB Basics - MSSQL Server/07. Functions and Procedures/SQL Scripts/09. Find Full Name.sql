/* 09. Find Full Name */
USE [Bank]
GO

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(a.FirstName, ' ', a.LastName) AS [Full Name]
	  FROM AccountHolders AS a
END

EXEC dbo.usp_GetHoldersFullName;

