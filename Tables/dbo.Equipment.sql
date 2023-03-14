CREATE TABLE [dbo].[Equipment] (
  [equipment_id] [int] NOT NULL,
  [equipment_name] [nvarchar](100) NOT NULL,
  [equipment_quantity] [int] NULL,
  [staff_id] [int] NOT NULL,
  CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED ([equipment_id])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Equipment]
  ADD CONSTRAINT [FK_Equipment] FOREIGN KEY ([staff_id]) REFERENCES [dbo].[Staff] ([staff_id])
GO