/* 01. Database design */

CREATE DATABASE Bakery;

USE [Bakery]
GO

CREATE TABLE Countries
(
	Id		INT PRIMARY KEY IDENTITY(1, 1),
	[Name]	NVARCHAR(50) UNIQUE
)

CREATE TABLE Products
(
	Id				INT NOT NULL IDENTITY(1, 1),
	[Name]			NVARCHAR(25) NOT NULL UNIQUE,
	[Description]	NVARCHAR(250),
	Recipe			NVARCHAR(MAX),
	Price			MONEY CHECK(Price >= 0)

	CONSTRAINT PK_Products PRIMARY KEY (Id)
)

CREATE TABLE Customers
(
	Id			INT NOT NULL IDENTITY(1, 1),
	FirstName	NVARCHAR(25),
	LastName	NVARCHAR(25),
	Gender		CHAR(1) CHECK(Gender IN ('M', 'F')),
	Age			INT,
	PhoneNumber CHAR(10),
	CountryId	INT NOT NULL

	CONSTRAINT PK_Customers PRIMARY KEY (Id),

	CONSTRAINT FK_Customers_Countries 
	FOREIGN KEY (CountryId) REFERENCES Countries (Id)
)

CREATE TABLE Feedbacks
(
	Id				INT NOT NULL IDENTITY(1, 1),
	[Description]	NVARCHAR(255),
	Rate			DECIMAL(10, 2) CHECK(Rate >= 0 AND Rate <= 10),
	ProductId		INT NOT NULL,
	CustomerId		INT NOT NULL

	CONSTRAINT PK_Feedbacks PRIMARY KEY (Id),

	CONSTRAINT FK_Feedbacks_Products
	FOREIGN KEY (ProductId) REFERENCES Products (Id),

	CONSTRAINT FK_Feedbacks_Customers 
	FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
)

CREATE TABLE Distributors
(
	Id			INT NOT NULL IDENTITY(1, 1),
	[Name]		NVARCHAR(25) NOT NULL UNIQUE,
	AddressText	NVARCHAR(30),
	Summary		NVARCHAR(200),
	CountryId	INT NOT NULL

	CONSTRAINT PK_Distributors PRIMARY KEY (Id),

	CONSTRAINT FK_Distributors_Countries
	FOREIGN KEY (CountryId) REFERENCES Countries (Id)
)

CREATE TABLE Ingredients
(
	Id				INT NOT NULL IDENTITY(1, 1),
	[Name]			NVARCHAR(30),
	[Description]	NVARCHAR(200),
	OriginCountryId INT NOT NULL,
	DistributorId	INT NOT NULL

	CONSTRAINT PK_Ingredients PRIMARY KEY (Id),

	CONSTRAINT FK_Ingredients_Countries
	FOREIGN KEY (OriginCountryId) REFERENCES Countries (Id),

	CONSTRAINT FK_Ingredients_Distributors
	FOREIGN KEY (DistributorId) REFERENCES Distributors (Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId		INT NOT NULL,
	IngredientId	INT NOT NULL

	CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId, IngredientId),

	CONSTRAINT FK_ProductsIngredients_Products
	FOREIGN KEY (ProductId) REFERENCES Products (Id),

	CONSTRAINT FK_ProductsIngredients_Ingredients
	FOREIGN KEY (IngredientId) REFERENCES Ingredients (Id)
)