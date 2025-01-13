<Query Kind="SQL">
  <Connection>
    <ID>0a2b3a0d-3bac-49ad-83f2-23cef3365c25</ID>
    <Persist>true</Persist>
    <Server>localhost</Server>
    <Database>master</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

--CREATE DATABASE ShowRoom
------------------------
------------------------
--DROP TABLE Cars
GO

USE ShowRoom
GO

Create Table Cars
(
	Id int primary key,
	Name nvarchar(50),
	company nvarchar(50)
)
GO

------------------------
------------------------
--DROP TYPE CarTableType
CREATE TYPE CarTableType AS TABLE
(
	Id int primary key,
	Name nvarchar(50),
	company nvarchar(50)
)
GO

------------------------
------------------------
CREATE PROCEDURE spInsertCars
@CarType CarTableType READONLY
AS
BEGIN
	INSERT INTO CARS
	SELECT * FROM @CarType
END

------------------------
------------------------
DECLARE @CarTableType CarTableType

INSERT INTO @CarTableType VALUES (1, 'Corrolla', 'Toyota')
INSERT INTO @CarTableType VALUES (2, 'Civic', 'Honda')
INSERT INTO @CarTableType VALUES (3, '6', 'Audi')
INSERT INTO @CarTableType VALUES (4, 'C100', 'Mercedez')
INSERT INTO @CarTableType VALUES (5, 'Mustang', 'Ford')

exec spInsertCars @CarTableType