ALTER TRIGGER TranslatedBookTrigger
ON TranslatedBooks
FOR UPDATE
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Deleted d JOIN Inserted i ON d.TranslatedBookId = i.TranslatedBookId WHERE d.BookId != i.BookId)
	BEGIN
		ROLLBACK
		RAISERROR('You cannot change the assigned book in a composition!',12,1)
	END
END