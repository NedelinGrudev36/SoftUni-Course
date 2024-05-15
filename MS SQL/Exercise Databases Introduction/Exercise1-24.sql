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
	





