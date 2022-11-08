CREATE PROCEDURE [dbo].[spToDo_Get]
	@ToDoId int


AS
BEGIN
	SELECT
		[ToDoId], 
		[Name], 
		[Priority], 
		[Deadline], 
		[DateCreated]
	FROM
		ToDo
	WHERE
		ToDoId = @ToDoId;
END

