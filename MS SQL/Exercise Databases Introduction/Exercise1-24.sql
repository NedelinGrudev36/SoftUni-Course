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



