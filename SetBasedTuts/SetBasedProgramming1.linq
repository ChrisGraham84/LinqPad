<Query Kind="SQL">
  <Connection>
    <ID>41ae6d78-15ee-4560-8db5-f08f0905c10c</ID>
    <Persist>true</Persist>
    <Server>IL0824AM099024</Server>
    <Database>ShowRoom</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

---https://www.itprotoday.com/analytics-and-reporting/programming-sql-set-based-way----

SET NOCOUNT ON;

CREATE TABLE Dates
(ID int, VisitDate datetime);

--populate the table with 20 visit dates
DECLARE @i int, @startdate datetime;
SET @i = 1;
SET @startdate = GETDATE();

WHILE @i <= 20
BEGIN
	INSERT Dates
	(ID, VisitDate)
	Values (@i, @startdate);
		SET @startdate = DATEADD(dd, 7, @startdate)
	SET @i = @i + 1;
END

CREATE TABLE PatientHeight
(PatientID int not null, Height int);

--populate table with 1000 patients with height between 59 and 47 inches
SET @i = 1;

WHILE @i <= 1000
BEGIN
	INSERT PatientHeight
	(PatientID, Height)
	VALUES (@i, @i % 16 + 59);
		SET @i = @i + 1
END

ALTER TABLE PatientHeight ADD CONSTRAINT PK_PatientHeight
	PRIMARY KEY (PatientID);

-- cartesian join produces 200,000 Patient Visit Records

SELECT 
	ISNULL(PatientID, -1) AS PatientID,
	ISNULL(VisitDate, '19000101') AS VisitDate,
	Height
INTO PatientVisit
FROM PatientHeight
CROSS JOIN Dates;

ALTER TABLE PatientVisit ADD CONSTRAINT PK_PatientVisit
	PRIMARY KEY (PatientID, VisitDate);
	
-- creat changes in height
SET @i = 3

WHILE @i < 10000
BEGIN
	UPDATE pv
	SET Height = Height +2
	FROM PatientVisit pv
	WHERE PatientID = @i AND pv.VisitDate = (SELECT TOP 1 VisitDate FROM Dates WHERE id = ABS(CHECKSUM(@i)) % 19);
   SET @i = @i + 7;
END


/*
-- return AdventureWorks to its previous state when you are finished
-- with this example.

DROP TABLE Dates;
DROP TABLE PatientHeight;
DROP TABLE PatientVisit;
*/