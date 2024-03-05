


select * from addressbook;




CREATE PROCEDURE InsertRecord
    @id int,
    @name VARCHAR(55),
	@age int
AS
BEGIN
    INSERT INTO addressbook (id, name,age) 
    VALUES (@id, @name,@age);
END;









CREATE PROCEDURE GetRecords
AS
BEGIN
    SELECT * FROM addressbook;
END;








CREATE PROCEDURE UpdateRecord
    @id INT,
    @name VARCHAR(55),
    @age INT
AS
BEGIN
    UPDATE addressbook 
    SET name = @name,
		age = @age
    WHERE id = @id; 
END;











CREATE PROCEDURE DeleteRecord
    @id INT
AS
BEGIN
    DELETE FROM addressbook 
    WHERE id = @id; 
END;

