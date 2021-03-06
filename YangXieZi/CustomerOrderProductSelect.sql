USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_CustomerOrderProduct_Select]    Script Date: 2017/3/23 21:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ECom_CustomerOrderProduct_Select] 
	@Id INT	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 
    SELECT CustomerOrderId, ProductId, Quantity, UnitPrice, UnitPrice, Tax, UnitOfMeasure, LastModifiedDate, CreatedDate, CreatedBy, LastModifiedBy
	FROM [dbo].[CustomerOrderProduct]
	WHERE
	Id=@Id
	RETURN @@IDENTITY
END
