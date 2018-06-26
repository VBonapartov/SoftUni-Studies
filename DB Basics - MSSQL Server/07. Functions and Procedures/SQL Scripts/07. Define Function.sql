/* 07. Define Function */
USE [SoftUni]
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1;
	DECLARE @lenght INT = LEN(@word);
	DECLARE @letter CHAR(1);

	WHILE(@counter <= @lenght)
	BEGIN
		SET @letter = SUBSTRING(@word, @counter, 1)     
		IF (CHARINDEX(@letter, @setOfLetters) > 0)
		  SET @counter += 1
		ELSE     
		  RETURN 0
	END

	RETURN 1
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia');

