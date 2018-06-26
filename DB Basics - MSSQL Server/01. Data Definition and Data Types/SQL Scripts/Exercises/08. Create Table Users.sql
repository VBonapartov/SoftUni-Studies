/* 08. Create Table Users */
USE [Minions]
GO

CREATE TABLE Users
(
	Id             BIGINT IDENTITY NOT NULL,
	Username		   VARCHAR(30) UNIQUE NOT NULL,
	[Password]	   VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime	 DATETIME2, 
	IsDeleted		   BIT NOT NULL DEFAULT(0)
)
GO

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(ID);
GO

ALTER TABLE Users
ADD CONSTRAINT CH_ProfilePicture CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024);
GO

INSERT INTO Users(Username, [Password])
VALUES 
	('Username1', 'pass1'), 
	('Username2', 'pass2'),
	('Username3', 'pass3'),
	('Username4', 'pass4'),
	('Username5', 'pass5')
GO