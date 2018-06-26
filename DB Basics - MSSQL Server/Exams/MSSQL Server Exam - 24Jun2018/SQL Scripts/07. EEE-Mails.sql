/* 07. EEE-Mails */
USE [TripService]
GO

    SELECT a.FirstName,
    		   a.LastName,
    		   FORMAT(a.BirthDate, 'MM-dd-yyyy'),
    		   c.Name,
    		   a.Email
      FROM Accounts AS a
INNER JOIN Cities AS c ON c.Id = a.CityId 
     WHERE SUBSTRING(Email, 1, 1) = 'e'
  ORDER BY c.Name DESC