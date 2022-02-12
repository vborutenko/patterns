--RANK()

--The RANK() function is used to give a unique rank to each record based on a specified value, for example salary, order amount etc.

--If two records have the same value then the RANK() function will assign the same rank to both records by skipping the next rank. 
--This means – if there are two identical values at rank 2, it will assign the same rank 2 to both records and then skip rank 3 and assign rank 4 to the next record.


--DENSE_RANK()

--The DENSE_RANK() function is identical to the RANK() function except that it does not skip any rank. 
--This means that if two identical records are found then DENSE_RANK() will assign the same rank to both records but not skip then skip the next rank.


--ROW_NUMBER()

--These functions assign a unique row number to each record.

--The row number will be reset for each partition if PARTITION BY is specified. Let’s see how ROW_NUMBER() works without PARTITION BY and then with PARTITION BY.

    SELECT  
         ROW_NUMBER()      OVER( PARTITION BY FirstName ORDER BY FirstName ) [ROW_NUMBER]
	,    RANK()            OVER(ORDER BY FirstName) [RANK] 
	,    DENSE_RANK()      OVER(ORDER BY FirstName) [DENSE_RANK] ,
	[Person].[Person].FirstName
    FROM [Person].[Person] 