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

WITH PV_RN AS
(
	SELECT ROW_NUMBER() OVER (ORDER BY PatientID, VisitDate) AS ROWID, * 
	FROM PatientVisit
)
SELECT t1.PatientID, t2.VisitDate as DateChanged, t1.Height as HeightChangedFrom, t2.Height as HeightChangedTo
FROM PV_RN t1
JOIN PV_RN t2 on t2.ROWID = t1.ROWID + 1
WHERE t1.PatientID = t2.PatientID and t1.Height <> t2.Height
ORDER BY t1.PatientID, t2.VisitDate;

/*
SELECT ph.PatientID, ph.Height as BeginningHeight, VisitDate, pv.Height as ChangedHeight
FROM PatientHeight ph 
INNER JOIN PatientVisit pv ON ph.PatientID = pv.PatientID
WHERE ph.Height <> pv.Height
ORDER BY ph.PatientID

*/