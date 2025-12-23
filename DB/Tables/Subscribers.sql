CREATE TABLE [dbo].[Subscribers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Email] NCHAR(200) NOT NULL, 
    [SubscribedAt] DATETIME2 NOT NULL, 
    [Status] VARCHAR(20) NOT NULL, 
    [UnsubscribedAt] DATETIME2 NULL, 
    CONSTRAINT [AK_Subscribers_Email] UNIQUE ([Email])
)
