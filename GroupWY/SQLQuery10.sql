USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_UpdateShoppingCartProduct]    Script Date: 3/23/2017 8:21:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JIANPING YIN	
-- Create date: 20170311
-- Description:	UPDATE BY ID
-- =============================================
ALTER PROCEDURE [dbo].[usp_ECom_UpdateShoppingCartProduct]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@ShoppingCartId INT,
	@ProductId INT,
	@Quantity DECIMAL(12,2),
	@UnitPrice MONEY,
	@UnitOfMeasure DECIMAL(12,2),
	@SubTotal DECIMAL(12,2),
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [dbo].[ShoppingCartProduct] 
	SET ShoppingCartId=@ShoppingCartId, ProductId=@ProductId, Quantity=@Quantity, UnitPrice=@UnitPrice, UnitOfMeasure=@UnitOfMeasure, SubTotal=@SubTotal, LastModifiedBy=@LastModifiedBy, LastModifiedDate=@LastModifiedDate
    WHERE ID=@Id;
	-- Insert statements for procedure here
	RETURN @@IDENTITY;
END
