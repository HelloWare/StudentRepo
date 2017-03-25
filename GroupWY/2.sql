USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_ECom_InsertShoppingCart]    Script Date: 3/24/2017 1:26:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Zhe,,Wang>
-- Create date: <3/12/2017,,>
-- Description:	<CustomerOrder Delete,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ECom_InsertShoppingCart]
	-- Add the parameters for the stored procedure here
	@CustomerId INT,
	@GrandTotal DECIMAL,
	@CreatedBy VARCHAR(25),
	@CreatedDate DATETIME,
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO [dbo].[ShoppingCart] (CustomerId, GrandTotal, CreatedBy, CreatedDate,LastModifiedBy,LastModifiedDate)
    VALUES  (@CustomerId, @GrandTotal, @CreatedBy, @CreatedDate,@LastModifiedBy,@LastModifiedDate);
		-- Insert statements for procedure here
	RETURN SCOPE_IDENTITY();
END

GO

