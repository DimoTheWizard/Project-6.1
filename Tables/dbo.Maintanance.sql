CREATE TABLE [dbo].[Maintanance] (
  [work_id] [int] IDENTITY,
  [type_of_work] [nvarchar](50) NOT NULL,
  [duration] [datetime] NOT NULL,
  [staff_id] [int] NOT NULL,
  CONSTRAINT [PK_Maintanance] PRIMARY KEY CLUSTERED ([work_id])
)
ON [PRIMARY]
GO

GRANT
  ALTER,
  CONTROL,
  REFERENCES,
  TAKE OWNERSHIP,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Maintanance] TO [Administrator]
GO

GRANT
  DELETE,
  INSERT,
  SELECT,
  UPDATE
ON [dbo].[Maintanance] TO [Administrator] WITH GRANT OPTION
GO

DENY
  ALTER,
  CONTROL,
  DELETE,
  INSERT,
  REFERENCES,
  SELECT
ON [dbo].[Maintanance] TO [User]
GO

DENY TAKE OWNERSHIP ON [dbo].[Maintanance] TO [User] CASCADE
GO

DENY
  UPDATE,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Maintanance] TO [User]
GO

ALTER TABLE [dbo].[Maintanance]
  ADD CONSTRAINT [FK_Maintanance_Staff] FOREIGN KEY ([staff_id]) REFERENCES [dbo].[Staff] ([staff_id])
GO