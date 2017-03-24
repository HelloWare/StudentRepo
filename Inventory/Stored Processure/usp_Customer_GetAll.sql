USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Customer_GetAll]    Script Date: 2017/3/23 20:19:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_GetAll] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, UserName, FirstName, LastName, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate
	FROM [dbo].[Customer]
END

GO

