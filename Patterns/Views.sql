--A VIEW in SQL Server is like a virtual table that contains data from one or multiple tables. 
--It does not hold any data and does not exist physically in the database

--In a VIEW, we can also control user security for accessing the data from the database tables. 
--We can allow users to get the data from the VIEW, and the user does not require permission for each table or column to fetch data.

--These are also created for simplification purpose in order to encapsulate frequently executed, 
--complex queries that read from multiple tables each time.

CREATE VIEW EmployeeRecords
AS
     SELECT *
     FROM [HumanResources].[Employee];

CREATE VIEW EmployeeRecords2
AS
     SELECT NationalIDNumber,LoginID,JobTitle 
     FROM [HumanResources].[Employee];

--By Default, SQL Server does not modify the schema and metadata for the VIEW. 
--We can use the system stored procedure sp_refreshview to refresh the metadata of any view.

Exec sp_refreshview DemoView

--We do not want any changes to be made in the tables being used in the VIEW. 
--We can use SCHEMABINDING option to lock all tables used in the VIEW and deny any alter table statement against those tables.

CREATE VIEW DemoView
WITH SCHEMABINDING
AS
     SELECT TableID, ForeignID ,Value, CodeOne
     FROM [dbo].[MyTable];


--We can use SQL VIEW to insert, update and delete data in a single SQL table. We need to note the following things regarding this.


--INDEXED VIEW.

--There are no performance benefits from using standard views; 
--if the view definition contains complex processing and joins between huge numbers of rows from a combination of tables, 
--and you are calling this view very frequently, performance degradation will be noticed clearly.
-- To enhance the performance of such complex queries, a unique clustered index can be created on the view,

--You can benefit from indexed views if its data is not frequently updated, 
--as the performance degradation of maintaining the data changes of the indexed view is higher than the performance enhancement 
--of using this Indexed View


USE SQLShackDemo 
GO
CREATE VIEW [HumanResources].EmployeeFullInfo_Indexed
WITH SCHEMABINDING AS
SELECT EMP.[BusinessEntityID]
      ,EMP.[LoginID]
      ,EMP.[JobTitle]
      ,EMP.[BirthDate]
      ,EMP.[MaritalStatus]
      ,EMP.[Gender]
      ,EMP.[HireDate]
      ,Dep.Name AS Department
	  ,SH.Name AS ShiftName
	  ,EMPPayHist.Rate AS EmployeeRate
  FROM [HumanResources].[Employee] AS EMP
  JOIN [HumanResources].[EmployeeDepartmentHistory] AS EMPDepHist
  ON EMP.BusinessEntityID =EMPDepHist.BusinessEntityID 
  JOIN [HumanResources].[Department] AS Dep
  ON DEP.DepartmentID =EMPDepHist .DepartmentID 
  JOIN [HumanResources].[Shift] SH
  ON EMPDepHist.ShiftID=SH.ShiftID 
  JOIN [HumanResources].[EmployeePayHistory] EMPPayHist
  ON EMP.BusinessEntityID =EMPPayHist.BusinessEntityID 
  GO

  CREATE UNIQUE CLUSTERED INDEX IX_VEMPInfo 
	ON EmployeeFullInfo_Indexed
	 ([BusinessEntityID]
      	,[LoginID]
      	,[JobTitle]
      	,[BirthDate]
     	,[MaritalStatus]
     	,[Gender]
    	,[HireDate]
     	,Department
     	,ShiftName);
