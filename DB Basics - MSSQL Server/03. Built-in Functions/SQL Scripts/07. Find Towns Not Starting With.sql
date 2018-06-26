/* 07. Find Towns Not Starting With */
USE [SoftUni]
GO

  SELECT *
    FROM Towns
 --WHERE [Name] NOT LIKE '[R, B, D]%'
   WHERE LEFT(Name,1) NOT LIKE '[RBD]'
ORDER BY [Name];