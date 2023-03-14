CREATE TABLE [dbo].[Food] (
  [food_id] [int] NOT NULL,
  [food_name] [nvarchar](50) NOT NULL,
  [food_quantity] [int] NULL,
  CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED ([food_id])
)
ON [PRIMARY]
GO