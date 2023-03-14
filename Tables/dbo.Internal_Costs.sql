CREATE TABLE [dbo].[Internal_Costs] (
  [cost_id] [int] NOT NULL,
  [maintanane_id] [int] NOT NULL,
  [staff_id] [int] NOT NULL,
  CONSTRAINT [PK_Internal_Costs] PRIMARY KEY CLUSTERED ([cost_id])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Internal_Costs]
  ADD CONSTRAINT [FK_Internal_Costs_Staff] FOREIGN KEY ([staff_id]) REFERENCES [dbo].[Staff] ([staff_id])
GO