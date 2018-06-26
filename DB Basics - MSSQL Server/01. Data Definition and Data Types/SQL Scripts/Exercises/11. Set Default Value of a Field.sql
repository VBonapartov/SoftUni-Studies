/* 11. Set Default Value of a Field */
USE [Minions]
GO

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime
GO