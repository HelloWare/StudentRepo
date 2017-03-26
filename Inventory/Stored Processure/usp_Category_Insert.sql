USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Category_Insert]    Script Date: 2017/3/26 12:53:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Category_Insert]
	-- Add the parameters for the stored procedure here
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

    INSERT [dbo].[Category] (Name, Description, IsActive, Sequence, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
	VALUES (@Name, @Description, @IsActive, @Sequence, @CreatedBy, @CreatedDate, @LastModifiedBy, @LastModifiedDate)

	RETURN @@IDENTITY
END



GO

