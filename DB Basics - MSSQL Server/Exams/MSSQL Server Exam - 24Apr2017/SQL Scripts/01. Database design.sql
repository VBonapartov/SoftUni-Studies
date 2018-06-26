/* 01. Database design */

CREATE DATABASE WMS

USE [WMS]
GO

CREATE TABLE Clients
(
	ClientId	INT NOT NULL IDENTITY,
	FirstName	VARCHAR(50) NOT NULL,
	LastName	VARCHAR(50) NOT NULL,
	Phone		  CHAR(12) NOT NULL

	CONSTRAINT PK_Clients PRIMARY KEY (ClientId)
)

CREATE TABLE Mechanics
(
	MechanicId	INT NOT NULL IDENTITY,
	FirstName	  VARCHAR(50) NOT NULL,
	LastName	  VARCHAR(50) NOT NULL,
	[Address]	  VARCHAR(255) NOT NULL

	CONSTRAINT PK_Mechanics PRIMARY KEY (MechanicId)
)

CREATE TABLE Models
(
	ModelId		INT PRIMARY KEY IDENTITY,
	[Name]		VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId		    INT NOT NULL IDENTITY,
	ModelId		  INT NOT NULL,
	[Status]	  VARCHAR(11) CHECK(Status IN ('Pending', 'In Progress', 'Finished')) DEFAULT('Pending'),
	ClientId	  INT NOT NULL,
	MechanicId	INT,
	IssueDate	  DATE NOT NULL,
	FinishDate	DATE

	CONSTRAINT PK_Jobs PRIMARY KEY (JobId),

	CONSTRAINT FK_Jobs_Models 
	FOREIGN KEY (ModelId) REFERENCES Models(ModelId),

	CONSTRAINT FK_Jobs_Clients 
	FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),

	CONSTRAINT FK_Jobs_Mechanics 
	FOREIGN KEY (MechanicId) REFERENCES Mechanics(MechanicId)
)

CREATE TABLE Orders
(
	OrderId		INT NOT NULL IDENTITY,
	JobId		  INT NOT NULL,
	IssueDate	DATE,
	Delivered	BIT DEFAULT(0) NOT NULL

	CONSTRAINT PK_Orders PRIMARY KEY (OrderId),

	CONSTRAINT FK_Orders_Jobs
	FOREIGN KEY (JobId) REFERENCES Jobs(JobId)
)

CREATE TABLE Vendors
(
	VendorId	INT PRIMARY KEY IDENTITY,
	[Name]		VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId			  INT PRIMARY KEY IDENTITY,
	SerialNumber	VARCHAR(50) NOT NULL UNIQUE,
	[Description]	VARCHAR(255),
	Price			    DECIMAL(6, 2) CHECK(Price > 0 AND Price < 10000) NOT NULL,
	VendorId		  INT NOT NULL,
	StockQty		  INT NOT NULL DEFAULT(0) CHECK(StockQty >= 0)

	CONSTRAINT FK_Parts_Vendors
	FOREIGN KEY (VendorId) REFERENCES Vendors(VendorId)
)

CREATE TABLE OrderParts
(
	OrderId		INT NOT NULL,
	PartId		INT NOT NULL,
	Quantity	INT NOT NULL DEFAULT(1) CHECK(Quantity > 0)

	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId),

	CONSTRAINT FK_OrderParts_Orders
	FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),

	CONSTRAINT FK_OrderParts_Parts
	FOREIGN KEY (PartId) REFERENCES Parts(PartId)
)

CREATE TABLE PartsNeeded
(
	JobId		  INT NOT NULL,
	PartId		INT NOT NULL,
	Quantity	INT NOT NULL DEFAULT(1) CHECK(Quantity > 0)

	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId),

	CONSTRAINT FK_PartsNeeded_Jobs
	FOREIGN KEY (JobId) REFERENCES Jobs(JobId),

	CONSTRAINT FK_PartsNeeded_Parts
	FOREIGN KEY (PartId) REFERENCES Parts(PartId)
)