
--The GROUP BY statement groups rows that have the same values into summary rows, like "find the number of customers in each country".

--The GROUP BY statement is often used with aggregate functions (COUNT(), MAX(), MIN(), SUM(), AVG()) to group the result-set by one or more columns.

--The HAVING clause was added to SQL because the WHERE keyword cannot be used with aggregate functions.


  SELECT FirstName , SUM(EmailPromotion),COUNT(BusinessEntityID) , MIN(LastName) FROM [Person].[Person]
  GROUP BY FirstName
  HAVING COUNT(BusinessEntityID) > 1