CREATE TABLE [dbo].[Tags]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Slug] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [AK_Tags_Name] UNIQUE ([Name]),
    CONSTRAINT [AK_Tags_Slug] UNIQUE ([Slug])
)

GO

CREATE INDEX [IX_Tags_Name] ON [dbo].[Tags] ([Name])

GO

CREATE INDEX [IX_Tags_Slug] ON [dbo].[Tags] ([Slug])
