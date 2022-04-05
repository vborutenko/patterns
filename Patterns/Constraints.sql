--SQL constraints are used to specify rules for the data in a table.

--Constraints are used to limit the type of data that can go into a table. 
--This ensures the accuracy and reliability of the data in the table. 
--If there is any violation between the constraint and the data action, the action is aborted.

--Constraints can be column level or table level

-- 1.NOT NULL
-- 2.UNIQUE 

--Both the UNIQUE and PRIMARY KEY constraints provide a guarantee for uniqueness for a column or set of columns.
--A PRIMARY KEY constraint automatically has a UNIQUE constraint.
--However, you can have many UNIQUE constraints per table, but only one PRIMARY KEY constraint per table.

--3.PRIMARY KEY

--A table can have only ONE primary key; and in the table, this primary key can consist of single or multiple columns (fields).

--4.FOREIGN KEY

--The FOREIGN KEY constraint is used to prevent actions that would destroy links between tables.

--A FOREIGN KEY is a field (or collection of fields) in one table, that refers to the PRIMARY KEY in another table.

--5. check

--The CHECK constraint is used to limit the value range that can be placed in a column.

--6. DEFAULT 
CREATE TABLE Persons (
    ID int NOT NULL UNIQUE,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255) NOT NULL,
    Age int,
    OrderId int,
    City varchar(255) DEFAULT 'Sandnes'
    CHECK (Age>=18),
    PRIMARY KEY (ID),
    FOREIGN KEY (OrderId) REFERENCES Orders (OrderId)
);