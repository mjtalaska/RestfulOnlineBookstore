CREATE Trigger CommentTrigger
ON Comments
FOR INSERT
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM inserted i JOIN Purchases p ON i.UserId = p.UserId AND i.BookId = p.BookId)
	BEGIN
		ROLLBACK
		RAISERROR('Comment is a subset of purchase! You cannot comment on a book you have not purchased',12,1)
	END
END