USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Product_Insert]    Script Date: 2017/3/23 20:21:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Product_Insert]
	-- Add the parameters for the stored procedure here
	@Name VARCHAR(50),
	@UnitPrice DECIMAL,
	@StockQuantity DECIMAL,
	@Description VARCHAR(200),
	@Sequence INT,
	@IsActive BIT,
	@Comment VARCHAR(200),
	@CreatedBy VARCHAR(25),
	@CreatedDate DATETIME,
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME,
	@UnitOfMeasure VARCHAR(25),
	@CategoryId INT,
	@IconUrl VARCHAR(100),
	@PictureUrl VARCHAR(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT [dbo].[Product] (Name, UnitPrice, StockQuantity, Description, Sequence, IsActive, Comment, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate, UnitOfMeasure, CategoryId, IconUrl, PictureUrl)
	VALUES (@Name, @UnitPrice, @StockQuantity, @Description, @Sequence, @IsActive, @Comment, @CreatedBy, @CreatedDate, @LastModifiedBy, @LastModifiedDate, @UnitOfMeasure, @CategoryId, @IconUrl, @PictureUrl)

	RETURN @@IDENTITY
END


GO

