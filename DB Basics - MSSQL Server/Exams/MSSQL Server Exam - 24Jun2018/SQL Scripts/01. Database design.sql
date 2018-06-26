/* 01. Database design */

CREATE DATABASE TripService

USE [TripService]
GO

CREATE TABLE Cities
(
	Id				   INT NOT NULL IDENTITY,
	[Name]			 NVARCHAR(20) NOT NULL,
	CountryCode  CHAR(2) NOT NULL
	
	CONSTRAINT PK_Cities PRIMARY KEY (Id)
)

CREATE TABLE Hotels
(
	Id             INT NOT NULL IDENTITY,
	[Name]			   NVARCHAR(30) NOT NULL,
	CityId			   INT NOT NULL,
	EmployeeCount	 INT NOT NULL,
	BaseRate		   DECIMAL(10, 2)

	CONSTRAINT PK_Hotels PRIMARY KEY (Id),

	CONSTRAINT FK_Hotels_Cities
	FOREIGN KEY (CityId) REFERENCES Cities(Id)
)

CREATE TABLE Rooms
(
	Id       INT NOT NULL IDENTITY,
	Price		 DECIMAL(10, 2) NOT NULL,
	[Type]	 NVARCHAR(20) NOT NULL,
	Beds		 INT NOT NULL,
	HotelId	 INT NOT NULL	

	CONSTRAINT PK_Rooms PRIMARY KEY (Id),

	CONSTRAINT FK_Rooms_Hotels
	FOREIGN KEY (HotelId) REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id           INT NOT NULL IDENTITY,
	RoomId		   INT NOT NULL,
	BookDate	   DATE NOT NULL,
	ArrivalDate	 DATE NOT NULL,
	ReturnDate	 DATE NOT NULL,
	CancelDate	 DATE

	CONSTRAINT PK_Trips PRIMARY KEY (Id),

	CONSTRAINT FK_Trips_Rooms
	FOREIGN KEY (RoomId) REFERENCES Rooms(Id),

	CONSTRAINT CHK_Trips_BookDate CHECK(BookDate < ArrivalDate),

	CONSTRAINT CHK_Trips_ArrivalDate CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id         INT PRIMARY KEY IDENTITY,
	FirstName  NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName   NVARCHAR(50) NOT NULL,
	CityId     INT NOT NULL,
	BirthDate  DATE NOT NULL,
	Email      VARCHAR(100) NOT NULL UNIQUE

	CONSTRAINT FK_Accounts_Cities
	FOREIGN KEY (CityId) REFERENCES Cities(Id)
)

CREATE TABLE AccountsTrips
(
	AccountId	INT NOT NULL,
	TripId		INT NOT NULL,
	Luggage		INT NOT NULL CHECK(Luggage >= 0)

	CONSTRAINT PK_AccountsTrips PRIMARY KEY (AccountId, TripId),

	CONSTRAINT FK_AccountsTrips_Accounts
	FOREIGN KEY (AccountId) REFERENCES Accounts(Id),

	CONSTRAINT FK_AccountsTrips_Trips
	FOREIGN KEY (TripId) REFERENCES Trips(Id)
)