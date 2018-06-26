/* 19. Delete Products */
USE [Bakery]
GO

CREATE TRIGGER tr_DeleteTrigger
ON dbo.Products
INSTEAD OF DELETE
AS
	DECLARE @productId INT = (SELECT deleted.id FROM deleted);

	DELETE FROM ProductsIngredients
		    WHERE ProductId = @productId

	DELETE FROM Feedbacks
		    WHERE ProductId = @productId
		  
	DELETE FROM Products
		    WHERE Id = @productId	

-- Example
DELETE FROM Products 
      WHERE Id = 7

