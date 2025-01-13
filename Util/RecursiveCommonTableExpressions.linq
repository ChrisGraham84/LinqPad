<Query Kind="SQL">
  <Connection>
    <ID>41ae6d78-15ee-4560-8db5-f08f0905c10c</ID>
    <Persist>true</Persist>
    <Server>IL0824AM099024</Server>
    <Database>AdventureWorks2016CTP3</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

--------------https://www.essentialsql.com/recursive-ctes-explained/--------------------

/*
----Basic CTE to add one to a SELECT 
WITH cte
AS (SELECT 1 AS n
	UNION ALL
	SELECT n + 1
	FROM cte
	WHERE n < 50
	)
SELECT n
FROM cte;



----Basic Query to pull all the top level products
SELECT P.ProductID,
       P.Name,
       P.Color
FROM   Production.Product AS P
       INNER JOIN
       Production.BillOfMaterials AS BOM
       ON BOM.ComponentID = P.ProductID
       AND BOM.ProductAssemblyID IS NULL
       AND (BOM.EndDate IS NULL
            OR BOM.EndDate > GETDATE());
			

------CTE to pull Top level and Recursively get child level products
WITH cte_BOM (ProductID, Name, Color, Quantity, ProductLevel, ProductAssemblyID, Sort)
AS  (SELECT P.ProductID,
            CAST (P.Name AS VARCHAR (100)),
            P.Color,
            CAST (1 AS DECIMAL (8, 2)),
            1,
            NULL,
            CAST (P.Name AS VARCHAR (100))
     FROM   Production.Product AS P
            INNER JOIN
            Production.BillOfMaterials AS BOM
            ON BOM.ComponentID = P.ProductID
            AND BOM.ProductAssemblyID IS NULL
            AND (BOM.EndDate IS NULL
                OR BOM.EndDate > GETDATE())
     UNION ALL
     SELECT P.ProductID,
            CAST (REPLICATE('|---', cte_BOM.ProductLevel) + P.Name AS VARCHAR (100)),
            P.Color,
            BOM.PerAssemblyQty,
            cte_BOM.ProductLevel + 1,
            cte_BOM.ProductID,
            CAST (cte_BOM.Sort + '\' + p.Name AS VARCHAR (100))
     FROM   cte_BOM
            INNER JOIN Production.BillOfMaterials AS BOM
            ON BOM.ProductAssemblyID = cte_BOM.ProductID
            INNER JOIN Production.Product AS P
            ON BOM.ComponentID = P.ProductID
            AND (BOM.EndDate IS NULL
                OR BOM.EndDate > GETDATE())
    )
SELECT   ProductID,
         Name,
         Color,
         Quantity,
         ProductLevel,
         ProductAssemblyID,
         Sort
FROM     cte_BOM
ORDER BY Sort;