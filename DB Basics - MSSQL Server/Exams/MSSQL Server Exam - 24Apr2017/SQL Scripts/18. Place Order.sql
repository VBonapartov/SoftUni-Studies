/* 18. Place Order */
USE [WMS]
GO

CREATE PROCEDURE usp_PlaceOrder(@JobId INT, @SerialNumber VARCHAR(50), @Quantity INT)
AS
BEGIN
	
	DECLARE @JobStatus VARCHAR(MAX) = (SELECT Status FROM Jobs WHERE JobId = @JobId)
	DECLARE @JobExists BIT = (SELECT COUNT(JobId) FROM Jobs WHERE JobId = @JobId)
	DECLARE @PartExists BIT = (SELECT COUNT(SerialNumber) FROM Parts WHERE SerialNumber = @SerialNumber)

  IF(@Quantity <= 0)
	BEGIN
		THROW 50012, 'Part quantity must be more than zero!' , 1
	END

  IF(@JobStatus = 'Finished')
	BEGIN
		THROW 50011, 'This job is not active!', 1
	END
  
	IF(@JobExists = 0)
	BEGIN
		THROW 50013, 'Job not found!', 1
	END

	IF(@PartExists = 0)
	BEGIN
		THROW 50014, 'Part not found!', 1
	END

	DECLARE @OrderForJobExists INT = 
	(
		SELECT COUNT(o.OrderId) 
		  FROM Orders AS o
		 WHERE o.JobId = @JobId AND o.IssueDate IS NULL
	)

	IF(@OrderForJobExists = 0)
	BEGIN
		INSERT INTO Orders 
		VALUES (@JobId, NULL, 0)
	END

	DECLARE @OrderId INT = 
	(
		SELECT o.OrderId 
		  FROM Orders AS o
		 WHERE o.JobId = @JobId AND o.IssueDate IS NULL
	)

	IF(@OrderId > 0 AND @PartExists = 1 AND @Quantity > 0)
	BEGIN
		DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)
		DECLARE @PartExistsInOrder INT = (SELECT COUNT(*) FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId)

		IF(@PartExistsInOrder > 0)
		BEGIN
			UPDATE OrderParts
			   SET Quantity += @Quantity
			 WHERE OrderId = @OrderId AND PartId = @PartId
		END
		ELSE
		BEGIN
			INSERT INTO OrderParts 
			VALUES (@OrderId, @PartId, @Quantity)
		END
	END
END

--Example
DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY
BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

