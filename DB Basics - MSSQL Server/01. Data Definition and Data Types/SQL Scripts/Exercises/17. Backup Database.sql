/* 17. Backup Database */
USE SoftUni
GO

BACKUP DATABASE SoftUni TO DISK = 'C:\SoftUniBackUp.bak'

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
