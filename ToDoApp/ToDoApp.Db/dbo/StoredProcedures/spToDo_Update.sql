CREATE PROCEDURE [dbo].[spToDo_Update]
	@ToDoId int,
	@Name nvarchar(50),
	@Priority int,
	@Deadline Date	
AS
BEGIN
	UPDATE
		ToDo
	SET
		[Name] = @Name,
		[Priority] = @Priority,
		Deadline = @Deadline
	WHERE
		ToDoId = @ToDoId
END

