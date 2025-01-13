<Query Kind="SQL">
  <Connection>
    <ID>706b96fc-200f-4bcd-a1ca-0f6263abcb91</ID>
    <Persist>true</Persist>
    <Server>ALYSHA\SQLEXPRESS01</Server>
    <Database>schooldb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

use schooldb
 
USE schooldb

SELECT * FROM student
Where student.name = 'Jon'

CREATE PROCEDURE [dbo].[QuickCheckOnCache]
(
    @StringToFind   NVARCHAR (4000)
)
AS
SET NOCOUNT ON;

SELECT [st].[text]
	, [qs].[execution_count]
	, [qs].*
	, [p].* 
FROM [sys].[dm_exec_query_stats] AS [qs] 
	CROSS APPLY [sys].[dm_exec_sql_text] 
		([qs].[sql_handle]) AS [st]
	CROSS APPLY [sys].[dm_exec_query_plan] 
		([qs].[plan_handle]) AS [p]
WHERE [st].[text] LIKE @StringToFind
ORDER BY 1, [qs].[execution_count] DESC;
GO

EXEC [QuickCheckOnCache] '%student%';
GO