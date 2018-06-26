/* 01. One-To-One Relationship */
CREATE DATABASE TableRelations;
GO

USE [TableRelations]
GO

CREATE TABLE Persons
(
	PersonID   INT IDENTITY NOT NULL,
	FirstName  VARCHAR(50) NOT NULL,
	Salary	   DECIMAL(10, 2),
	PassportID INT NOT NULL
);

CREATE TABLE Passports
(
	PassportID	   INT IDENTITY(101, 1) NOT NULL,
	PassportNumber VARCHAR(10) NOT NULL
);

ALTER TABLE Passports
ADD PRIMARY KEY (PassportID);

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID),
CONSTRAINT FK_PersonsPassports 
FOREIGN KEY (PassportID) REFERENCES Passports(PassportID);

INSERT INTO Passports
VALUES ('N34FG21B'),
	     ('K65LO4R7'),
	     ('ZE657QP2');

INSERT INTO Persons
VALUES ('Roberto', 43300.00, 102),
	     ('Tom', 56100.00, 103),
	     ('Yana', 60200.00, 101);

--DROP TABLE Persons;
--DROP TABLE Passports;

	