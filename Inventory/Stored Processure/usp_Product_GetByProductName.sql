USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Product_GetByProductName]    Script Date: 2017/3/23 20:21:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Product_GetByProductName] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Id, Name, UnitPrice, StockQuantity, Description, Sequence, IsActive, Comment, CreateBy, CreateDate, LastModifiedBy, LastModifiedDate, UnitOfMeasure, CategoryId, IconUrl, PictureUrl
	FROM [dbo].[Product]
	WHERE Name = @Name
END

GO

