<Query Kind="SQL">
  <Connection>
    <ID>41ae6d78-15ee-4560-8db5-f08f0905c10c</ID>
    <Persist>true</Persist>
    <Server>IL0824AM099024</Server>
    <Database>ShowRoom</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

CREATE DATABASE ShowRoom
------------------------
------------------------
--DROP TABLE Cars
--GO

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
DROP TYPE CarTableType
CREATE TYPE CarTableType AS TABLE
(
	Id int primary key,
	Name nvarchar(50),
	company nvarchar(50)
)
GO

------------------------
------------------------
DROP PROCEDURE spInsertCars
DROP PROCEDURE spUpdateCars

CREATE PROCEDURE spInsertCars
@CarType CarTableType READONLY
AS
BEGIN
	INSERT INTO Cars
	SELECT * FROM @CarType
	exec spUpdateCars @CarType
END

CREATE PROCEDURE spUpdateCars
@CarType CarTableType READONLY
AS
BEGIN
	UPDATE CARS SET Name = Name + '_updated'
	WHERE Id IN (SELECT Id FROM @CarType)
	SELECT * FROM Cars
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