CREATE TABLE [dbo].[Messages]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Subject] VARCHAR(50) NOT NULL, 
    [Message] VARCHAR(MAX) NOT NULL
)
