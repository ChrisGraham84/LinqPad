<Query Kind="SQL" />

SELECT[alloc_unit_type_desc] AS[Data Structure]
	, [page_count] AS[Pages]
	, [record_count] AS[Rows]
	, [min_record_size_in_bytes] AS[Min Row]
	, [max_record_size_in_bytes]
AS[Max Row]
FROM sys.dm_db_index_physical_stats
	(DB_ID ()
		, OBJECT_ID (N'LargeVariableWidthTable')
		, NULL
		, NULL
		, N'DETAILED'); --detailed mode
GO