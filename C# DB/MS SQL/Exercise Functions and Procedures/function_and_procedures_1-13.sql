--01. Employees with Salary SoftUni Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove3500
AS 
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove3500

--02. Employees with Salary Above Number
