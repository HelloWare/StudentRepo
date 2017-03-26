USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Product_GetByName]    Script Date: 2017/3/26 12:55:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Product_GetByName] 
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Id, CategoryId, Name, UnitPrice, StockQuantity, Description, UnitOfMeasure, IsActive, Sequence, IconUrl, PictureUrl, Comment, CreatedDate, CreatedBy, LastModifiedBy, LastModifiedDate
	FROM [dbo].[Product]
	WHERE Name = @Name
END

GO

