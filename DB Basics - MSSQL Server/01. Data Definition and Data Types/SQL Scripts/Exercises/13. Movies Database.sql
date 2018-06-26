/* 13. Movies Database */
CREATE DATABASE Movies COLLATE Cyrillic_General_100_CI_AS;
GO

USE Movies
GO

CREATE TABLE Directors 
(
	Id           INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes	       NVARCHAR(MAX)
)
GO

INSERT INTO Directors(DirectorName)
VALUES 
	('Director 1'),
	('Director 2'),
	('Director 3'),
	('Director 4'),
	('Director 5')
GO

CREATE TABLE Genres 
(
	Id         INT PRIMARY KEY IDENTITY,
	GenreName  NVARCHAR(50) NOT NULL,
	Notes	     NVARCHAR(MAX)
)
GO

INSERT INTO Genres(GenreName)
VALUES 
	('Genre 1'),
	('Genre 2'),
	('Genre 3'),
	('Genre 4'),
	('Genre 5')
GO

CREATE TABLE Categories 
(
	Id			     INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes	       NVARCHAR(MAX)
)
GO

INSERT INTO Categories(CategoryName)
VALUES 
	('Category 1'),
	('Category 2'),
	('Category 3'),
	('Category 4'),
	('Category 5')
GO

CREATE TABLE Movies  
(
	Id             INT PRIMARY KEY IDENTITY,	
	Title			     NVARCHAR(100) NOT NULL,	 
	DirectorId		 INT FOREIGN KEY REFERENCES Directors(Id), 
	CopyrightYear	 INT, 
	Length         INT, 
	GenreId			   INT FOREIGN KEY REFERENCES Genres(Id), 
	CategoryId		 INT FOREIGN KEY REFERENCES Categories(Id),
	Rating			   INT,
	Notes			     NVARCHAR(MAX)
)
GO

INSERT INTO Movies(Title, DirectorId, GenreId, CategoryId)
VALUES 
	('Title 1', 1, 1, 1),
	('Title 2', 2, 3, 1),
	('Title 3', 4, 2, 2),
	('Title 4', 1, 5, 4),
	('Title 5', 5, 4, 3)
GO