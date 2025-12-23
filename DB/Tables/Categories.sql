CREATE TABLE [dbo].[Categories]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Slug] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [AK_Categories_Name] UNIQUE ([Name]),
    CONSTRAINT [AK_Categories_Slug] UNIQUE ([Slug])
)
