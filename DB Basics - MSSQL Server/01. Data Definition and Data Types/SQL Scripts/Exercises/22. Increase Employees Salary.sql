/* 22. Increase Employees Salary */
USE SoftUni
GO

UPDATE Employees
   SET Salary *= 1.10

SELECT Salary 
  FROM Employees