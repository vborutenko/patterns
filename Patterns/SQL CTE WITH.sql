--A Common Table Expression, also called as CTE in short form, is a temporary named result set that you can reference within a SELECT, INSERT, UPDATE, or DELETE statement. 
--The CTE can also be used in a View.


-- select only one record for every first name

  WITH CTE AS(
    SELECT  [Person].[Person] .*
    , RN = ROW_NUMBER()OVER(PARTITION BY FirstName ORDER BY BusinessEntityId)
    FROM [Person].[Person] 
)
SELECT * FROM CTE
WHERE Rn = 1


