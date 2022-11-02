CREATE PROCEDURE [dbo].[spTask_Update]
	@TaskId int,
	@Name nvarchar(50),
	@Priority int,
	@Deadline date
AS
BEGIN
	UPDATE
		Task
	SET
		[Name] = @Name,
		[Priority] = @Priority,
		Deadline = @Deadline
	WHERE
		TaskId = @TaskId
END

