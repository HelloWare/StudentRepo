USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_DeleteShoppingCartProduct]    Script Date: 3/23/2017 8:18:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jianping Yin
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_ECom_DeleteShoppingCartProduct] 
	-- Add the parameters for the stored procedure here
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DELETE FROM [dbo].[ShoppingCartProduct]
	WHERE Id=@Id;
	RETURN SCOPE_IDENTITY();

    -- Insert statements for procedure here
END
