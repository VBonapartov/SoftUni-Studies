/* 05. Deposits Sum */
USE [Gringotts]
GO

  SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
GROUP BY DepositGroup;