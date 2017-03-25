USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_ECom_SelectAllShoppingCart]    Script Date: 3/24/2017 1:27:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jianping Yin
-- Create date: 
-- Description:	
-- =============================================
Create  PROCEDURE [dbo].[usp_ECom_SelectAllShoppingCart]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[ShoppingCartProduct];
    -- Insert statements for procedure here
END

GO

