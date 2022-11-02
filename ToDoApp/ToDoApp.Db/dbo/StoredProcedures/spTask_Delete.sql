CREATE PROCEDURE [dbo].[spTask_Delete]
	@TaskId int
AS
BEGIN
	DELETE
	FROM 
		Task
	WHERE
		TaskId = @TaskId;
END

