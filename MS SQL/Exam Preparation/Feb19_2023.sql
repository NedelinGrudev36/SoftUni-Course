--00.Exam Preparation
--01.Create Tables

CREATE DATABASE Boardgames 
USE Boardgames 

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

CREATE TABLE Addresses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StreetName NVARCHAR(100) NOT NULL,
    StreetNumber INT NOT NULL,
    Town VARCHAR(30) NOT NULL,
    Country VARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
);

CREATE TABLE Publishers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(30) UNIQUE NOT NULL,
    AddressId INT NOT NULL,
    Website NVARCHAR(40),
    Phone NVARCHAR(20),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE PlayersRanges (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
);

CREATE TABLE Boardgames (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(10,2) NOT NULL,
    CategoryId INT NOT NULL,
    PublisherId INT NOT NULL,
    PlayersRangeId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (PublisherId) REFERENCES Publishers(Id),
    FOREIGN KEY (PlayersRangeId) REFERENCES PlayersRanges(Id)
);

CREATE TABLE Creators (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
);

CREATE TABLE CreatorsBoardgames (
    CreatorId INT NOT NULL,
    BoardgameId INT NOT NULL,
    PRIMARY KEY (CreatorId, BoardgameId),
    FOREIGN KEY (CreatorId) REFERENCES Creators(Id),
    FOREIGN KEY (BoardgameId) REFERENCES Boardgames(Id)
);

--02.Insert

INSERT INTO Publishers (Name, AddressId, Website, Phone)
VALUES 
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907');

INSERT INTO Boardgames (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES 
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2);

--03.Update

UPDATE PlayersRanges
SET PlayersMax = PlayersMax + 1
WHERE PlayersMin = 2 AND PlayersMax = 2;

UPDATE Boardgames
SET Name = Name + ' V2'
WHERE YearPublished >= 2021;

--04. Delete

SELECT Id 
INTO #TempAddressesToDelete
FROM Addresses
WHERE Town LIKE 'L%';

--05. Boardgames by Year of Publication

SELECT Name, Rating
FROM Boardgames
ORDER BY YearPublished ASC, Name DESC;

--06. Boardgames by Category

SELECT 
    b.Id,
    b.Name,
    b.YearPublished,
    c.Name AS CategoryName
FROM 
    Boardgames b
JOIN 
    Categories c ON b.CategoryId = c.Id
WHERE 
    c.Name IN ('Strategy Games', 'Wargames')
ORDER BY 
    b.YearPublished DESC;

--07.Creators without Boardgames

SELECT 
    c.Id,
    CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName,
    c.Email
FROM 
    Creators c
LEFT JOIN 
    CreatorsBoardgames cb ON c.Id = cb.CreatorId
WHERE 
    cb.CreatorId IS NULL
ORDER BY 
    CreatorName ASC;

--08. First 5 Boardgames

SELECT 
    b.Name,
    b.Rating,
    c.Name AS CategoryName
FROM 
    Boardgames b
JOIN 
    Categories c ON b.CategoryId = c.Id
JOIN 
    PlayersRanges pr ON b.PlayersRangeId = pr.Id
WHERE 
    (b.Rating > 7.00 AND b.Name LIKE '%a%')
    OR 
    (b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5)
ORDER BY 
    b.Name ASC, 
    b.Rating DESC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;
--09. Creators with Emails

WITH CreatorBoardgameRatings AS (
    SELECT
        c.Id AS CreatorId,
        CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
        c.Email,
        b.Rating,
        ROW_NUMBER() OVER (PARTITION BY c.Id ORDER BY b.Rating DESC) AS rn
    FROM
        Creators c
    JOIN
        CreatorsBoardgames cb ON c.Id = cb.CreatorId
    JOIN
        Boardgames b ON cb.BoardgameId = b.Id
    WHERE
        c.Email LIKE '%.com'
)
SELECT
    FullName,
    Email,
    Rating
FROM
    CreatorBoardgameRatings
WHERE
    rn = 1
ORDER BY
    FullName ASC;


--10. Creators by Rating

SELECT
    c.LastName,
    CEILING(AVG(b.Rating)) AS AverageRating,
    p.Name AS PublisherName
FROM
    Creators c
JOIN
    CreatorsBoardgames cb ON c.Id = cb.CreatorId
JOIN
    Boardgames b ON cb.BoardgameId = b.Id
JOIN
    Publishers p ON b.PublisherId = p.Id
WHERE
    p.Name = 'Stonemaier Games'
GROUP BY
    c.LastName,
    p.Name
ORDER BY
    AverageRating DESC;

--11. Creator with Boardgames

CREATE FUNCTION udf_CreatorWithBoardgames (@name NVARCHAR(50))
RETURNS INT
AS
BEGIN
    DECLARE @CreatorId INT;

    SELECT @CreatorId = Id
    FROM Creators
    WHERE FirstName = @name;

    RETURN (
        SELECT COUNT(*)
        FROM CreatorsBoardgames
        WHERE CreatorId = @CreatorId
    );
END;

--12. Search for Boardgame with Specific Category

CREATE PROCEDURE usp_SearchByCategory
    @category NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        b.Name,
        b.YearPublished,
        b.Rating,
        c.Name AS CategoryName,
        p.Name AS PublisherName,
        CONCAT(pr.PlayersMin, ' people') AS MinPlayers,
        CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
    FROM
        Boardgames b
    JOIN
        Categories c ON b.CategoryId = c.Id
    JOIN
        Publishers p ON b.PublisherId = p.Id
    JOIN
        PlayersRanges pr ON b.PlayersRangeId = pr.Id
    WHERE
        c.Name = @category
    ORDER BY
        p.Name ASC,
        b.YearPublished DESC;

END;






