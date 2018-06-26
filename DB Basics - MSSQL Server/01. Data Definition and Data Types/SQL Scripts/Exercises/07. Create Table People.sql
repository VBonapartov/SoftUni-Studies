/* 07. Create Table People */
USE [Minions]
GO

CREATE TABLE People
(
	Id         INT PRIMARY KEY IDENTITY,
	Name       NVARCHAR(200) NOT NULL,
	Picture    VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024),
	Height	   DECIMAL(3, 2),
	Weight     DECIMAL(5, 2), 
	Gender     CHAR(1) CHECK([Gender] IN('M', 'F')) NOT NULL,
	Birthdate  DATE NOT NULL,
	Biography  NVARCHAR(MAX)
)
GO

INSERT INTO People(Name, Gender, Birthdate)
VALUES 
	('Ivan Ivanov', 'M', '1980-01-12'), 
	('Nadya Georgieva', 'F', '1990-07-06'),
	('Alina Petrova', 'F', '1993-09-01'),
	('Georgi Todorov', 'M', '1976-11-12'),
	('Anatoli Aleksandrov', 'M', '1988-03-21')
GO