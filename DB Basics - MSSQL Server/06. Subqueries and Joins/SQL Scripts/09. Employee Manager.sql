/* 09. Employee Manager */
USE [SoftUni]
GO

    SELECT e.EmployeeID,
    		   e.FirstName,
    		   e.ManagerID,
    		   m.FirstName AS [ManagerName]
      FROM Employees AS e
INNER JOIN Employees AS m
        ON m.EmployeeID = e.ManagerID
	   WHERE e.ManagerID IN (3, 7)
  ORDER BY e.EmployeeID;