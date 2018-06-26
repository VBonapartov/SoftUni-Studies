/* 22. Delete Employees */
USE [SoftUni]
GO

CREATE TABLE Deleted_Employees
(
	EmployeeId   INT IDENTITY NOT NULL, 
	FirstName    VARCHAR(50) NOT NULL, 
	LastName     VARCHAR(50) NOT NULL, 
	MiddleName   VARCHAR(50), 
	JobTitle     VARCHAR(100), 
	DepartmentId INT NOT NULL, 
	Salary       DECIMAL(15, 2)

	CONSTRAINT PK_Deleted_Employees PRIMARY KEY (EmployeeId),

	CONSTRAINT FK_Deleted_Employees_Departments FOREIGN KEY(DepartmentId) 
	REFERENCES Departments(DepartmentId)
)
GO

CREATE TRIGGER tr_SaveDeletedEmployees
ON Employees
AFTER DELETE
AS
BEGIN
  INSERT INTO Deleted_Employees
       SELECT d.FirstName, 
              d.LastName, 
				      d.MiddleName, 
				      d.JobTitle, 
				      d.DepartmentID, 
				      d.Salary
		     FROM deleted AS d; 
END
