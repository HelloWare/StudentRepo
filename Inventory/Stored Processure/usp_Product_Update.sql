USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Product_Update]    Script Date: 2017/3/26 12:56:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Product_Update]
	-- Add the parameters for the stored procedure here
	@Id INT,
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

    UPDATE [dbo].[Product]
	SET  Name = @Name, UnitPrice = @UnitPrice, StockQuantity = @StockQuantity, Description = @Description, Sequence = @Sequence, IsActive = @IsActive, Comment = @Comment, UnitOfMeasure = @UnitOfMeasure, CategoryId = @CategoryId, IconUrl = @IconUrl, PictureUrl = @PictureUrl, CreatedBy = @CreatedBy, CreatedDate = @CreatedDate, LastModifiedBy = @LastModifiedBy, LastModifiedDate = @LastModifiedDate
	WHERE Id = @Id
END



GO

