CREATE TABLE [dbo].[Messages]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Subject] VARCHAR(50) NOT NULL, 
    [UserMessage] VARCHAR(MAX) NOT NULL
)
