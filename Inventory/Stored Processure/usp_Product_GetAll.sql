USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Product_GetAll]    Script Date: 2017/3/26 12:55:15 ******/
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

    SELECT Id, CategoryId, Name, UnitPrice, StockQuantity, Description, UnitOfMeasure, IsActive, Sequence, IconUrl, PictureUrl, Comment, CreatedDate, CreatedBy, LastModifiedBy, LastModifiedDate
	FROM [dbo].[Product]
END



GO

