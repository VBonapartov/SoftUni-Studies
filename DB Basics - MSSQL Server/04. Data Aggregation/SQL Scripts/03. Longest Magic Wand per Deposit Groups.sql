/* 03. Longest Magic Wand per Deposit Groups */
USE [Gringotts]
GO

  SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand]
    FROM WizzardDeposits
GROUP BY DepositGroup;