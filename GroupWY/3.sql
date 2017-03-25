USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_ECom_UpdateShoppingCart]    Script Date: 3/24/2017 1:27:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jianping Yin
-- Create date: 
-- Description:	
-- =============================================
Create PROCEDURE [dbo].[usp_ECom_UpdateShoppingCart]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@GrandTotal DECIMAL,
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [dbo].[ShoppingCart] 
	SET GrandTotal=@GrandTotal, LastModifiedBy=@LastModifiedBy, LastModifiedDate=@LastModifiedDate
    WHERE ID=@Id;
	-- Insert statements for procedure here
	RETURN @@IDENTITY;
END
GO

