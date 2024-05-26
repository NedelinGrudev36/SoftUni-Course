CREATE DATABASE Demo
USE Demo

--01. One-to-One Relationship
CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY(101,1),
	PassportNumber VARCHAR(30) NOT NULL
)

INSERT INTO Passports
VALUES('N34FG218'), ('K65LO4R7'), ('ZE657QP2')


CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(30) NOT NULL,
	Salary DECIMAL(10,2),
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)

)

INSERT INTO Persons
VALUES('Roberto','43300',102),
	('Tom','56100',103),
	('Yana','60200',101)

--02. One to many relationship

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(30) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn DATETIME2
)

INSERT INTO Models
VALUES('X1',1),
		('i6',1),
		('Model S',2),
		('Model X',2),
		('Model 3',3),
		('Nova',3)

INSERT INTO Manufacturers
VALUES('BMW','07/03/1916'),
		('Tesla','01/01/2003'),
		('Lada','01/05/1966')

--03. Many to Many relationship

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT PK_StudentsExam PRIMARY KEY(StudentID,ExamID)
)

INSERT INTO Students
VALUES('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams
VALUES('SpringMVC'),('Neo4j'),('Oracle 11g')

--04. Self-Referencing

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES('John', NULL),('Maya', 106),('Silvia', 106),('Ted', 105),('Mark', 101),('Greta', 101)

--05. Online Store Database
CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE ItemsTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemsTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID	INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Birthday DATETIME2,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

--06. University Database
CREATE DATABASE University
USE University

CREATE TABLE [Subjects]
(
    SubjectID INT PRIMARY KEY IDENTITY
   ,SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE [Majors]
(
    MajorID INT PRIMARY KEY IDENTITY
   ,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students]
(
    StudentID INT PRIMARY KEY IDENTITY
   ,StudentNumber INT NOT NULL
   ,StudentName VARCHAR(50) NOT NULL
   ,MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE [Payments]
(
    PaymentID INT PRIMARY KEY IDENTITY
   ,PaymentDate DATE NOT NULL
   ,PaymentAmount DECIMAL(6,2) NOT NULL
   ,StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE [Agenda]
(
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
   ,SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
    PRIMARY KEY (StudentID, SubjectID)
)

