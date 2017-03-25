USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Customer_GetByName]    Script Date: 2017/3/25 16:29:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_GetByName]
	-- Add the parameters for the stored procedure here
	@UserName VARCHAR(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Id, UserName, FirstName, LastName, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate
	FROM [dbo].[Customer]
	WHERE UserName = @UserName
END

GO

