-- Read Uncommitted


--This is the lowest isolation level there is. 
--Read uncommitted causes no shared locks to be requested which allows you to read data that is currently being modified in other transactions. 
--It also allows other transactions to modify data that you are reading.

BEGIN TRAN
UPDATE Person.Person SET MiddleName = 'tran1' where BusinessEntityID = 1
--Simulate having some intensive processing here with a wait
WAITFOR DELAY '00:00:30'
ROLLBACK

SELECT * FROM Person.Person WITH(NOLOCK)  where BusinessEntityID = 1 


-- Read Committed

--This is the default isolation level and means selects will only return committed data.

BEGIN TRAN
UPDATE Person.Person SET MiddleName = 'tran1' where BusinessEntityID = 1
--Simulate having some intensive processing here with a wait
WAITFOR DELAY '00:00:30'
ROLLBACK

SELECT * FROM Person.Person where BusinessEntityID = 1 


--Repeatable Read

--This is similar to Read Committed but with the additional guarantee that if you issue the same select twice in a transaction you will get the same results both times.
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT top(5) *  FROM Person.Person
--Simulate having some intensive processing here with a wait
WAITFOR DELAY '00:00:10'

SELECT top(5) * FROM Person.Person

ROLLBACK


UPDATE Person.Person SET MiddleName = 'ttttt' where BusinessEntityID = 1 --(Non-repeatable read)


--One last thing to know about Repeatable Read is that the data can change between 2 queries if more records are added. 
--Repeatable Read guarantees records queried by a previous select 
--will not be changed or deleted, it does not stop new records being inserted so it is still very possible to get Phantom Reads at this isolation level.

SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT top(5) *  FROM Person.ContactType order by ContactTypeID desc
--Simulate having some intensive processing here with a wait
WAITFOR DELAY '00:00:10'

SELECT top(5) *  FROM Person.ContactType order by ContactTypeID desc

ROLLBACK


INSERT INTO Person.ContactType VALUES ('test','2008-04-30 00:00:00.000') -- allow with repeatable read (Phantom read)


--Serializable

--This isolation level takes Repeatable Read and adds the guarantee that no new data will be added eradicating the chance of getting Phantom Reads



--Snapshot

--This provides the same guarantees as serializable. So what's the difference? Well it’s more in the way it works, using snapshot doesn't
--block other queries from inserting or updating the data touched by the snapshot transaction. Instead row versioning is 
--used so when data is changed the old version is kept in tempdb so existing transactions will see the version without the change

--You’re using extra resources on the SQL Server to hold multiple versions of your changes.



--Dirty read 

--Uncommitted data is read.


-- Non repeatable read

--Phantom read