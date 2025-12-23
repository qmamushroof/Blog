CREATE TABLE [dbo].[ShareTracks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Platform] VARCHAR(100) NULL, 
    [ShareUrl] VARCHAR(500) NULL, 
    [SharedAt] DATETIME2 NOT NULL, 
    [UserIp] VARCHAR(40) NULL, 
    [PostId] INT NOT NULL, 
    CONSTRAINT [FK_ShareTracks_Posts] FOREIGN KEY ([PostId]) REFERENCES [Posts]([Id])  ON DELETE SET NULL
)
