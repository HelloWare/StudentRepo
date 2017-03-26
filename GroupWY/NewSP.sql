USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_ECom_SelectByCustomerIdShoppingCart]    Script Date: 3/26/2017 12:45:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jianping Yin
-- Create date: 
-- Description:	
-- =============================================
Create PROCEDURE [dbo].[usp_ECom_SelectByCustomerIdShoppingCart]
	-- Add the parameters for the stored procedure here
	@CustomerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT Id, CustomerId, GrandTotal, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate FROM [dbo].[ShoppingCart]
	WHERE CustomerId=@CustomerId;
    -- Insert statements for procedure here
END

GO

