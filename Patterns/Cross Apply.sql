
  --For every state display first 3 addresses
  SELECT * FROM [Person].[StateProvince] sp
  CROSS APPLY ( SELECT TOP 3 * FROM [Person].[Address] pa WHERE pa.StateProvinceID = sp.StateProvinceID    ) a


  --for every state display first 3 addresses.If there arnot any addreses for state - still display it
  SELECT * FROM [Person].[StateProvince] sp
  OUTER APPLY ( SELECT TOP 3 * FROM [Person].[Address] pa WHERE pa.StateProvinceID = sp.StateProvinceID    ) a


  --  table function
  select * from [Person].[Person] p
  cross apply (select * from ufnGetContactInformation(p.BusinessEntityID)) ci 