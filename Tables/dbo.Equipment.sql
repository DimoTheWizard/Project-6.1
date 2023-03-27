CREATE TABLE [dbo].[Equipment] (
  [equipment_id] [int] IDENTITY,
  [equipment_name] [nvarchar](100) NOT NULL,
  [staff_id] [int] NOT NULL,
  CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED ([equipment_id])
)
ON [PRIMARY]
GO

GRANT
  CONTROL,
  REFERENCES,
  TAKE OWNERSHIP,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Equipment] TO [Administrator]
GO

GRANT
  ALTER,
  DELETE,
  INSERT,
  SELECT,
  UPDATE
ON [dbo].[Equipment] TO [Administrator] WITH GRANT OPTION
GO

DENY
  ALTER,
  CONTROL,
  DELETE,
  INSERT,
  REFERENCES,
  SELECT
ON [dbo].[Equipment] TO [User]
GO

DENY TAKE OWNERSHIP ON [dbo].[Equipment] TO [User] CASCADE
GO

DENY
  UPDATE,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Equipment] TO [User]
GO

ALTER TABLE [dbo].[Equipment]
  ADD CONSTRAINT [FK_Equipment] FOREIGN KEY ([staff_id]) REFERENCES [dbo].[Staff] ([staff_id])
GO