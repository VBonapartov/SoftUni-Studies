/* 07. Mechanic Assignments */
USE [WMS]
GO

    SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
           j.Status,
		       j.IssueDate
      FROM Mechanics AS m
INNER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
  ORDER BY m.MechanicId ASC, j.IssueDate ASC, JobId ASC