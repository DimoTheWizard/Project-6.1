CREATE TABLE [dbo].[User] (
  [user_id] [int] IDENTITY,
  [username] [nvarchar](50) NOT NULL,
  [password] [nvarchar](10) NOT NULL,
  CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([user_id])
)
ON [PRIMARY]
GO