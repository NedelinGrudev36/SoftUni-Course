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


