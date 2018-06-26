/* 23. Decrease Tax Rate */
USE Hotel
GO

UPDATE Payments
   SET TaxRate -= TaxRate * 0.03

UPDATE Payments
   SET TaxAmount = AmountCharged * TaxRate

UPDATE Payments
   SET PaymentTotal = AmountCharged + TaxAmount

SELECT TaxRate 
  FROM Payments