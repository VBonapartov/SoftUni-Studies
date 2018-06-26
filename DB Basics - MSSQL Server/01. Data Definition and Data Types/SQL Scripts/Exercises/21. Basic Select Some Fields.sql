/* 21. Basic Select Some Fields */
USE SoftUni
GO

  SELECT Name 
    FROM Towns
ORDER BY Name ASC

  SELECT Name 
    FROM Departments
ORDER BY Name ASC

  SELECT FirstName, LastName, JobTitle, Salary 
    FROM Employees
ORDER BY Salary DESC