/* 13. Monasteries by Country */
USE [Geography]
GO

CREATE TABLE Monasteries
(
	Id			    INT IDENTITY(1, 1) NOT NULL,
	[Name]	    NVARCHAR(100) NOT NULL,
	CountryCode CHAR(2) NOT NULL

	CONSTRAINT PK_Monasteries PRIMARY KEY (Id),

	CONSTRAINT FK_Monasteries_Countries
	FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries(Name, CountryCode) 
VALUES
  ('Rila Monastery “St. Ivan of Rila”', 'BG'), 
  ('Bachkovo Monastery “Virgin Mary”', 'BG'),
  ('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
  ('Kopan Monastery', 'NP'),
  ('Thrangu Tashi Yangtse Monastery', 'NP'),
  ('Shechen Tennyi Dargyeling Monastery', 'NP'),
  ('Benchen Monastery', 'NP'),
  ('Southern Shaolin Monastery', 'CN'),
  ('Dabei Monastery', 'CN'),
  ('Wa Sau Toi', 'CN'),
  ('Lhunshigyia Monastery', 'CN'),
  ('Rakya Monastery', 'CN'),
  ('Monasteries of Meteora', 'GR'),
  ('The Holy Monastery of Stavronikita', 'GR'),
  ('Taung Kalat Monastery', 'MM'),
  ('Pa-Auk Forest Monastery', 'MM'),
  ('Taktsang Palphug Monastery', 'BT'),
  ('Sümela Monastery', 'TR');

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL DEFAULT 0

UPDATE Countries
   SET IsDeleted = 1
 WHERE CountryCode IN
 (
	    SELECT c.CountryCode
		    FROM Countries AS c
  INNER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	  GROUP BY c.CountryCode
	    HAVING COUNT(cr.RiverId) > 3
 )

	  SELECT m.Name AS [Monastery], 
		       c.CountryName AS [Country]
	    FROM Monasteries AS m
INNER JOIN Countries AS c ON c.CountryCode = m.CountryCode
	   WHERE c.IsDeleted = 0
  ORDER BY Monastery