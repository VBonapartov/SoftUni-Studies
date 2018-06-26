/* 03. Update */
USE [RentACar]
GO

UPDATE Models
   SET Class = 'Luxury'
 WHERE Consumption > 20

