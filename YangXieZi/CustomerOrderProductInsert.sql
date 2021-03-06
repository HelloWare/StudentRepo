USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_CustomerOrderProduct_Insert]    Script Date: 2017/3/23 21:35:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Zhe,,Wang>
-- Create date: <3/12/2017,,>
-- Description:	<CustomerOrder Insert,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ECom_CustomerOrderProduct_Insert]
	@CustomerOrderId INT,
	@ProductId INT,
	@Quantity DECIMAL(12,2),
	@UnitPrice DECIMAL(12,2),
	@Tax DECIMAL(12,2),
	@UnitOfMeasure VARCHAR(25),
	@LastModifiedDate DATETIME,
	@CreatedDate DATETIME,
	@CreatedBy VARCHAR(25),
	@LastModifiedBy VARCHAR(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[CustomerOrderProduct] (CustomerOrderId, ProductId, Quantity, UnitPrice, Tax, UnitOfMeasure, LastModifiedDate, CreatedDate, CreatedBy, LastModifiedBy)
	VALUES (@CustomerOrderId, @ProductId, @Quantity, @UnitPrice, @Tax, @UnitOfMeasure, @LastModifiedDate, @CreatedDate, @CreatedBy, @LastModifiedBy)

	RETURN @@IDENTITY
END
