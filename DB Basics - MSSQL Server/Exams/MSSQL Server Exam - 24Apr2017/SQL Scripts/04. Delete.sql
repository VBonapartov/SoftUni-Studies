/* 04. Delete */
USE [WMS]
GO

DELETE FROM OrderParts
	    WHERE OrderId = 19

DELETE FROM Orders
	    WHERE OrderId = 19


