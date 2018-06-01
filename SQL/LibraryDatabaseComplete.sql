/*T-SQL Example Database and Queries

This is an example of creating a SQL database of seven joined tables for library resource
 tracking including book information, library branches, library patrons and their checkout 
 records. Tables are populated with hard coded data as well as algorithmically using loops 
 and iterating variables. Queries are stored in procedures and executed at the end of the whole query.*/


CREATE DATABASE Library2
GO

USE Library2
Go

CREATE TABLE  PUBLISHER(
	Name VARCHAR(100) PRIMARY KEY NOT NULL,
	Address VARCHAR(100),
	Phone VARCHAR(20)
);

CREATE TABLE BORROWER (
	CardNo INT PRIMARY KEY NOT NULL IDENTITY(10000,1),
	Name VARCHAR(50) NOT NULL,
	Address VARCHAR(100) NOT NULL,
	Phone VARCHAR(20) NOT NULL
);

CREATE TABLE LIBRARY_BRANCH(
	BranchId INT PRIMARY KEY NOT NULL IDENTITY(101,10),
	BranchName VARCHAR(50) NOT NULL,
	Address VARCHAR(100) NOT NULL
);

CREATE TABLE  BOOK(
	BookId	INT PRIMARY KEY Identity(1,1) NOT NULL,	
	Title	VARCHAR(100) NOT NULL,
	PublisherName	VARCHAR(100) NOT NULL CONSTRAINT bk_publisher_name FOREIGN KEY REFERENCES PUBLISHER(Name) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE  BOOK_AUTHORS(
	BookId	INT PRIMARY KEY NOT NULL CONSTRAINT au_book_id FOREIGN KEY REFERENCES BOOK(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	AuthorName VARCHAR(100) NOT NULL
);



CREATE TABLE  BOOK_LOANS(
	RecordId INT NOT NULL PRIMARY KEY Identity(1,1),
	BookId	INT  NOT NULL CONSTRAINT ln_book_id FOREIGN KEY REFERENCES BOOK(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	BranchId INT NOT NULL CONSTRAINT ln_library_br FOREIGN KEY REFERENCES Library_Branch(BranchId) ON UPDATE CASCADE ON DELETE CASCADE,
	CardNo INT NOT NULL CONSTRAINT ln_card_nm FOREIGN KEY REFERENCES Borrower(CardNo) ON UPDATE CASCADE ON DELETE CASCADE,
	DateOut Date NOT NULL,
	DueDate AS DATEADD(DAY,21,DateOut) Persisted
);

CREATE TABLE  BOOK_COPIES(
	RecordID INT PRIMARY KEY NOT NULL Identity(1,1),
	BookId	INT NOT NULL CONSTRAINT cp_book_id FOREIGN KEY REFERENCES BOOK(BookId) ON UPDATE CASCADE ON DELETE CASCADE,
	BranchID INT NOT NULL CONSTRAINT cp_library_br FOREIGN KEY REFERENCES Library_Branch(BranchId) ON UPDATE CASCADE ON DELETE CASCADE,
	NO_OF_COPIES INT NOT NULL
);





INSERT INTO PUBLISHER(Name, Address, Phone)
	VALUES
	('Picador USA','175 Fifth Avenue, New York, NY 10010, USA','646-307-5629'),
	('Chilton Books', '12 Wolfpen Ln, Southborough, MA 01772, USA', '508-249-4284'),
	('Simon & Schuster', '1230 6th Ave, New York, NY 10020, USA', '212-698-7000'),
	('Stackpole Books','5067 Ritter Rd, Mechanicsburg, PA 17055, USA','978-750-8400'),
	('Bloomsbury Publishing','1385 Broadway, 5th Floor, New York, NY 10018','212-419-5300'),
	('Henry Holt & Company, Inc','175 5th Ave, New York, NY 10010, USA','646-307-5095'),
	('Penguin Books', '345 Hudson St New York, NY 10014, USA','101-101-1001'),
	('Chapman & Hall', 'No Longer In Existence', 'NA'),
	('Allen & Unwin','83 Alexander St,Crows Nest, NSW 2065, AUS','(61 2) 8425 0100'),
	('Macmillan', '75 Varick St, New York, NY 10013, USA', '212-226-7521'),
	('Geoffrey Bles', 'No Longer In Existence', 'NA'),
	('Scribner', '1230 6th Ave, New York, NY 10020, USA', '212-698-7000')
	;


INSERT INTO BOOK(Title,PublisherName)
	VALUES
	
	
	('The Lost Tribe','Picador USA'),
	('Dune', 'Chilton Books'),
	('Dune Messiah', 'Chilton Books'),
	('Children of Dune', 'Chilton Books'),
	('IT', 'Simon & Schuster'),
	('Nightmares and Dreamscapes', 'Simon & Schuster'),
	('Christine', 'Simon & Schuster'),
	('Bird Feathers', 'Stackpole Books'),
	('Harry Potter and The Philosopher''s Stone', 'Bloomsbury Publishing'),
	('Harry Potter and The Chamber of Secrets', 'Bloomsbury Publishing'),
	('Harry Potter and The Prisoner of Azkaban', 'Bloomsbury Publishing'),
	('Harry Potter and The Goblet of Fire', 'Bloomsbury Publishing'),
	('Harry Potter and The Order of the Phoenix', 'Bloomsbury Publishing'),
	('Never Sniff a Gift Fish','Henry Holt & Company, Inc'),
	('A Fine and Pleasant Misery','Henry Holt & Company, Inc'),
	('The Godfather','Penguin Books'),
	('A Tale of Two Cities','Chapman & Hall'),
	('The Lord of the Rings','Allen & Unwin'),
	('Alice in Wonderland','Macmillan'),
	('The Lion, the Witch and the Wardrobe','Geoffrey Bles'),
	('The Screwtape Letters','Geoffrey Bles'),
	('20,000 Leagues under the Sea','Simon & Schuster'),
	('Watership Down','Scribner')
	;

INSERT INTO LIBRARY_BRANCH(BranchName, Address)
	VALUES
	('Sharpstown', '7660 Clarewood Dr, Houston, TX 77036, USA'),
	('Central', '1000 Fourth Avenue, Seattle, WA 98104, USA'),
	('West End', '2210 South Peabody Street, Port Angeles, WA 98362, USA'),
	('North Pole', '656 NPHS Boulevard, North Pole, AK 99705, USA'),
	('London', '14 Saint James''s Square, Saint James''s, London SW1Y 4LG, UK') 

INSERT INTO BORROWER(Name, Address, Phone)
	VALUES
	('Michael Strunk', '811 North Baker Street, Port Angeles, WA 98362, USA', '555-123-4567'),
	('John Jacob Jingleheimer Schmidt','1941 Seneca Lake Drive, Seneca Falls, NY 13148, USA','555-999-9999'),
	('David Bowman','11 Universe Drive, Jupiter, MW 19581, Stars','555-555-5555'),
	('Leto Atriedes','1 Arrakis Dessert Way, Arrakeen, Dune 21267AD','555-099-1111'),
	('Erik Gross','310 SouthWest Fourth Ave Suite 412, Portland, OR 97204, USA','503-206-6915'),
	('Mike Kazowsky','1200 Park Avenue, Emeryville, CA 94608, USA','510-922-3000'),
	('Luke Skywalker','1110 Gorgas Avenue, San Francisco, CA 94129, USA','415-623-1000'),
	('Michael Corleone','110 Longfellow Avenue, Staten Island, NY 10301, USA','666-777-8888'),
	('Nemo','42 Wallaby Way, Sydney, NSW 2774, AUS','61.491-570-110'),
	--PATRON WITHOUT CHECKOUT RECORDS
	('Jeffrey Lebowski', '5227 Santa Monica Blvd, Los Angeles, CA 90029, USA', '191-292-3993')
	;

INSERT INTO BOOK_AUTHORS (BookId, AuthorName)
	VALUES

	(1,'Mark Lee'),
	(2,'Frank Herbert'),
	(3,'Frank Herbert'),
	(4,'Frank Herbert'),
	(5,'Stephen King'),
	(6,'Stephen King'),
	(7,'Stephen King'),
	(8,'S. David Scott'),
	(9,'J. K. Rowling'),
	(10,'J. K. Rowling'),
	(11,'J. K. Rowling'),
	(12,'J. K. Rowling'),
	(13,'J. K. Rowling'),
	(14,'Patrick McManus'),
	(15,'Patrick McManus'),
	(16,'Mario Puzo'),
	(17,'Charles Dickens'),
	(18,'J.R.R. Tolkien'),
	(19,'Lewis Carroll'),
	(20,'C. S. Lewis'),
	(21,'C. S. Lewis'),
	(22,'Jules Verne'),
	(23,'Richard Adams')
	;

--INSERT DUMMY VALUES FOR BOOK COPIES USING LOOPS

DECLARE @i int = 0
DECLARE @l int = 101
DECLARE @c int = 2
DECLARE @inc int = 1
DECLARE @count int = 0
WHILE @l < 150
	BEGIN
		WHILE @count < 18 AND @i < 20
		BEGIN
			SET @i = @i + 1
			SET @count = @count + 1
			IF (@i%2) <> 0
			BEGIN 
				SET @c = 3
			END
			ELSE
			BEGIN
				SET @c = 2
			END
					
			INSERT INTO BOOK_COPIES (BookId, BranchID, NO_OF_COPIES)
			VALUES
			(@i, @l, @c)		
		END
		SET @inc = @inc + 1
		SET @i = @inc
		SET @l = @l + 10
		SET @count = 0
	END
--ADD ADDITIONAL ENTRY FOR TESTING THE LOST TRIBE
INSERT INTO BOOK_COPIES(BookId, BranchID, NO_OF_COPIES)
	VALUES
	(1,121,2)



INSERT INTO BOOK_LOANS (BookId,BranchId,CardNo,DateOut)
	VALUES
	(3,111,10000,DATEADD(DAY,-21,GETDATE())),(4,111,10000,Getdate()),(5,111,10000,Getdate()),(12,111,10000,Getdate()),(13,111,10000,Getdate()),(14,111,10000,Getdate()),
	(4,121,10001,Getdate()),(6,121,10001,Getdate()),(8,121,10001,Getdate()),(10,121,10002,Getdate()),(14,121,10002,Getdate()),(13,121,10002,Getdate()),
	(7,131,10003,Getdate()),(8,131,10003,Getdate()),(9,131,10003,Getdate()),(10,141,10003,Getdate()),
	(1,101,10004,Getdate()),(2,101,10004,Getdate()),(3,101,10004,Getdate()),(4,101,10004,Getdate()),(5,101,10004,Getdate()),(6,101,10004,Getdate()),
	(6,101,10005,DATEADD(DAY,-21,GETDATE())),(7,101,10005,Getdate()),(8,101,10005,Getdate()),(9,101,10005,Getdate()),(10,101,10005,Getdate()),(11,101,10005,Getdate()),
	(8,141,10006,Getdate()),(9,141,10006,Getdate()),(12,141,10006,Getdate()),(15,141,10005,Getdate()),(20,141,10005,Getdate()),(19,141,10005,Getdate()),
	(11,131,10007,Getdate()),(16,131,10007,Getdate()),(17,131,10007,Getdate()),(15,131,10007,Getdate()),(15,131,10008,Getdate()),(14,101,10008,Getdate()),
	(16,101,10008,Getdate()),(17,101,10008,Getdate()),(18,101,10008,Getdate()),(19,101,10008,Getdate()),(20,101,10008,DATEADD(DAY,-21,GETDATE())),(12,141,10008,Getdate()),
	(4,121,10008,DATEADD(DAY,-21,GETDATE())),(5,121,10008,DATEADD(DAY,-21,GETDATE())),(6,121,10008,DATEADD(DAY,-21,GETDATE())),(7,121,10008,DATEADD(DAY,-21,GETDATE())),(8,121,10008,DATEADD(DAY,-21,GETDATE())),(6,141,10000,DATEADD(DAY,-21,GETDATE())),(5,141,10000, DATEADD(DAY,-20,GETDATE())), (5,131,10000, DATEADD(DAY,-21,GETDATE()))
	;

GO

	--DONT't FORGET TO MAKE STORED PROCEDURES. TUrn Values into variables.

--Question 1- Check for number of @book at @library
CREATE PROC dbo.bookCopiesAtBranch @bookTitle varchar(50)='The Lost Tribe', @library varchar(50)='Sharpstown'
AS
SELECT Title, LIBRARY_BRANCH.BranchName, BOOK_COPIES.NO_OF_COPIES  FROM BOOK_COPIES
	Inner Join BOOK ON BOOK_COPIES.BookId = Book.BookId
	Inner Join LIBRARY_BRANCH ON BOOK_COPIES.BranchID = LIBRARY_BRANCH.BranchId
	Where title = @bookTitle AND LIBRARY_BRANCH.BranchName = @library
GO


--Question 2 - Check for number of @book at all branches
CREATE PROC dbo.bookCopiesAtAll @bookTitle varchar(50) = 'The Lost Tribe'
AS
SELECT Title, LIBRARY_BRANCH.BranchName, BOOK_COPIES.NO_OF_COPIES  FROM BOOK_COPIES
	Inner Join BOOK ON BOOK_COPIES.BookId = Book.BookId
	Inner Join LIBRARY_BRANCH ON BOOK_COPIES.BranchID = LIBRARY_BRANCH.BranchId
	Where title = @bookTitle
GO



--Question 3 Check for loanless patrons
CREATE PROC dbo.patronzeroLoans
AS
SELECT NAME FROM BORROWER
	WHERE NOT EXISTS
		(SELECT * FROM BOOK_LOANS
		WHERE CardNo = BORROWER.CardNo)
GO


--Question 4 Retrieve Patron Record based on @date and @library
CREATE PROC dbo.bookOnLoanDate @library varchar(50) = 'Sharpstown', @date date = null
AS
SET @date = GetDate()
SELECT l.BranchName, b.Title,  z.Name, z.Address, a.DueDate From BOOK_LOANS As a
	Inner Join BOOK As b On a.BookId = b.BookId
	Inner Join LIBRARY_BRANCH As l On l.branchID = a.branchId
	Inner Join BORROWER As z on z.CardNo = a.CardNo
	Where a.DueDate = @date AND l.BranchName = @library
GO



--Question 5 Retrieve Number of loans checked out from each branch
CREATE PROC dbo.branchLoans
AS
SELECT l.BranchName, Count(l.branchname) From Book_Loans as b
	INNER JOIN Library_Branch as l On b.branchid = l.BranchId
	GROUP BY BranchName
GO


--Question 6 Retrieve Borrowers with @booksOut # of Books out
CREATE PROC dbo.patronBookLoanCount @booksOut INT = 5
AS 
SELECT b.Name as patronName, b.address as patronAddress, Count(b.Name) as booksOut From Book_loans as a
	Inner Join Borrower as b on a.CardNo = b.CardNo
	Group by b.name, b.address
	HAVING Count(b.name) >= @booksOut
GO



--Question 7
CREATE PROC dbo.bookByAuthorNBranch @branch varchar(50) = 'Central', @Author varchar(50) = 'Stephen King'
AS

SELECT b.Title, c.NO_OF_COPIES From BOOK_AUTHORS as a
	Inner Join BOOK As b On a.BookId = b.bookId
	Inner JOIN BOOK_COPIES As c On a.BookId = c.BookId
	Inner Join LIBRARY_BRANCH as l On c.BranchID = l.BranchId
	Where l.BranchName = @branch AND a.AuthorName = @Author
GO


EXEC dbo.bookCopiesAtBranch
EXEC dbo.bookCopiesAtAll
EXEC dbo.patronZeroLoans
EXEC dbo.bookOnLoanDate
EXEC dbo.branchLoans
EXEC patronBookLoanCount
EXEC bookByAuthorNBranch


USE library
DROP Database library2
