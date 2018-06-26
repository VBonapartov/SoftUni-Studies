/* 06. Find Towns Starting With */
USE [SoftUni]
GO

  SELECT *
    FROM Towns
   WHERE [Name] LIKE '[M, K, B, E]%'
 --WHERE LEFT(Name,1) LIKE '[MKBE]'
ORDER BY [Name];

   