CREATE TABLE [dbo].[Rent] (
  [rent_id] [int] NOT NULL,
  [amount] [int] NULL,
  [date] [datetime] NOT NULL,
  CONSTRAINT [PK_Rent] PRIMARY KEY CLUSTERED ([rent_id])
)
ON [PRIMARY]
GO