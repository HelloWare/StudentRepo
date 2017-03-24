USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Product_GetAll]    Script Date: 2017/3/23 20:20:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Product_GetAll] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Id, Name, UnitPrice, StockQuantity, Description, Sequence, IsActive, Comment, CreateBy, CreateDate, LastModifiedBy, LastModifiedDate, UnitOfMeasure, CategoryId, IconUrl, PictureUrl
	FROM [dbo].[Product]
END


GO

