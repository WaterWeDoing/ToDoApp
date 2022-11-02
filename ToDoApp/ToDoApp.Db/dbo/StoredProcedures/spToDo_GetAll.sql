CREATE PROCEDURE [dbo].[spToDo_GetAll]

	
AS
BEGIN
	SELECT 
		[ToDoId], 
		[Name], 
		[Priority], 
		[Deadline], 
		[DateCreated]
	FROM 
		ToDo;
END
