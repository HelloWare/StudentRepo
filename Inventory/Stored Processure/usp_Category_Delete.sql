USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Category_Delete]    Script Date: 2017/3/23 20:18:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Category_Delete] 
	-- Add the parameters for the stored procedure here
	@Id INT
AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Category]
	 WHERE [Id] = @Id
END


GO

