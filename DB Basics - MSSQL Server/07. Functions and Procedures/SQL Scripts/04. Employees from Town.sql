/* 04. Employees from Town */
USE [SoftUni]
GO

CREATE PROC usp_GetEmployeesFromTown @TownName VARCHAR(50)
AS
BEGIN
  	SELECT e.FirstName AS [First Name],
  		     e.LastName AS [Last Name]
	    FROM Employees AS e
INNER JOIN Addresses AS a ON a.AddressID = e.AddressID
INNER JOIN Towns AS t ON t.TownID = a.TownID
	   WHERE t.Name LIKE @TownName
END

EXEC usp_GetEmployeesFromTown 'Sofia';