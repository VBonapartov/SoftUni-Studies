/* 16. Show All Games with Duration and Part of the Day */
USE [Orders]
GO

SELECT ProductName, 
       OrderDate, 
	     DATEADD(DAY, 3, OrderDate) AS [Pay Due], 
	     DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
  FROM Orders;