/* 12. *Rich Wizard, Poor Wizard */
USE [Gringotts]
GO

SELECT SUM(WizardDep.Difference)
  FROM (
  		 SELECT FirstName,
    			    DepositAmount,
    			    LEAD(FirstName) OVER(ORDER BY Id) AS GuestWizard,
    			    LAG(FirstName) OVER(ORDER BY Id) AS GuestLagWizard,
    			    LEAD(DepositAmount) OVER(ORDER BY Id) AS GuestDeposit,
    			    LAG(DepositAmount) OVER(ORDER BY Id) AS GuestLagDeposit,
    			    DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
  		   FROM WizzardDeposits
  	   ) AS WizardDep;
 