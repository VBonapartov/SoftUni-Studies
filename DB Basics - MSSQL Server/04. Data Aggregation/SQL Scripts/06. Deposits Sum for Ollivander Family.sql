/* 06. Deposits Sum for Ollivander Family */
USE [Gringotts]
GO

  SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup;