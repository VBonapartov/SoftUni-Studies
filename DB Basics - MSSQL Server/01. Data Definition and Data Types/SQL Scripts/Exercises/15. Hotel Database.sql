/* 15. Hotel Database */
CREATE DATABASE Hotel COLLATE Cyrillic_General_100_CI_AS;
GO

USE Hotel
GO

CREATE TABLE Employees  
(
	Id         INT IDENTITY,
	FirstName	 NVARCHAR(50) NOT NULL, 
	LastName	 NVARCHAR(50) NOT NULL, 
	Title		   NVARCHAR(50) NOT NULL,
	Notes		   NVARCHAR(MAX),

	CONSTRAINT PK_Employees PRIMARY KEY (Id)
)
GO

INSERT INTO Employees (FirstName, LastName, Title)
VALUES 
	('Ivan', 'Ivanov', 'Manager'),
	('Petar', 'Georgiev', 'Director'),
	('Stoyan', 'Petev', 'Supervisor')
GO

CREATE TABLE Customers   
(
	AccountNumber    INT IDENTITY,
	FirstName		     NVARCHAR(50) NOT NULL, 
	LastName		     NVARCHAR(50) NOT NULL, 
	PhoneNumber		   VARCHAR(50), 
	EmergencyName	   NVARCHAR(50) NOT NULL, 
	EmergencyNumber	 INT NOT NULL, 
	Notes			       NVARCHAR(MAX),

	CONSTRAINT PK_Customers PRIMARY KEY (AccountNumber)
)
GO

INSERT INTO Customers (FirstName, LastName, EmergencyName, EmergencyNumber)
VALUES
	('First','Name', 'EmergencyName 1', 1111),
	('Second','Name', 'EmergencyName 2', 2222),
	('Third','Name', 'EmergencyName 3', 3333)
GO

CREATE TABLE RoomStatus  
(
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes      NVARCHAR(MAX)
)
GO

INSERT INTO RoomStatus (RoomStatus)
VALUES 
	('Free'),
	('Reserved'),
	('In use')
GO

CREATE TABLE RoomTypes  
(
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes    NVARCHAR(MAX)
)
GO

INSERT INTO RoomTypes (RoomType)
VALUES 
	('Casual'),
	('Studio'),
	('Deluxe')
GO

CREATE TABLE BedTypes  
(
	BedType	 NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes	   NVARCHAR(MAX)
)
GO

INSERT INTO BedTypes (BedType)
VALUES 
	('Double'),
	('Queen'),
	('King')
GO

CREATE TABLE Rooms  
(
	RoomNumber	INT IDENTITY,
	RoomType	  NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType), 
	BedType		  NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType), 
	Rate		    DECIMAL(10, 2), 
	RoomStatus	NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus), 
	Notes		    NVARCHAR(MAX),

	CONSTRAINT PK_Rooms PRIMARY KEY (RoomNumber)
)
GO

INSERT INTO Rooms (RoomType, BedType, RoomStatus)
VALUES 
	('Casual', 'Double', 'Free'),
	('Studio', 'Queen', 'In use'),
	('Deluxe', 'King', 'Reserved')
GO

CREATE TABLE Payments 
(
	Id					      INT IDENTITY, 
	EmployeeId			  INT NOT NULL, 
	PaymentDate			  DATE NOT NULL, 
	AccountNumber		  INT NOT NULL, 
	FirstDateOccupied	DATE NOT NULL, 
	LastDateOccupied	DATE NOT NULL, 
	TotalDays			    INT NOT NULL, 
	AmountCharged		  DECIMAL(10, 2) NOT NULL, 
	TaxRate				    DECIMAL(10, 2) NOT NULL, 
	TaxAmount			    DECIMAL(10, 2) NOT NULL, 
	PaymentTotal		  DECIMAL(10, 2) NOT NULL, 
	Notes				      NVARCHAR(MAX),
	
	PRIMARY KEY (Id),
	FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
	FOREIGN KEY (AccountNumber) REFERENCES Customers (AccountNumber),
	
	CHECK (TotalDays = DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied)),
	CONSTRAINT CK_Payments_TaxAmount CHECK (TaxAmount = AmountCharged * TaxRate), 
	CONSTRAINT CK_Payments_PaymentTotal CHECK (PaymentTotal = AmountCharged + TaxAmount)
)
GO

INSERT INTO Payments (EmployeeId, 
					  PaymentDate, 
					  AccountNumber, 
					  FirstDateOccupied, 
					  LastDateOccupied, 
					  TotalDays, 
					  AmountCharged, 
					  TaxRate, 
					  TaxAmount, 
					  PaymentTotal)
VALUES
	(1, '2018-01-10', 1, '2018-01-09', '2018-01-10', 1, 100, 0.20, 20, 120),
	(2, '2018-01-10', 2, '2018-01-08', '2018-01-10', 2, 200, 0.20, 40, 240),
	(3, '2018-01-10', 3, '2018-01-07', '2018-01-10', 3, 300, 0.20, 60, 360)
GO

CREATE TABLE Occupancies
(
	Id				    INT IDENTITY, 
	EmployeeId		INT NOT NULL, 
	DateOccupied	DATE NOT NULL, 
	AccountNumber	INT NOT NULL, 
	RoomNumber		INT NOT NULL, 
	RateApplied		DECIMAL(10, 2) NOT NULL, 
	PhoneCharge		DECIMAL(10, 2) NOT NULL DEFAULT 0, 
	Notes			    NVARCHAR(MAX),

	PRIMARY KEY (Id),
	FOREIGN KEY (EmployeeId) REFERENCES Employees (Id),
	FOREIGN KEY (AccountNumber) REFERENCES Customers (AccountNumber),
	FOREIGN KEY (RoomNumber) REFERENCES Rooms (RoomNumber),
	CHECK (PhoneCharge >= 0)	
)
GO

INSERT INTO Occupancies (EmployeeId, 
						 DateOccupied, 
						 AccountNumber, 
						 RoomNumber, 
						 RateApplied, 
						 PhoneCharge)
VALUES
	(1, '2018-01-10', 1, 1, 70, 0),
	(2, '2018-01-10', 2, 2, 100, 5),
	(3, '2018-01-10', 3, 3, 110, 10)
GO

