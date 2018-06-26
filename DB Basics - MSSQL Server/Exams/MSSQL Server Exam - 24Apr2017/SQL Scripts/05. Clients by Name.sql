/* 05. Clients by Name */
USE [WMS]
GO

  SELECT FirstName, LastName, Phone
    FROM Clients
ORDER BY LastName ASC, ClientId ASC