/* 11. Future Value Function */
USE [Bank]
GO

CREATE FUNCTION ufn_CalculateFutureValue 
(	
	@sum DECIMAL(15, 4), 
	@yearlyInterestRate FLOAT, 
	@numberOfYears INT 
)
RETURNS DECIMAL(15, 4)
AS
BEGIN
     DECLARE @FutureValue DECIMAL(15, 4);
	   SET @FutureValue = @sum * POWER(1 + @yearlyInterestRate, @numberOfYears);
	   RETURN @FutureValue;
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5);