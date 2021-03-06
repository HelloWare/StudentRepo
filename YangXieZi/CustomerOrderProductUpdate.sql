USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_CustomerOrderProduct_Update]    Script Date: 2017/3/23 21:37:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JIANPING YIN	
-- Create date: 20170311
-- Description:	UPDATE BY ID
-- =============================================
CREATE PROCEDURE [dbo].[usp_ECom_CustomerOrderProduct_Update]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@CustomerOrderId INT,
	@ProductId INT,
	@Quantity DECIMAL(12,2),
	@UnitPrice DECIMAL(12,2),
	@Tax DECIMAL(12,2),
	@UnitOfMeasure VARCHAR(25),
	@CreatedBy VARCHAR(25),
	@CreatedDate DATETIME,
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [dbo].[CustomerOrderProduct] 
	SET @CustomerOrderId=@CustomerOrderId, ProductId=@ProductId, Quantity=@Quantity, UnitPrice=@UnitPrice, Tax=@Tax,@UnitOfMeasure=@UnitOfMeasure, CreatedBy=@CreatedBy, CreatedDate=@CreatedDate, LastModifiedBy=@LastModifiedBy, LastModifiedDate=@LastModifiedDate
    WHERE Id=@Id;
	-- Insert statements for procedure here
	RETURN @@IDENTITY;
END
