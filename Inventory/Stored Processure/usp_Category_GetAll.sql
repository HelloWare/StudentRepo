USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Category_GetAll]    Script Date: 2017/3/23 20:18:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Category_GetAll] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT Id, Name, Description, IsActive, Sequence, CreateBy, CreateDate, LastModifiedBy, LastModifiedDate
	FROM [dbo].[Category]
END


GO

