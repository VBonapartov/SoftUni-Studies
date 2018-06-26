/* 05. Find Towns with Name Length */
USE [SoftUni]
GO

  SELECT Name
    FROM Towns
   WHERE LEN(Name) IN (5, 6)
ORDER BY Name;