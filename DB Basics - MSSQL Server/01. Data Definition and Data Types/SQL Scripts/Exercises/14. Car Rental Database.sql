/* 14. Car Rental Database */
CREATE DATABASE CarRental COLLATE Cyrillic_General_100_CI_AS;
GO

USE CarRental
GO

CREATE TABLE Categories  
(
	Id           INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate	   DECIMAL(10, 2),
	WeeklyRate	 DECIMAL(10, 2),
	MonthlyRate	 DECIMAL(10, 2), 
	WeekendRate	 DECIMAL(10, 2)
)
GO

INSERT INTO Categories(CategoryName)
VALUES 
	('Category 1'),
	('Category 2'),
	('Category 3')
GO

CREATE TABLE Cars  
(
	Id           INT PRIMARY KEY IDENTITY,
	PlateNumber	 VARCHAR(50) NOT NULL, 
	Manufacturer VARCHAR(50) NOT NULL, 
	Model		     VARCHAR(50) NOT NULL, 
	CarYear		   INT NOT NULL, 
	CategoryId	 INT FOREIGN KEY REFERENCES Categories(Id), 
	Doors		     TINYINT, 
	Picture		   VARBINARY(MAX), 
	Condition	   NVARCHAR(100), 
	Available	   BIT NOT NULL DEFAULT 1
)
GO

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId)
VALUES 
	('A1234CT', 'Audi', 'A3', '2002', 2),
	('P4343AB', 'BMW', '525', '2004', 3),
	('CB3891TM', 'Volkswagen', 'Passat', '1996', 1)
GO

CREATE TABLE Employees  
(
	Id         INT PRIMARY KEY IDENTITY,
	FirstName	 NVARCHAR(50) NOT NULL, 
	LastName   NVARCHAR(50) NOT NULL, 
	Title		   NVARCHAR(50) NOT NULL,
	Notes		   NVARCHAR(MAX)
)
GO

INSERT INTO Employees(FirstName, LastName, Title)
VALUES 
	('Ivan', 'Ivanov', 'Manager'),
	('Petar', 'Georgiev', 'Director'),
	('Stoyan', 'Petev', 'Supervisor')
GO

CREATE TABLE Customers   
(
	Id					        INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber	VARCHAR(50) UNIQUE NOT NULL,
	FullName			      NVARCHAR(100) NOT NULL, 
	Address				      NVARCHAR(100) NOT NULL, 
	City				        NVARCHAR(50), 
	ZIPCode				      NVARCHAR(50), 
	Notes				        NVARCHAR(MAX)
)
GO

INSERT INTO Customers(DriverLicenceNumber, FullName, Address)
VALUES 
	('N1234TR619', 'Stanimir Georgiev', 'Sofia, bul. Tsariradsko Shose 123'),
	('7619ABTR6S', 'Milena Todorova', 'Plovdiv, bul. Botevgradsko Shose 456'),
	('A6140Y6316', 'Anelia Tihomirova', 'Ruse, str. Rila 14')
GO

CREATE TABLE RentalOrders    
(
	Id					     INT PRIMARY KEY IDENTITY,
	EmployeeId			 INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId			 INT FOREIGN KEY REFERENCES Customers(Id),
	CarId				     INT FOREIGN KEY REFERENCES Cars(Id), 
	TankLevel			   DECIMAL(5, 2),
	KilometrageStart INT,
	KilometrageEnd   INT,
	TotalKilometrage INT,
	StartDate			   DATE NOT NULL,
	EndDate				   DATE NOT NULL,
	TotalDays			   AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied			 DECIMAL(10, 2), 
	TaxRate				   DECIMAL(10, 2),
	OrderStatus			 NVARCHAR(50),
	Notes				     NVARCHAR(MAX)
)
GO

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, StartDate, EndDate)
VALUES 
	(1, 1, 2, '2016-04-12', '2016-04-14'),
	(2, 3, 1, '2016-09-07', '2016-09-08'),
	(3, 2, 3, '2016-11-11', '2016-11-12')
GO