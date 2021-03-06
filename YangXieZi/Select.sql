USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_CustomerOrder_Select]    Script Date: 2017/3/23 20:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_ECom_CustomerOrder_Select] 
	@Id INT	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 
    SELECT CustomerId, Status, GrandTotal, PaymentType, OrderDate, ShipToAddressId, OrderNumber, LastModifiedDate, CreatedDate, CreatedBy, LastModifiedBy
	FROM [dbo].[CustomerOrder]
	WHERE
	Id=@Id
	RETURN @@IDENTITY
END
