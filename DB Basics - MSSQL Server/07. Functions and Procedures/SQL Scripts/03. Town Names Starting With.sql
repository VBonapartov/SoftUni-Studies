/* 03. Town Names Starting With */
USE [SoftUni]
GO

CREATE PROC usp_GetTownsStartingWith @StartsWith VARCHAR(10)
AS
BEGIN
	SELECT Name AS [Town]
	  FROM Towns
	 WHERE Name LIKE @StartsWith + '%'
END

EXEC usp_GetTownsStartingWith 'b';