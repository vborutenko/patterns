--Autocommit Transaction mode is the default transaction for the SQL Server. 
--In this mode, each T-SQL statement is evaluated as a transaction 
--and they are committed or rolled back according to their results. The successful statements are committed and the failed statements are rolled back immediately

--Implicit transaction mode enables to SQL Server to start an implicit transaction for every DML statement but we need to use the 
--commit or rolled back commands explicitly at the end of the statements

SET IMPLICIT_TRANSACTIONS ON 
UPDATE 
    Person 
SET 
    Lastname = 'Sawyer', 
    Firstname = 'Tom' 
WHERE 
    PersonID = 2 
SELECT 
    IIF(@@OPTIONS & 2 = 2, 
    'Implicit Transaction Mode ON', 
    'Implicit Transaction Mode OFF'
    ) AS 'Transaction Mode' 
SELECT 
    @@TRANCOUNT AS OpenTransactions 
COMMIT TRAN 
SELECT 
    @@TRANCOUNT AS OpenTransactions


--Explicit transaction mode provides to define a transaction exactly with the starting and ending points of the transaction

--Rallback

BEGIN TRAN
UPDATE Person 
SET    Lastname = 'Donald', 
        Firstname = 'Duck'  WHERE PersonID=2
 
 
SELECT * FROM Person WHERE PersonID=2
 
ROLLBACK TRAN 

--Save Points in Transactions
BEGIN TRANSACTION 
INSERT INTO Person 
VALUES('Mouse', 'Micky','500 South Buena Vista Street, Burbank','California',43)
SAVE TRANSACTION InsertStatement
DELETE Person WHERE PersonID=3
SELECT * FROM Person 
ROLLBACK TRANSACTION InsertStatement
COMMIT
SELECT * FROM Person



--Auto Rollback transactions in SQL Server

BEGIN TRAN
INSERT INTO Person 
VALUES('Bunny', 'Bugs','742 Evergreen Terrace','Springfield',54)
    
UPDATE Person SET Age='MiddleAge' WHERE PersonID=7
SELECT * FROM Person
 
COMMIT TRAN

--@@TRANCOUNT - Returns the number of BEGIN TRANSACTION statements that have occurred on the current connection.


BEGIN TRANSACTION [Tran1]

  BEGIN TRY

      INSERT INTO [Test].[dbo].[T1] ([Title], [AVG])
      VALUES ('Tidd130', 130), ('Tidd230', 230)

      UPDATE [Test].[dbo].[T1]
      SET [Title] = N'az2' ,[AVG] = 1
      WHERE [dbo].[T1].[Title] = N'az'

      COMMIT TRANSACTION [Tran1]

  END TRY

  BEGIN CATCH

      ROLLBACK TRANSACTION [Tran1]

  END CATCH  


