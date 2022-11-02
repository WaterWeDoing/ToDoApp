CREATE TABLE [dbo].[Task]
(
	[TaskId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ToDoId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Priority] INT NOT NULL DEFAULT 3, 
    [Deadline] DATE NULL, 
    [DateCreated] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    CONSTRAINT [FK_Task_ToTable] FOREIGN KEY ([ToDoId]) REFERENCES [ToDo]([ToDoId])
)
