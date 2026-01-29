CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [PostId] INT NOT NULL, 
    [ParentCommentId] INT NULL, 
    [AuthorId] INT NULL, 
    [Content] NVARCHAR(1000) NOT NULL,
    [Status] TINYINT NOT NULL,
    [CreatedAt] DATETIME2(0) NOT NULL,
    [UpdatedAt] DATETIME2(0) NOT NULL,
    [SoftDeletedAt] DATETIME2(0) NULL,
    [GuestName] VARCHAR(50) NULL, -- for non-logged in users
    [GuestEmail] VARCHAR(50) NULL, -- for non-logged-in users
    CONSTRAINT [FK_Comments_Posts] FOREIGN KEY ([PostId]) REFERENCES [Posts]([Id]), 
    CONSTRAINT [FK_Comments_Comments] FOREIGN KEY ([ParentCommentId]) REFERENCES [Comments]([Id]), 
)

GO

CREATE INDEX [IX_Comments_PostId] ON [dbo].[Comments] ([PostId])

GO

CREATE INDEX [IX_Comments_ParentCommentId] ON [dbo].[Comments] ([ParentCommentId])

GO

CREATE INDEX [IX_Comments_Status] ON [dbo].[Comments] ([Status])
