CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(300) NOT NULL, 
    [Slug] NVARCHAR(300) NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [Status] VARCHAR(50) NOT NULL, 
    [Priority] VARCHAR(50) NOT NULL, 
    [PublishedAt] DATETIME2(0) NULL, 
    [Deadline] DATETIME2(0) NULL, 
    [HeaderImageUrl] VARCHAR(500) NULL, 
    [CreatedAt] DATETIME2(0) NOT NULL, 
    [UpdatedAt] DATETIME2(0) NOT NULL, 
    [DeletedAt] DATETIME2(0) NULL, 
    [CategoryId] INT NULL, 
    [AuthorId] VARCHAR(100) NULL, 
    [ShareCount] INT NULL, 
    CONSTRAINT [FK_Posts_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]) ON DELETE SET NULL, 
    CONSTRAINT [AK_Posts_Slug] UNIQUE ([Slug])
)

GO

CREATE INDEX [IX_Posts_Status] ON [dbo].[Posts] ([Status])

GO

CREATE INDEX [IX_Posts_Priority] ON [dbo].[Posts] ([Priority])

GO

CREATE INDEX [IX_Posts_PublishedAt] ON [dbo].[Posts] ([PublishedAt])

GO

CREATE INDEX [IX_Posts_Deadline] ON [dbo].[Posts] ([Deadline])

GO

CREATE INDEX [IX_Posts_CategoryId] ON [dbo].[Posts] ([CategoryId])

GO

CREATE INDEX [IX_Posts_Slug] ON [dbo].[Posts] ([Slug])
