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

--04. Find all empoloyees except engineers
SELECT [FirstName], [LastName]
FROM Employees
WHERE [JobTitle] NOT LIKE '%engineer%'

--05. Find Towns with name Length

SELECT [Name] 
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]


--06. find towns starting with

SELECT [TownID], [Name]
FROM Towns
WHERE [Name] LIKE '[mkbe]%'
ORDER BY [Name]

--07. find towns not starting with

SELECT [TownID], [Name]
FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

--08. Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName]
FROM Employees
WHERE DATEPART(YEAR,HireDate) > 2000

--09. Length of last name

SELECT [FirstName], [LastName]
FROM Employees
WHERE LEN(LastName) = 5

--10. rank Employees by Salary

SELECT [EmployeeID], [FirstName], [LastName], [Salary],
DENSE_RANK() OVER 
(PARTITION BY Salary ORDER BY EmployeeID)
FROM Employees
WHERE Salary BETWEEN 10000 AND 20000
ORDER BY Salary DESC

--11. find all emplyees with rank 2

WITH CTE_RankedEmployees AS
(
	SELECT EmployeeID, [FirstName], [LastName], [Salary]
	DENSE_RANK() OVER 
    (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 20000
)
SELECT *
FROM CTE_RankedEmployees
WHERE [Rank] = 2
ORDER BY Salary DESC

