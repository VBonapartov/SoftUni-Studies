/* 16. Create SoftUni Database */
CREATE DATABASE SoftUni COLLATE Cyrillic_General_100_CI_AS;
GO

USE SoftUni
GO

CREATE TABLE Towns  
(
	Id		INT IDENTITY,
	Name	NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_Towns PRIMARY KEY (Id)	
)
GO

CREATE TABLE Addresses  
(
	Id			     INT IDENTITY,
	AddressText  NVARCHAR(100) NOT NULL,
	TownId		   INT NOT NULL,
	
	CONSTRAINT PK_Addresses PRIMARY KEY (Id),
	CONSTRAINT FK_Addresses_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id)	
)
GO

CREATE TABLE Departments  
(
	Id		INT IDENTITY,
	Name	NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_Departments PRIMARY KEY (Id)	
)
GO

CREATE TABLE Employees  
(
	Id				   INT IDENTITY,
	FirstName		 NVARCHAR(50) NOT NULL,
	MiddleName	 NVARCHAR(50), 
	LastName		 NVARCHAR(50) NOT NULL, 
	JobTitle		 NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL, 
	HireDate     DATE NOT NULL,
	Salary       DECIMAL(10, 2) NOT NULL,
	AddressId		 INT

	CONSTRAINT PK_Employees PRIMARY KEY (Id),
	CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
	CONSTRAINT FK_Employees_Addresses FOREIGN KEY (AddressId) REFERENCES Addresses(Id),
	CONSTRAINT CK_Employees_Salary CHECK (Salary >= 0)	
)
GO