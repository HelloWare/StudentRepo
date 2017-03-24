USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_InsertShoppingCartProduct]    Script Date: 3/23/2017 8:20:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	JIANPINGYIN
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_ECom_InsertShoppingCartProduct]
	-- Add the parameters for the stored procedure here
	@ShoppingCartId INT,
	@ProductId INT,
	@Quantity DECIMAL(12,2),
	@UnitPrice MONEY,
	@UnitOfMeasure DECIMAL(12,2),
	@SubTotal DECIMAL(12,2),
	@CreatedBy VARCHAR(25),
	@CreatedDate DATETIME,
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO [dbo].[ShoppingCartProduct] (ShoppingCartId, ProductId, Quantity, UnitPrice, UnitOfMeasure, SubTotal, CreatedBy, CreatedDate,LastModifiedBy,LastModifiedDate)
    VALUES  (@ShoppingCartId, @ProductId, @Quantity, @UnitPrice, @UnitOfMeasure, @SubTotal, @CreatedBy, @CreatedDate,@LastModifiedBy,@LastModifiedDate);
		-- Insert statements for procedure here
	RETURN SCOPE_IDENTITY();
END
