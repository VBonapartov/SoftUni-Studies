/* 05. Employees Without Project */
USE [SoftUni]
GO

         SELECT TOP(3)
    		        e.EmployeeID,
    		        e.FirstName
           FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep 
             ON ep.EmployeeID = e.EmployeeID
		      WHERE ep.EmployeeID IS NULL  
       ORDER BY e.EmployeeID;