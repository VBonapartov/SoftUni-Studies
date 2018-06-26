/* 05. Products by Price */
USE [Bakery]
GO

   SELECT [Name], Price, Description
     FROM Products
 ORDER BY Price DESC, [Name] ASC