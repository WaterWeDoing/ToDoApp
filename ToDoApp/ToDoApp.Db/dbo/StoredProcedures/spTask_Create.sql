CREATE PROCEDURE [dbo].[spTask_Create]
	@Name nvarchar(50),
	@Priority int,
	@Deadline date,
	@ToDoId int
	
AS
BEGIN
	INSERT INTO Task
	(
		[Name],
		[Priority],
		Deadline,
		ToDoId
	)
	VALUES
	(
		@Name,
		@Priority,
		@Deadline,
		@ToDoId
	);

	SELECT SCOPE_IDENTITY();
END


