SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[get_transactions] @ID INT
AS
BEGIN
	SELECT transaction_id FROM dbo.user_transactions WHERE customer_id = @ID;
END
GO