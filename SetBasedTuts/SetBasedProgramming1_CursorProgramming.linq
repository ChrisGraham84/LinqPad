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


CREATE Table #Changes
(PatientID int,
VisitDate datetime,
BeginHeight smallint,
CurrentHeight smallint);

DECLARE @PatientID int,
@CurrentID int,
@BeginHeight smallint,
@CurrentHeight smallint,
@VisitDate datetime;

SET @PatientID = 0;

DECLARE Patient_cur CURSOR FAST_FORWARD FOR
SELECT PatientID, VisitDate, Height
FROM PatientVisit
ORDER BY PatientID, VisitDate;

OPEN Patient_cur;

FETCH NEXT FROM Patient_cur INTO  @CurrentID, @VisitDate, @CurrentHeight;

WHILE @@FETCH_STATUS = 0
BEGIN
	--first recrod for patient
IF @PatientID <> @CurrentID
BEGIN
	SET @PatientID = @CurrentID;
	SET @BeginHeight = @CurrentHeight;
END

IF @BeginHeight <> @CurrentHeight
BEGIN
INSERT #Changes (PatientID, VisitDate, BeginHeight, CurrentHeight) VALUES (@PatientID, @VisitDate, @BeginHeight, @CurrentHeight);

SET @BeginHeight = @CurrentHeight

END

FETCH NEXT FROM Patient_cur INTO  @CurrentID, @VisitDate, @CurrentHeight;

END

CLOSE Patient_cur;
DEALLOCATE Patient_cur;

SELECT * FROM #CHANGES 

DROP TABLE #Changes