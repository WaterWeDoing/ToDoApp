CREATE PROCEDURE [dbo].[spToDo_Create]
	@Name nvarchar(50),
	@Priority int,
	@Deadline date

AS
BEGIN
	INSERT INTO ToDo
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