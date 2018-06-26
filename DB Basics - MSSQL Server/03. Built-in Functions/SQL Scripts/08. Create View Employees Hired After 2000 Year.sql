/* 08. Create View Employees Hired After 2000 Year */
USE [SoftUni]
GO

CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT FirstName, LastName
  FROM Employees
 WHERE DATEPART(YEAR, HireDate) > 2000
