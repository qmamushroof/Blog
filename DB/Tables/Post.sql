CREATE TABLE [dbo].[Post]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(300) NOT NULL, 
    [Slug] NVARCHAR(300) NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [Status] INT NOT NULL, 
    [Priority] INT NOT NULL, 
    [PublishedAt] DATETIME NULL, 
    [Deadline] DATETIME NULL, 
    [HeaderImageUrl] VARCHAR(500) NULL, 
    [CreatedAt] DATETIME NOT NULL, 
    [UpdatedAt] DATETIME NOT NULL, 
    [DeletedAt] DATETIME NULL, 
    [CategoryId] INT NOT NULL, 
    [AuthorId] VARCHAR(100) NULL, 
    [ShareCount] INT NULL, 
    CONSTRAINT [FK_Post_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
