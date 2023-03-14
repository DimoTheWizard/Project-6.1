CREATE TABLE [dbo].[Transaction] (
  [transaction_id] [int] NOT NULL,
  [date_of_transaction] [datetime] NOT NULL,
  [type_of_transaction] [nvarchar](50) NOT NULL,
  [customer_id] [int] NOT NULL,
  [food_id] [int] NOT NULL,
  [beverage_id] [int] NOT NULL,
  [rent_id] [int] NOT NULL,
  [cost_id] [int] NOT NULL,
  CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([transaction_id])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transaction]
  ADD CONSTRAINT [FK_Transaction_Beverage] FOREIGN KEY ([beverage_id]) REFERENCES [dbo].[Beverage] ([beverage_id])
GO

ALTER TABLE [dbo].[Transaction]
  ADD CONSTRAINT [FK_Transaction_Cost] FOREIGN KEY ([cost_id]) REFERENCES [dbo].[Internal_Costs] ([cost_id])
GO

ALTER TABLE [dbo].[Transaction]
  ADD CONSTRAINT [FK_Transaction_Customer] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([customer_id])
GO

ALTER TABLE [dbo].[Transaction]
  ADD CONSTRAINT [FK_Transaction_Food] FOREIGN KEY ([food_id]) REFERENCES [dbo].[Food] ([food_id])
GO

ALTER TABLE [dbo].[Transaction]
  ADD CONSTRAINT [FK_Transaction_Rent] FOREIGN KEY ([rent_id]) REFERENCES [dbo].[Rent] ([rent_id])
GO