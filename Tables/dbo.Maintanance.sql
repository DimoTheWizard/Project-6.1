CREATE TABLE [dbo].[Maintanance] (
  [work_id] [int] NOT NULL,
  [type_of_work] [nvarchar](50) NOT NULL,
  [duration] [datetime] NOT NULL,
  [staff_id] [int] NOT NULL,
  CONSTRAINT [PK_Maintanance] PRIMARY KEY CLUSTERED ([work_id])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Maintanance]
  ADD CONSTRAINT [FK_Maintanance_Staff] FOREIGN KEY ([staff_id]) REFERENCES [dbo].[Staff] ([staff_id])
GO