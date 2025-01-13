<Query Kind="SQL">
  <Connection>
    <ID>9206e9da-25ca-4c95-b5dd-afd7610a70ec</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>Lydia</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>AdventureWorks2022</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

--SELECT Count(Name)
--FROM [Production].[Product]
--WHERE ProductID = ANY (SELECT ProductID From [Production].[WorkOrder] WHERE OrderQty < 10)

--SELECT TOP 10 Name FROM [Production].[Product]
--UNION 
--SELECT Name FROM [Sales].[SalesReason]

--SELECT TOP 20 OrderQty FROM [Production].[WorkOrder] ORDER BY OrderQty DESC
--SELECT Count(OrderQty) FROM [Production].[WorkOrder] OrderQty
--SELECT TOP 10 Count(OrderQty) FROM [Production].[WorkOrder] GROUP BY OrderQty 
--SELECT MAX(OrderQty) FROM [Production].[WorkOrder]

--SELECT TOP 10 Name FROM [Production].[Product]
--SELECT TOP 10 ASCII(Name) AS NumCodeOfFirstChar FROM [Production].[Product]

--SELECT CHARINDEX('a', Name) FROM [Production].[Product]

--SELECT CONCAT('Name ',Name,', ID', ProductID) FROM [Production].[Product]

--SELECT CONCAT_WS(' ',FirstName, MiddleName, LastName) FROM [Person].[Person]

SELECT Count(DISTINCT FirstName) FROM [Person].[Person]
SELECT  Count(FirstName) FROM [Person].[Person]
SELECT (1.0 *(SELECT Count(DISTINCT FirstName) FROM [Person].[Person]) / (SELECT  Count(FirstName) FROM [Person].[Person]) * 100) AS namediverse



/* SELECT Name
FROM [Production].[Product]
WHERE LEN(Name) > 6 AND LEN(Name) < 15 */

--SELECT FLOOR(RAND() * 10 + 5)

--SELECT COALESCE(NULL, NULL, 'TEST1', NULL, 'TEST2')

--SELECT CURRENT_USER

--SELECT IIF(10>1, 'true', 'false')

