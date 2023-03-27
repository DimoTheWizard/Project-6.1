CREATE TABLE [dbo].[Customer] (
  [customer_id] [int] IDENTITY,
  [iban] [int] NOT NULL,
  CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([customer_id])
)
ON [PRIMARY]
GO

GRANT
  CONTROL,
  REFERENCES,
  TAKE OWNERSHIP,
  UPDATE,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Customer] TO [Administrator]
GO

GRANT
  ALTER,
  DELETE,
  INSERT,
  SELECT
ON [dbo].[Customer] TO [Administrator] WITH GRANT OPTION
GO

GRANT DELETE ON [dbo].[Customer] TO [User]
GO

DENY
  ALTER,
  CONTROL,
  REFERENCES,
  SELECT
ON [dbo].[Customer] TO [User]
GO

DENY TAKE OWNERSHIP ON [dbo].[Customer] TO [User] CASCADE
GO

DENY
  UPDATE,
  VIEW CHANGE TRACKING,
  VIEW DEFINITION
ON [dbo].[Customer] TO [User]
GO