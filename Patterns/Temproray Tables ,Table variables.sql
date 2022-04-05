-- The simplest way of creating a temporary table is by using an INTO statement within a SELECT

  SELECT FirstName,MiddleName,LastName
  INTO #PersonTemp
  FROM Person.Person

  -- The second method is similar to creating normal tables

  CREATE TABLE #PersonTemp
(
	FirstName NVARCHAR(50),
	MiddleName NVARCHAR(50),
	LastName NVARCHAR (50)

)

INSERT INTO #PersonTemp
SELECT FirstName,MiddleName,LastName
FROM Person.Person



--It is pertinent to mention here that, a temporary table is only accessible to the connection that created that temporary table. 
--It is not accessible to other connections. However, we can create temporary tables that are accessible to all the open connections. 
--Such temporary tables are called global temporary tables. The name of the global temporary table starts with a double hash symbol (##). 
--Let’s create a global temporary table that contains records of all female students from the student table.

  SELECT FirstName,MiddleName,LastName
  INTO ##PersonTemp
  FROM Person.Person


  /*
  A temporary table is automatically deleted when the connection that created the table is closed. 
  Alternatively, when you close the query window that created the temporary table, without saving the changes the table will be closed. 
  If a connection is executing some queries on the global table then those queries have to be completed first before the global table is deleted.
  */


  --The table variable is a special type of the local variable that helps to store data temporarily, similar to the temp table in SQL Server.

DECLARE @ListOWeekDays TABLE(DyNumber INT,DayAbb VARCHAR(40) , WeekName VARCHAR(40))
 
INSERT INTO @ListOWeekDays
VALUES 
(1,'Mon','Monday')  ,
(2,'Tue','Tuesday') ,
(3,'Wed','Wednesday') ,
(4,'Thu','Thursday'),
(5,'Fri','Friday'),
(6,'Sat','Saturday'),
(7,'Sun','Sunday')	
SELECT * FROM @ListOWeekDays

--table variables are stored in the tempdb database
