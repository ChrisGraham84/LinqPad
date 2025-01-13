<Query Kind="SQL">
  <Connection>
    <ID>706b96fc-200f-4bcd-a1ca-0f6263abcb91</ID>
    <Persist>true</Persist>
    <Server>ALYSHA\SQLEXPRESS01</Server>
    <Database>Library</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

---------------------------------------------
-- Create Library Database
---------------------------------------------


--CREATE DATABASE Library
--GO
--USE Library;
--CREATE TABLE Author
--(
--	id INT PRIMARY KEY,
--	author_name VARCHAR(50) NOT NULL,
--)
--
--CREATE TABLE Book
--(
--	id INT PRIMARY KEY,
--	book_name VARCHAR(50) NOT NULL,
--	price INT NOT NULL,
--	author_id INT NOT NULL,
--)
--GO
--USE Library;
--
--INSERT INTO Author 
--VALUES
--(1, 'Author1'),
--(2, 'Author2'),
--(3, 'Author3'),
--(4, 'Author4'),
--(5, 'Author5'),
--(6, 'Author6'),
--(7, 'Author7')
-- 
-- 
--INSERT INTO Book 
-- 
--VALUES
--(1, 'Book1',500, 1),
--(2, 'Book2', 300 ,2),
--(3, 'Book3',700, 1),
--(4, 'Book4',400, 3),
--(5, 'Book5',650, 5),
--(6, 'Book6',400, 3)
--GO
--



-----------------------------------
--Create Functions ---------------
-------------------------------------
--Create Func to grab Author by Id
--CREATE FUNCTION fnGetBooksByAuthorId(@AuthorId int)
--RETURNS TABLE 
--AS 
--RETURN ( SELECT * FROM Book WHERE author_id = @AuthorId)

--Sample Join statement
--SELECT A.author_name, B.id, b.book_name, B.price
--FROM Author A
--LEFT JOIN Book B ON A.id = B.author_id


SELECT A.author_name, B.id, b.book_name, B.price
FROM Author A
CROSS APPLY fnGetBooksByAuthorId(A.Id) B 


SELECT A.author_name, B.id, b.book_name, B.price
FROM Author A
OUTER APPLY fnGetBooksByAuthorId(A.Id) B 
