CREATE TABLE [dbo].[Customer] (
  [customer_id] [int] NOT NULL,
  [iban] [int] NOT NULL,
  CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([customer_id])
)
ON [PRIMARY]
GO