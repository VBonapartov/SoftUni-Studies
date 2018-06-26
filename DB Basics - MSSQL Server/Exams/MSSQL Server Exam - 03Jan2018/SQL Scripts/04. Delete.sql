/* 04. Delete */
USE [RentACar]
GO

DELETE FROM Orders
      WHERE ReturnDate IS NULL

