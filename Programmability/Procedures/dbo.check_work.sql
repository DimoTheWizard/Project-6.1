SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[check_work] 
@Employee NVARCHAR(50)
AS
BEGIN
	SELECT staff_name FROM	internal_work WHERE	staff_name = @Employee
END
GO