CREATE TABLE [dbo].[Internal_Costs] (
  [cost_id] [int] IDENTITY,
  [work_id] [int] NOT NULL,
  [staff_id] [int] NOT NULL,
  CONSTRAINT [PK_Internal_Costs] PRIMARY KEY CLUSTERED ([cost_id])
)
ON [PRIMARY]
GO

GRANT
  ALTER,
  CONTROL,
  DELETE,
  INSERT,
  REFERENCES,
  SELECT,
  TAKE OWNERSHIP,
  UPDATE,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Internal_Costs] TO [Administrator]
GO

DENY
  ALTER,
  CONTROL,
  DELETE,
  INSERT,
  REFERENCES,
  SELECT
ON [dbo].[Internal_Costs] TO [User]
GO

DENY TAKE OWNERSHIP ON [dbo].[Internal_Costs] TO [User] CASCADE
GO

DENY
  UPDATE,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Internal_Costs] TO [User]
GO

ALTER TABLE [dbo].[Internal_Costs]
  ADD CONSTRAINT [FK_Internal_Costs] FOREIGN KEY ([work_id]) REFERENCES [dbo].[Maintanance] ([work_id])
GO

ALTER TABLE [dbo].[Internal_Costs]
  ADD CONSTRAINT [FK_Internal_Costs_Staff] FOREIGN KEY ([staff_id]) REFERENCES [dbo].[Staff] ([staff_id])
GO