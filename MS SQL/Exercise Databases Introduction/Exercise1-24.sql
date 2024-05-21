--Exercises: Database Introduction
--01. Create Database

CREATE DATABASE Minions

--02. Create Tables
USE Minions
CREATE TABLE Minions(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50)
)

--03. Alter Minions Table
ALTER TABLE Minions
ADD TownId INT

--04.Insert Records in Both Tables
INSERT INTO Towns
VALUES(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions(Id,[Name],Age,TownId)
VALUES(1,'Kevin',22,1),
	(2,'Bob',15,3),
	(3,'Steward',NULL,2)

--05. Truncate table
TRUNCATE TABLE Minions
SELECT * FROM Minions

--06. Drop table
DROP TABLE Minions
DROP TABLE Towns

--07. Create Table People
CREATE TABLE People
(
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(200) NOT NULL,
  Picture VARBINARY(MAX),
  Height DECIMAL(3,2),
  [Weight] DECIMAL(5,2),
  Gender CHAR(1) NOT NULL, 
	CHECK(Gender in('m', 'f')),
  Birthdate DATETIME2 NOT NULL,
  Biography VARCHAR(MAX)
)

INSERT INTO People([Name],Gender,Birthdate)
VALUES('Pesho','m','1998-05-05'),
('Gosho','m','1994-06-09'),
('Radka','f','1987-12-12'),
('Ivan','m','1999-05-04'),
('Kevin','m','1960-11-28')

--08. Cretae table Users
USE Minions
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users(Username,[Password])
VALUES('peshjo123','122334'),
('ganio111','123434'),
('petka132','1325432'),
('kevin3444','243433'),
('baba231345','1234533')

--09. Change Primary Key
--09.1 Delete Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07A1CD8BA4

--09.2 Add new Primary Key

ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY(Id, Username)

--10.Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordIsAtleastFiveSymbols
CHECK(LEN(Password) >= 5)

--13. Movies Database
CREATE DATABASE Movies

USE Movies
--DROP TABLE Directors
CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorsName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors(DirectorsName,Notes)
VALUES('Projects','diajwijddaiwhjdua'),
('Exercise1','dawuhdwadau'),
('Exercise1','awdawda'),
('Exercise1','dawdjaiwjd'),
('Projects','jiajwdaawda')
--DROP TABLE Genres
CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Genres(GenreName,Notes)
VALUES('Pop','Pop is good Genre'),
('Pop','Pop is good Genre'),
('Rock','Rock is not good Genre'),
('Pop','Pop is good Genre'),
('Rock','Rock is not good Genre')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Categories(CategoryName,Notes)
VALUES('Book','funny reading book'),
('Pen','funny writing book'),
('Book','funny reading book'),
('Pen','funny writing book'),
('Book','funny reading book')

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(30) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear VARCHAR(30),
	[Length] INT,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes VARCHAR(MAX)
)



INSERT INTO Movies(Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes)
VALUES('titanik',2,'1995-05-05',200,1,3,5,'adwawdaijwdiajwdj'),
('titanik1',1,'1996-04-05',200,1,3,5,'adwawdaijwdiajwdj'),
('titanik2',2,'1934-05-04',200,1,3,5,'adwawdaijwdiajwdj'),
('titanik3',1,'1995-06-05',200,1,3,5,'adwawdaijwdiajwdj'),
('titanik4',2,'1933-05-12',200,1,3,5,'adwawdaijwdiajwdj')
SELECT * FROM Movies
	
--14. Car Rental Database
--14.1 create database
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(6, 2) NOT NULL,
	[WeeklyRate] DECIMAL(6, 2) NOT NULL,
	[MonthlyRate] DECIMAL(6, 2) NOT NULL,
	[WeekendRate] DECIMAL(6, 2) NOT NULL
)

CREATE TABLE [Cars]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(30) NOT NULL,
	[Manufacturer] VARCHAR(50) NOT NULL,
	[Model] VARCHAR(50) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] IMAGE,
	[Condition] NVARCHAR(1000) NOT NULL,
	[Available] BIT NOT NULL
)

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Customers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(200) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [RentalOrders]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL,
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] DECIMAL(6, 2) NOT NULL,
	[TaxRate] DECIMAL(4, 2) NOT NULL,
	[OrderStatus] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

INSERT INTO [Categories] VALUES
	('First category name', 10.00, 50.00, 150.00, 20.00),
	('Second category name', 50.00, 250.00, 750.00, 100.00),
	('Third category name', 100.00, 500.00, 1500.00, 200.00)

INSERT INTO [Cars] VALUES
	('PLN 0001', 'Ford', 'Model A', 1994, 1, 4, NULL, 'Good', 1),
	('PLN 0002', 'Tesla', 'Model B', 2021, 2, 4, NULL, 'Great', 1),
	('PLN 0003', 'Capsule Corp', 'Model C', 2054, 3, 10, NULL, 'Best', 0)

INSERT INTO [Employees] VALUES
	('Tyler', 'Durden', 'Edward Norton`s Alter Ego', NULL),
	('Plain', 'Jane', 'some gal', NULL),
	('Average', 'Joe', 'some dude', NULL)

INSERT INTO [Customers] VALUES
	('123456', 'Jimmy Carr', 'Britain', 'London', 1000, NULL),
	('654321', 'Bill Burr', 'USA', 'Washington', 2000, NULL),
	('999999', 'Louis CK', 'Mexico', 'Mexico City', 3000, NULL)

