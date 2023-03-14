CREATE TABLE [dbo].[Beverage] (
  [beverage_id] [int] NOT NULL,
  [beverage_name] [nvarchar](50) NOT NULL,
  [beverage_quantity] [int] NULL,
  CONSTRAINT [PK_Beverage] PRIMARY KEY CLUSTERED ([beverage_id])
)
ON [PRIMARY]
GO