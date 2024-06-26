--02. Find All the inforamtion About Departments

USE SoftUni
SELECT * FROM [Departments]

--03. Find all Department Names

SELECT [Name] FROM [Departments]

--04. Find Salary of Each Employee

SELECT [FirstName],[LastName],[Salary] FROM [Employees]

--05. Find Full Name of Each Employee

SELECT [FirstName],[MiddleName],[LastName] FROM [Employees]

--06. Find Email Address of Each Employee

SELECT [FirstName] + '.' + [LastName] + '@softuni.bg'
AS [Full Email Address]
FROM [Employees]

--07. Find All Different Employees Salary

SELECT DISTINCT [Salary] FROM [Employees]

--08. Find All inforamtion About Employees

SELECT * 
FROM [Employees]
WHERE JobTitle = 'Sales Representative'

--09. Find ames of All Employees  by Salary in Range

SELECT [FirstName], [LastName], [JobTitle] 
FROM Employees
WHERE [Salary]>=20000 AND [Salary] <= 30000

--10. Find Names of All Employees

SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName]
AS [Full Name]
FROM Employees
WHERE [Salary] = 25000 OR [Salary] = 14000 OR [Salary] = 12500 OR [Salary] = 23600

--11. Find All Employees Without a Manager

SELECT [FirstName], [LastName]
FROM Employees
WHERE ManagerID IS NULL

--12. Find All Employees with a Salary More Than 50000

SELECT [FirstName], [LastName], [Salary]
FROM Employees
WHERE [Salary] > 50000
ORDER BY [Salary] DESC

--13. Find 5 Best Paid Employees

SELECT TOP(5) [FirstName], [LastName]
FROM [Employees]
ORDER BY [Salary] DESC

--14. Find All Employees Except Marketing

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [DepartmentId] != 4

--15. Sort Employees Table
SELECT * 
FROM [Employees]
ORDER BY [Salary] DESC,
[FirstName] ASC,
[LastName] DESC,
[MiddleName] ASC

--16. Create View Employees with Salary

CREATE VIEW V_EmployeesSalaries AS
(
	SELECT [FirstName], [LastName], [Salary]
	FROM Employees
)

--17. Create View Employees with Job Titles

CREATE VIEW V_EmployeeNameJobTitle AS
(
	SELECT 
	CONCAT_WS(' ', [FirstName], [MiddleName], [LastName]) AS 'Full Name'
	[Salary]
	FROM Employees
)

--18. Distinct Job Titles

SELECT DISTINCT [JobTitle]
FROM Employees

--19. Find First 10 Started Projects

SELECT TOP(10) *
FROM Projects
ORDER BY StartDate, [Name]


--20. Last 7 Hired Employees

SELECT TOP(7) [FirstName], [LastName] , [HireDate]
FROM Employees
ORDER BY [HireDate] DESC