INSERT INTO [RentalOrders] VALUES
	(1, 1, 1, 70, 90000, 100000, 10000, '1994-10-01', '1994-10-21', 20, 100.00, 14.00, 'Pending', NULL),
	(2, 2, 2, 85, 250000, 2750000, 25000, '2011-11-12', '2011-11-24', 12, 150.00, 17.50, 'Canceled', NULL),
	(3, 3, 3, 90, 0, 120000, 120000, '2025-04-05', '2025-05-02', 27, 220.00, 21.25, 'Delivered', NULL)

	--15. Hotel Database
	CREATE DATABASE Hotel
	USE Hotel

	CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Customers]
(
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[PhoneNumber] INT NOT NULL,
	[EmergencyName] VARCHAR(50),
	[EmergencyNumber] INT,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [RoomStatus]
(
	[RoomStatus] VARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [RoomTypes]
(
	[RoomType] VARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [BedTypes]
(
	[BedType] VARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(1000)
)


CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY IDENTITY,
	[RoomType] VARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes](RoomType) NOT NULL,
	[BedType] VARCHAR(50) FOREIGN KEY REFERENCES [BedTypes](BedType) NOT NULL,
	[Rate] DECIMAL(5,2) NOT NULL,
	[RoomStatus] VARCHAR(50) FOREIGN KEY REFERENCES [RoomStatus](RoomStatus) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Payments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[PaymentDate] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
	[FirstDateOccupied] DATE NOT NULL,
	[LastDateOccupied] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmountCharged] DECIMAL(6, 2) NOT NULL,
	[TaxRate] DECIMAL(4, 2) NOT NULL,
	[TaxAmount] DECIMAL(6, 2) NOT NULL,
	[PaymentTotal] DECIMAL(6, 2) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Occupancies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[DateOccupied] DATE NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms](RoomNumber) NOT NULL,
	[RateApplied] DECIMAL(4, 2) NOT NULL,
	[PhoneCharge] DECIMAL(4, 2) NOT NULL,
	[Notes] NVARCHAR(1000)
)


INSERT INTO [Employees] VALUES
	('Jim', 'McJim', 'Supervisor', NULL),
	('Jane', 'McJane', 'Cook', NULL),
	('John', 'McJohn', 'Waiter', NULL)
		
INSERT INTO [Customers] VALUES
	('Mickey', 'Mouse', 12345678, 'Minnie', 11111111, NULL),
	('Donald', 'Duck', 87654321, 'Daisy', 22222222, NULL),
	('Scrooge', 'McDuck', 9999999, 'Richie', 33333333, NULL)
		
INSERT INTO [RoomStatus] VALUES
	('Free', NULL),
	('Occupied', NULL),
	('No idea', NULL)
		
INSERT INTO [RoomTypes] VALUES
	('Room', NULL),
	('Studio', NULL),
	('Apartment', NULL)
		
INSERT INTO [BedTypes] VALUES
	('Big', NULL),
	('Small', NULL),
	('Child', NULL)
		
INSERT INTO [Rooms] VALUES
	('Room', 'Big', 15.00, 'Free', NULL),
	('Studio', 'Small', 12.50, 'Occupied', NULL),
	('Apartment', 'Child', 10.25, 'No idea', NULL)
		
INSERT INTO [Payments] VALUES
	(1, '2023-02-01', 1, '2023-01-11', '2023-01-14', 3, 250.00, 20.00, 50.00, 300.00, NULL),
	(2, '2023-02-02', 2, '2023-01-12', '2023-01-15', 3, 199.90, 20.00, 39.98, 239.88, NULL),
	(3, '2023-02-03', 3, '2023-01-13', '2023-01-16', 3, 330.50, 20.00, 66.10, 396.60, NULL)
	   	
INSERT INTO [Occupancies] VALUES
	(1, '2023-01-01', 1, 1, 20.00, 15.00, NULL),
	(2, '2023-01-02', 2, 2, 20.00, 12.50, NULL),
	(3, '2023-01-03', 3, 3, 20.00, 18.90, NULL)

--16. Create SoftUni Database
CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY,
    AddressText VARCHAR(255) NOT NULL,
    TownId INT FOREIGN KEY (TownId) REFERENCES Towns(Id),
)

CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50),
    LastName VARCHAR(50) NOT NULL,
    JobTitle VARCHAR(100) NOT NULL,
    DepartmentId INT FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    HireDate DATE NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    AddressId INT FOREIGN KEY (AddressId) REFERENCES Addresses(Id),
)

--18 basic insert 

INSERT INTO Towns (Name) VALUES ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas');

INSERT INTO Departments (Name) VALUES ('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance');

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
    ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
    ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
    ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
    ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);

	--19. Basic Select All Fields

SELECT * FROM Towns;

SELECT * FROM Departments;

SELECT * FROM Employees;

--20. Basic Select All Fields and Order Them

SELECT * FROM Towns ORDER BY [Name] ASC;

SELECT * FROM Departments ORDER BY [Name] ASC;

SELECT * FROM Employees ORDER BY Salary DESC;

--21. Basic Select Some Fields

SELECT [Name] FROM Towns ORDER BY [Name] ASC;

SELECT [Name] FROM Departments ORDER BY [Name] ASC;

SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC;

--22. Increase Employees Salary

USE SoftUni;

UPDATE Employees
SET Salary = Salary * 1.1;
SELECT Salary FROM Employees;

--23. Decrease Tax Rate

USE Hotel;

UPDATE Payments
SET TaxRate = TaxRate * 0.97;
SELECT TaxRate FROM Payments;

--24. Delete All Records

TRUNCATE TABLE Occupancies;




