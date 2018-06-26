/* 13. User Email Providers */
USE [Diablo]
GO

  SELECT Username,
		     RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], Username;