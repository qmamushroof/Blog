CREATE TABLE [dbo].[Subscribers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Email] NCHAR(200) NOT NULL, 
    [SubscribedAt] DATETIME2 NOT NULL, 
    [Status] VARCHAR(50) NOT NULL, 
    [UnsubscribedAt] DATETIME2 NOT NULL, 
    CONSTRAINT [AK_Subscribers_Email] UNIQUE ([Email])
)

GO

CREATE INDEX [IX_Subscribers_Status] ON [dbo].[Subscribers] ([Status])
