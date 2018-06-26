/* 18. *3rd Highest Salary */
USE [SoftUni]
GO

SELECT DISTINCT DepartmentID, Salary
  FROM (
  		   SELECT DepartmentID, 
  			        Salary,
  			        DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
  		     FROM Employees
	     ) AS e
 WHERE Rank = 3;
