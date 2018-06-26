/* 19. Detect Delivery */
USE [WMS]
GO

CREATE TRIGGER tr_DetectDelivery
ON Orders
AFTER UPDATE
AS
BEGIN
		  UPDATE Parts
		     SET StockQty += op.Quantity
		    FROM deleted AS d
	INNER JOIN inserted AS i ON d.OrderId = i.OrderId
	INNER JOIN OrderParts AS op ON i.OrderId = op.OrderId
		   WHERE d.Delivered = 0 AND i.Delivered = 1 AND Parts.PartId = op.PartId
END
      
--Example 
UPDATE Orders
   SET Delivered = 1
 WHERE OrderId = 21


