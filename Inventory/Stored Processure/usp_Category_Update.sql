USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Category_Update]    Script Date: 2017/3/26 12:53:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Category_Update] 
	-- Add the parameters for the stored procedure here
	@Id INT,
	@Name VARCHAR(50),
	@Description VARCHAR(200),
	@IsActive BIT,
	@Sequence INT,
	@CreatedBy VARCHAR(25),
	@CreatedDate DATETIME,
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Category]
	SET  Name = @Name, Description = @Description, IsActive = @IsActive, Sequence = @Sequence, CreatedBy = @CreatedBy, CreatedDate = @CreatedDate, LastModifiedBy = @LastModifiedBy, LastModifiedDate = @LastModifiedDate
	WHERE Id = @Id
END



GO

