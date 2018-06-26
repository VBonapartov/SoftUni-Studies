/* 17. Cost of Order */
USE [WMS]
GO

CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15, 2)
AS
BEGIN
	DECLARE @totalOrderCost DECIMAL(15, 2) = 0;

	SET @totalOrderCost =
	(
			  SELECT ISNULL(SUM(p.Price * op.Quantity), 0) AS PartsPrice
			    FROM Orders AS o
		INNER JOIN OrderParts AS op ON op.OrderId = o.OrderId
		INNER JOIN Parts AS p ON p.PartId = op.PartId
			   WHERE o.JobId = @jobId
	)

	RETURN @totalOrderCost;
END

--Example
SELECT dbo.udf_GetCost(1)
