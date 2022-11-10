CREATE PROCEDURE [dbo].[spTask_Get]
	@TaskId int
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
		TaskId = @TaskId;
END


