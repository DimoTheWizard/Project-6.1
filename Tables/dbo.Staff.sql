CREATE TABLE [dbo].[Staff] (
  [staff_id] [int] NOT NULL,
  [staff_name] [nvarchar](70) NOT NULL,
  [time] [datetime] NULL,
  [equipment_id] [int] NOT NULL,
  CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([staff_id])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Staff]
  ADD CONSTRAINT [FK_Staff_Equipment] FOREIGN KEY ([equipment_id]) REFERENCES [dbo].[Equipment] ([equipment_id])
GO