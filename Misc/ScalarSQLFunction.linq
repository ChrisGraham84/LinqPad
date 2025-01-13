<Query Kind="SQL">
  <Connection>
    <ID>ef5b3c36-ba1a-4022-b709-fff4b4f55e72</ID>
    <Persist>true</Persist>
    <Server>DESKTOP-0KNPA1M</Server>
    <Database>JunkDB</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

BEGIN 
	IF OBJECT_ID('dbo.T1') IS NOT NULL DROP TABLE dbo.T1;
	IF OBJECT_ID('dbo.T2') IS NOT NULL DROP TABLE dbo.T2;
	CREATE TABLE dbo.T1 (Col1 INT);
	CREATE TABLE dbo.T2 (ColA INT);
	INSERT dbo.T1 VALUES (1), (100);
	INSERT dbo.T2 VALUES (1), (90);
END
GO
----------------------------
----------------------------
IF OBJECT_ID('dbo.fn_mapsomething') IS NOT NULL DROP FUNCTION dbo.fn_mapsomething;
GO
CREATE FUNCTION dbo.fn_mapsomething(@a INT, @b INT, @c INT)
RETURNS VARCHAR(1000) AS
BEGIN
	RETURN 'A B & C ARE: '+CONCAT(@a, ',', @b, ',', @c);
END
GO
----------------------------
----------------------------
IF OBJECT_ID('dbo.usp_proc') IS NOT NULL DROP PROCEDURE dbo.usp_proc;
GO
CREATE PROC dbo.usp_proc @x INT
AS
BEGIN
	SELECT 
		T1.Col1,
		T2.ColA,
		dbo.fn_mapsomething(@x, T1.Col1, T2.ColA) AS ThisColumn
	FROM 	dbo.T1 AS t1
	LEFT JOIN dbo.T2 AS t2
		ON t1.Col1 = t2.ColA;
END
GO

exec dbo.usp_proc 555