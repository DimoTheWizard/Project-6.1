CREATE TABLE [dbo].[Beverage] (
  [beverage_id] [int] IDENTITY,
  [beverage_name] [nvarchar](50) NOT NULL,
  CONSTRAINT [PK_Beverage] PRIMARY KEY CLUSTERED ([beverage_id])
)
ON [PRIMARY]
GO

GRANT
  CONTROL,
  REFERENCES,
  TAKE OWNERSHIP,
  VIEW DEFINITION
ON [dbo].[Beverage] TO [Administrator]
GO

GRANT
  ALTER,
  DELETE,
  INSERT,
  SELECT,
  UPDATE,
  VIEW CHANGE TRACKING
ON [dbo].[Beverage] TO [Administrator] WITH GRANT OPTION
GO

GRANT SELECT ON [dbo].[Beverage] TO [User]
GO

DENY
  ALTER,
  CONTROL,
  DELETE,
  INSERT,
  REFERENCES
ON [dbo].[Beverage] TO [User]
GO

DENY TAKE OWNERSHIP ON [dbo].[Beverage] TO [User] CASCADE
GO

DENY
  UPDATE,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Beverage] TO [User]
GO