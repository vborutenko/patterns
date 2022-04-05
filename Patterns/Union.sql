-- The UNION operator is used to combine the result-set of two or more SELECT statements.

--Every SELECT statement within UNION must have the same number of columns
--The columns must also have similar data types
--The columns in every SELECT statement must also be in the same order


  select  PersonType,NameStyle from [Person].[Person] p
  UNION
  select 'abc',7

  --The UNION operator selects only distinct values by default. To allow duplicate values, use UNION ALL:

  select  PersonType,NameStyle from [Person].[Person] p
  UNION ALL
  select 'abc',7