USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Product_GetByCategoryId]    Script Date: 2017/3/26 12:55:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Product_GetByCategoryId] 
	-- Add the parameters for the stored procedure here
	@CategoryId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Name, UnitPrice, StockQuantity, Description, Sequence, IsActive, Comment, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate, UnitOfMeasure, CategoryId, IconUrl, PictureUrl
	FROM [dbo].[Product]
	WHERE CategoryId = @CategoryId
END



GO

