CREATE PROCEDURE [dbo].[spToDo_Delete]
	@ToDoId int
AS
BEGIN
	DELETE
		
	FROM
		ToDo
	WHERE
		ToDoId = @ToDoId;
END

