USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Product_Insert]    Script Date: 2017/3/26 12:56:01 ******/
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
	@CategoryId INT,
	@Name VARCHAR(50),
	@UnitPrice DECIMAL,
	@StockQuantity DECIMAL,
	@Description VARCHAR(200),
	@UnitOfMeasure VARCHAR(25),
	@IsActive BIT,
	@Sequence INT,
	@IconUrl VARCHAR(100),
	@PictureUrl VARCHAR(100),
	@Comment VARCHAR(200),
	@CreatedDate DATETIME,
	@CreatedBy VARCHAR(25),
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT [dbo].[Product] (CategoryId, Name, UnitPrice, StockQuantity, Description, UnitOfMeasure, IsActive, Sequence, IconUrl, PictureUrl, Comment, CreatedDate, CreatedBy, LastModifiedBy, LastModifiedDate )
	VALUES (@CategoryId, @Name, @UnitPrice, @StockQuantity, @Description, @UnitOfMeasure, @IsActive, @Sequence, @IconUrl, @PictureUrl, @Comment, @CreatedDate, @CreatedBy, @LastModifiedBy, @LastModifiedDate)

	RETURN @@IDENTITY
END



GO

