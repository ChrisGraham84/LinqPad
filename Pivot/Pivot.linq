<Query Kind="SQL">
  <Connection>
    <ID>0a2b3a0d-3bac-49ad-83f2-23cef3365c25</ID>
    <Persist>true</Persist>
    <Server>localhost</Server>
    <Database>master</Database>
  </Connection>
</Query>

--create database School
--GO

--use School
--GO
--
--create table Students
--(
--	Id int primary key Identity,
--	StudentName varchar(50),
--	Course varchar(50),
--	Score int
--)
--GO
--
--insert into Students values ('Sally', 'English', 95)
--insert into Students values ('Sally', 'History', 82)
--insert into Students values ('Edward', 'English', 45)
--insert into Students values ('Edward', 'History', 78)
select * from students


Select * from (
	select StudentName, Score, Course
	from Students
)
As StudentTable PIVOT(
	SUM(score)
	for Course in ([English],[History])
) as SchoolPivot