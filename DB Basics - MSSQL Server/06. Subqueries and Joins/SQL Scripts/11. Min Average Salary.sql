/* 11. Min Average Salary */
USE [SoftUni]
GO

SELECT MIN(DepartmensAvgSalary.AvgSalary) As MinAverageSalary
  FROM (
  		    SELECT DepartmentID, AVG(Salary) AS AvgSalary  
  			    FROM Employees
  		  GROUP BY DepartmentID
	     ) AS DepartmensAvgSalary;