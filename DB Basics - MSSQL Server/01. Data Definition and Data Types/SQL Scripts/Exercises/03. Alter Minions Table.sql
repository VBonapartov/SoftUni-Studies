/* 03. Alter Minions Table */
USE [Minions]
GO

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
GO