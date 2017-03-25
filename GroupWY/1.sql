USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_ECom_DeleteShoppingCart]    Script Date: 3/24/2017 1:26:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jianping Yin
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_ECom_DeleteShoppingCart] 
	-- Add the parameters for the stored procedure here
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DELETE FROM [dbo].[ShoppingCart]
	WHERE Id=@Id;
	RETURN SCOPE_IDENTITY();

    -- Insert statements for procedure here
END

GO

