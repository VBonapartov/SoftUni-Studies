/* 17. Create View Employees with Job Titles */
USE [SoftUni]
GO

CREATE VIEW V_EmployeeNameJobTitle  
		     AS
  	 SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], 
  			    JobTitle AS [Job Title]
  	   FROM Employees;
GO

SELECT *
  FROM V_EmployeeNameJobTitle;