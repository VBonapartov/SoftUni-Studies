/* 18. Send Feedback */
USE [Bakery]
GO

CREATE PROCEDURE usp_SendFeedback(@customerId INT, @productId INT, @rate decimal(4, 2), @description NVARCHAR(255))
AS
	BEGIN
		BEGIN TRANSACTION
		INSERT INTO Feedbacks (Description, Rate, ProductId, CustomerId)
		VALUES (@description, @rate, @productId, @customerId)    
		
		DECLARE @customerFeedbacks INT = (SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = @customerId);

		IF (@customerFeedbacks > 3) 
		BEGIN
			ROLLBACK TRANSACTION;
			RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1);
			RETURN;
		END
		ELSE
			COMMIT TRANSACTION;
    END

-- Example
EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';
SELECT COUNT(*) 
  FROM Feedbacks 
 WHERE CustomerId = 1 AND ProductId = 5;

