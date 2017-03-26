USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Customer_Delete]    Script Date: 2017/3/26 12:53:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_Delete]
	@Id INT
AS
BEGIN
	
	SET NOCOUNT ON;

	 DELETE FROM [dbo].[Customer]
	 WHERE [Id] = @Id

	 RETURN @@IDENTITY
END


GO

