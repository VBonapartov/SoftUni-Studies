/* 21. Increase Salaries */
USE [SoftUni]
GO

/* Create Backup */
BACKUP DATABASE SoftUni TO DISK = 'C:\SoftUniBackUp.bak'


UPDATE Employees
   SET Salary *= 1.12
 WHERE DepartmentID IN 
	   (
		SELECT DepartmentID 
		  FROM Departments 
         WHERE Name IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')	
	   )	
GO

SELECT Salary
  FROM Employees;
GO


/* Restore SoftUni Database */
USE Hotel
GO

-- drop the connection to that database
DECLARE @DatabaseName NVARCHAR(50) = N'SoftUni'

DECLARE @SQL VARCHAR(max)

SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(VARCHAR, SPId) + ';'
  FROM MASTER..SysProcesses
 WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId
 
EXEC(@SQL)

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK = 'C:\SoftUniBackUp.bak'