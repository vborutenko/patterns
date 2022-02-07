-- INNER JOIN

  SELECT c.* , p.LastName
  FROM [Sales].[Customer] c
  INNER JOIN Person.Person p ON c.PersonID = p.BusinessEntityID

  -- LEFT (OUTER) JOIN

  SELECT c.* , p.LastName
  FROM [Sales].[Customer] c
  LEFT JOIN Person.Person p ON c.PersonID = p.BusinessEntityID


  --RIGHT (OUTER) JOIN
  
  SELECT c.* , p.LastName
  FROM [Sales].[Customer] c
  RIGHT OUTER JOIN Person.Person p ON c.PersonID = p.BusinessEntityID

  --FULL (OUTER) JOIN

  SELECT c.* , p.LastName
  FROM [Sales].[Customer] c
  FULL JOIN Person.Person p ON c.PersonID = p.BusinessEntityID


  -- CROSS JOIN


  --The CARTESIAN JOIN is also known as CROSS JOIN. In a CARTESIAN JOIN there is a 
  --join for each row of one table to every row of another table. This usually happens when the matching column or WHERE condition is not specified.

  SELECT c.* , p.LastName
  FROM [Sales].[Customer] c
  CROSS JOIN Person.Person p 



