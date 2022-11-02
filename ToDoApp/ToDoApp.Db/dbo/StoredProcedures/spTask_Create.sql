CREATE PROCEDURE [dbo].[spTask_Create]
	@Name nvarchar(50),
	@Priority int,
	@Deadline date
	
AS
BEGIN
	INSERT INTO Task
	(
		[Name],
		[Priority],
		Deadline
	)
	VALUES
	(
		@Name,
		@Priority,
		@Deadline
	);

	SELECT SCOPE_IDENTITY();
END


