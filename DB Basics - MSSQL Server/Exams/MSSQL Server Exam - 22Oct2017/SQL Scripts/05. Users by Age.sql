/* 05. Users by Age */
USE [ReportService]
GO

  SELECT Username, Age
    FROM Users
ORDER BY Age ASC, Username DESC 
