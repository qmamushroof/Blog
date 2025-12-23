CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(300) NOT NULL, 
    [Slug] NVARCHAR(300) NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [Status] VARCHAR(50) NOT NULL, 
    [Priority] VARCHAR(50) NOT NULL, 
    [PublishedAt] DATETIME2 NULL, 
    [Deadline] DATETIME2 NULL, 
    [HeaderImageUrl] VARCHAR(500) NULL, 
    [CreatedAt] DATETIME2 NOT NULL, 
    [UpdatedAt] DATETIME2 NOT NULL, 
    [DeletedAt] DATETIME2 NULL, 
    [CategoryId] INT NULL, 
    [AuthorId] VARCHAR(100) NULL, 
    [ShareCount] INT NOT NULL, 
    CONSTRAINT [FK_Posts_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]) ON DELETE SET NULL, 
    CONSTRAINT [AK_Posts_Slug] UNIQUE ([Slug])
)
