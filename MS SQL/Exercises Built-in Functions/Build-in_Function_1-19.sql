--01. Find names of all employees by first name

SELECT [FirstName], [LastName]
FROM Employees
WHERE [FirstName] LIKE 'Sa%'

--02. Find names of all employees by last name

SELECT [FirstName], [LastName]
FROM Employees
WHERE [LastName] LIKE '%ei%'

--03. Find First Names of all employees

SELECT [FirstName]
FROM Employees
WHERE DepartmentId IN (3,10) AND 
DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005




