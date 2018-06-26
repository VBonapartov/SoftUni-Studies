/* 19. Find First 10 Started Projects */
USE [SoftUni]
GO

  SELECT TOP(10) *
    FROM Projects
ORDER BY StartDate, [Name];