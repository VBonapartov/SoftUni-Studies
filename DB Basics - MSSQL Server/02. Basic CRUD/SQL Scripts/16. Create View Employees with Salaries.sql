/* 16. Create View Employees with Salaries */
USE [SoftUni]
GO

CREATE VIEW V_EmployeesSalaries 
		     AS
  	 SELECT FirstName, LastName, Salary
  	   FROM Employees
GO

SELECT *
  FROM V_EmployeesSalaries;