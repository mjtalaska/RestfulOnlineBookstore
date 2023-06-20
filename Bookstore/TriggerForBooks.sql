CREATE TRIGGER BookTrigger
ON Books
FOR UPDATE
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Deleted d JOIN Inserted i ON d.BookId = i.BookId WHERE d.PublisherId != i.PublisherId)
	BEGIN
		ROLLBACK
		RAISERROR('You cannot change the assigned publisher in a composition!',12,1)
	END
END