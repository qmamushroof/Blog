CREATE TABLE [dbo].[ShareTracks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Platform] VARCHAR(100) NULL, 
    [ShareUrl] VARCHAR(500) NULL, 
    [SharedAt] DATETIME2(0) NOT NULL, 
    [UserIp] VARBINARY(16) NULL, 
    [PostId] INT NOT NULL, 
    CONSTRAINT [FK_ShareTracks_Posts] FOREIGN KEY ([PostId]) REFERENCES [Posts]([Id])  ON DELETE SET NULL
)

GO

CREATE INDEX [IX_ShareTracks_PostId] ON [dbo].[ShareTracks] ([PostId])
