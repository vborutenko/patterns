--An index is an on-disk structure associated with a table or view that speeds retrieval of rows from the table or view. 
--An index contains keys built from one or more columns in the table or view. 
--These keys are stored in a structure (B-tree) that enables SQL Server to find the row or rows associated with the key values quickly and efficiently.


-- 1. Clustered vs non-clustered

--The key difference between clustered indexes and non clustered indexes is that the leaf level of the clustered index is the table. 
--This has two implications.

-- 1.The rows on the clustered index leaf pages always contain something for each of the (non-sparse) columns 
--in the table (either the value or a pointer to the actual value).

-- 2.The clustered index is the primary copy of a table.

--Non clustered indexes can also do point 1 by using the INCLUDE clause (Since SQL Server 2005) 
--to explicitly include all non-key columns but they are secondary representations and there is always another copy of the data around (the table itself).



-- create nonclustered index
CREATE NONCLUSTERED INDEX IX_ProductVendor_VendorID   
    ON Purchasing.ProductVendor (BusinessEntityID);   


-- create unique nonclustered index
CREATE UNIQUE INDEX AK_UnitMeasure_Name   
   ON Production.UnitMeasure (Name);   

-- create filtered index

CREATE NONCLUSTERED INDEX FIBillOfMaterialsWithEndDate  
    ON Production.BillOfMaterials (ComponentID, StartDate)  
    WHERE EndDate IS NOT NULL ;  