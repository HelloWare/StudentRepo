USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_GetShoppingCartProduct]    Script Date: 3/23/2017 8:20:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JIANPING YIN	
-- Create date: 03-11-2017
-- Description:	get a row for [dbo].[ShoppingCartProduct] by Id
-- =============================================
ALTER PROCEDURE [dbo].[usp_ECom_GetShoppingCartProduct]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT Id,ShoppingCartId, ProductId, Quantity, UnitPrice, UnitOfMeasure, SubTotal, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate FROM [dbo].[ShoppingCartProduct]
	WHERE Id=@Id;
    -- Insert statements for procedure here
END
