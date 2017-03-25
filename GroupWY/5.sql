USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_ECom_SelectByIdShoppingCart]    Script Date: 3/24/2017 1:27:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jianping Yin
-- Create date: 
-- Description:	
-- =============================================
Create PROCEDURE [dbo].[usp_ECom_SelectByIdShoppingCart]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT Id, CustomerId, GrandTotal, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate FROM [dbo].[ShoppingCart]
	WHERE Id=@Id;
    -- Insert statements for procedure here
END

GO

