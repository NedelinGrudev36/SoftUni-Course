CREATE DATABASE LibraryDb 
USE LibraryDb 
GO

CREATE TABLE Contacts (
    Id INT IDENTITY PRIMARY KEY,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    PostAddress NVARCHAR(200),
    Website NVARCHAR(50)
);

CREATE TABLE Authors (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ContactId INT NOT NULL,
    ContactId INT FOREIGN KEY REFERENCES Contacts(Id)
);

CREATE TABLE Genres (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL
);

CREATE TABLE Books (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    YearPublished INT NOT NULL,
    ISBN NVARCHAR(13) NOT NULL UNIQUE,
    AuthorId INT NOT NULL,
    GenreId INT NOT NULL,
    AuthorId INT FOREIGN KEY REFERENCES Authors(Id),
    GenreId INT FOREIGN KEY REFERENCES Genres(Id)
);

CREATE TABLE Libraries 
(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    ContactId INT NOT NULL,
    ContactId INT FOREIGN KEY REFERENCES Contacts(Id)
);

CREATE TABLE LibrariesBooks (
    LibraryId INT NOT NULL,
    BookId INT NOT NULL,
    PRIMARY KEY (LibraryId, BookId),
    FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
    FOREIGN KEY (BookId) REFERENCES Books(Id)
);

--02. INSERT 

INSERT INTO Contacts (Email, PhoneNumber, PostAddress, Website) VALUES
(NULL, NULL, NULL, NULL),
(NULL, NULL, NULL, NULL),
('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com');

INSERT INTO Authors (Name, ContactId) VALUES
('George Orwell', 1),
('Aldous Huxley', 2),
('Stephen King', 3),
('Suzanne Collins', 4);

INSERT INTO Books (Title, YearPublished, ISBN, AuthorId, GenreId) VALUES
('1984', 1949, '9780451524935', 1, 2),
('Animal Farm', 1945, '9780451526342', 1, 2),
('Brave New World', 1932, '9780060850524', 2, 2),
('The Doors of Perception', 1954, '9780060850531', 2, 2),
('The Shining', 1977, '9780307743657', 3, 9),
('It', 1986, '9781501142970', 3, 9),
('The Hunger Games', 2008, '9780439023481', 4, 7),
('Catching Fire', 2009, '9780439023498', 4, 7),
('Mockingjay', 2010, '9780439023511', 4, 7);

INSERT INTO LibrariesBooks (LibraryId, BookId) VALUES
(1, 36),
(1, 37),
(2, 38),
(2, 39),
(3, 40),
(3, 41),
(4, 42),
(4, 43),
(5, 44);

--03. Update

UPDATE Contacts
SET Website = 'www.' + LOWER(REPLACE(a.Name, ' ', '')) + '.com'
FROM Contacts c
JOIN Authors a ON c.Id = a.ContactId
WHERE c.Website IS NULL;

--04.Delete
DECLARE @AuthorId INT;
SELECT @AuthorId = Id FROM Authors WHERE Name = 'Alex Michaelides';

DELETE FROM LibrariesBooks 
WHERE BookId IN (SELECT Id FROM Books WHERE AuthorId = @AuthorId);

DELETE FROM Books 
WHERE AuthorId = @AuthorId;

DELETE FROM Authors 
WHERE Id = @AuthorId;

--05.Books by Year of Publication

SELECT 
    Title AS [Book Title], 
    ISBN, 
    YearPublished AS [YearReleased]
FROM 
    Books
ORDER BY 
    YearPublished DESC, 
    Title ASC;

--06.Books by Genre

SELECT 
    b.Id, 
    b.Title, 
    b.ISBN, 
    g.Name AS Genre
FROM 
    Books b
JOIN 
    Genres g ON b.GenreId = g.Id
WHERE 
    g.Name IN ('Biography', 'Historical Fiction')
ORDER BY 
    g.Name ASC, 
    b.Title ASC;

--07. Libraries Missing Specific Genre

SELECT 
    l.Name AS Library,
    c.Email
FROM 
    Libraries l
JOIN 
    Contacts c ON l.ContactId = c.Id
LEFT JOIN (
    SELECT DISTINCT
        lb.LibraryId
    FROM
        LibrariesBooks lb
    JOIN
        Books b ON lb.BookId = b.Id
    JOIN
        Genres g ON b.GenreId = g.Id
    WHERE
        g.Name = 'Mystery'
) AS MysteryLibraries ON l.Id = MysteryLibraries.LibraryId
WHERE
    MysteryLibraries.LibraryId IS NULL
ORDER BY
    l.Name ASC;


--08.First 3 Books

SELECT TOP 3
    Title,
    YearPublished AS Year,
    g.Name AS Genre
FROM
    Books b
JOIN
    Genres g ON b.GenreId = g.Id
WHERE
    (YearPublished > 2000 AND Title LIKE '%a%')
    OR
    (YearPublished < 1950 AND g.Name LIKE '%Fantasy%')
ORDER BY
    Title ASC,
    YearPublished DESC;

--09. Authors from the UK

SELECT
    a.Name AS Author,
    c.Email,
    c.PostAddress AS Address
FROM
    Authors a
JOIN
    Contacts c ON a.ContactId = c.Id
WHERE
    c.PostAddress LIKE '%UK%'
ORDER BY
    Author ASC;


--10. Memoirs in NY

SELECT
    a.Name AS Author,
    b.Title,
    l.Name AS Library,
    c.PostAddress AS [Library Address]
FROM
    Books b
JOIN
    Authors a ON b.AuthorId = a.Id
JOIN
    Genres g ON b.GenreId = g.Id
JOIN
    LibrariesBooks lb ON b.Id = lb.BookId
JOIN
    Libraries l ON lb.LibraryId = l.Id
JOIN
    Contacts c ON l.ContactId = c.Id
WHERE
    g.Name = 'Fictions'
    AND
    c.PostAddress LIKE '%Denver%'
ORDER BY
    b.Title ASC;

--11.Authors with Books

CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @bookCount INT;

    SELECT @bookCount = COUNT(*)
    FROM Authors a
    JOIN Books b ON a.Id = b.AuthorId
    JOIN LibrariesBooks lb ON b.Id = lb.BookId
    WHERE a.Name = @name;

    RETURN @bookCount;
END;


--12. Search for Books from a Specific Genre

CREATE PROCEDURE usp_SearchByGenre
    @genreName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        b.Title,
        b.YearPublished AS Year,
        b.ISBN,
        a.Name AS Author,
        g.Name AS Genre
    FROM
        Books b
    JOIN
        Authors a ON b.AuthorId = a.Id
    JOIN
        Genres g ON b.GenreId = g.Id
    WHERE
        g.Name = @genreName
    ORDER BY
        b.Title ASC;
END;






