/* 10. First Letter */
USE [Gringotts]
GO

  SELECT LEFT(FirstName, 1) AS [FirstLetter]
    FROM WizzardDeposits
   WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY [FirstLetter]	