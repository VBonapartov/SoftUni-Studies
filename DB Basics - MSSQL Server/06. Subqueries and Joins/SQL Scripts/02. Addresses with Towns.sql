/* 02. Addresses with Towns */
USE [SoftUni]
GO

    SELECT TOP(50)
    		   e.FirstName, 
    		   e.LastName,
    		   t.Name,  
    		   a.AddressText
      FROM Employees AS e
INNER JOIN Addresses AS a 
        ON a.AddressID = e.AddressID
INNER JOIN Towns AS t 
        ON t.TownID = a.TownID
  ORDER BY e.FirstName, e.LastName;