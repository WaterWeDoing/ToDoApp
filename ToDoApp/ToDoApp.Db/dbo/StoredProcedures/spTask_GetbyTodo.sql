CREATE PROCEDURE [dbo].[spTask_GetbyTodo]
	@ToDoId int

AS
BEGIN
	SELECT
		[TaskId], 
		[ToDoId], 
		[Name], 
		[Priority], 
		[Deadline], 
		[DateCreated]
	FROM
		Task
	WHERE
		ToDoId = @ToDoId;
END