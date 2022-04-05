--The SQL Server user-defined functions help you simplify your development 
--by encapsulating complex business logic and make them available for reuse in every query.



-- 1.User-defined scalar functions – cover the user-defined scalar functions that allow you to encapsulate complex formula or business 
--logic and reuse them in every query.

CREATE FUNCTION sales.udfNetSale(
    @quantity INT,
    @list_price DEC(10,2),
    @discount DEC(4,2)
)
RETURNS DEC(10,2)
AS 
BEGIN
    RETURN @quantity * @list_price * (1 - @discount);
END;
GO
SELECT 
    sales.udfNetSale(10,100,0.1) net_sale;
GO


--2.A table-valued function is a user-defined function that returns data of a table type. 
--The return type of a table-valued function is a table, therefore, you can use the table-valued function just like you would use a table.

CREATE FUNCTION udfProductInYear (
    @model_year INT
)
RETURNS TABLE
AS
RETURN
    SELECT 
        product_name,
        model_year,
        list_price
    FROM
        production.products
    WHERE
        model_year = @model_year;

GO
SELECT 
    * 
FROM 
    udfProductInYear(2017);


--A multi-statement table-valued function or MSTVF is a table-valued function that returns the result of multiple statements.

GO
CREATE FUNCTION udfContacts()
    RETURNS @contacts TABLE (
        first_name VARCHAR(50),
        last_name VARCHAR(50),
        email VARCHAR(255),
        phone VARCHAR(25),
        contact_type VARCHAR(20)
    )
AS
BEGIN
    INSERT INTO @contacts
    SELECT 
        first_name, 
        last_name, 
        email, 
        phone,
        'Staff'
    FROM
        sales.staffs;

    INSERT INTO @contacts
    SELECT 
        first_name, 
        last_name, 
        email, 
        phone,
        'Customer'
    FROM
        sales.customers;
    RETURN;
END;