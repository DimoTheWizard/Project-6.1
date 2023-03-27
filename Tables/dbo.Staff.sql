CREATE TABLE [dbo].[Staff] (
  [staff_id] [int] IDENTITY,
  [staff_name] [nvarchar](70) NOT NULL,
  [time] [datetime] NULL,
  CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([staff_id])
)
ON [PRIMARY]
GO

GRANT
  CONTROL,
  REFERENCES,
  TAKE OWNERSHIP,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Staff] TO [Administrator]
GO

GRANT
  ALTER,
  DELETE,
  INSERT,
  SELECT,
  UPDATE
ON [dbo].[Staff] TO [Administrator] WITH GRANT OPTION
GO

DENY
  ALTER,
  CONTROL,
  DELETE,
  INSERT,
  REFERENCES,
  SELECT
ON [dbo].[Staff] TO [User]
GO

DENY TAKE OWNERSHIP ON [dbo].[Staff] TO [User] CASCADE
GO

DENY
  UPDATE,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Staff] TO [User]
GO