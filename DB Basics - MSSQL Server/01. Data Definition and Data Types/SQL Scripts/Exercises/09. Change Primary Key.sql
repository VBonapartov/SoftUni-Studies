/* 09. Change Primary Key */
USE [Minions]
GO

ALTER TABLE Users
DROP CONSTRAINT PK_Users
GO

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)
GO
