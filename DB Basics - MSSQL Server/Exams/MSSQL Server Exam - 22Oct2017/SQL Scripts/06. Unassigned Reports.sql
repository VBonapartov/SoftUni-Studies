/* 06. Unassigned Reports */
USE [ReportService]
GO

  SELECT Description, OpenDate
    FROM Reports
   WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, Description ASC 
