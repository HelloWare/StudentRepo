USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Customer_Delete]    Script Date: 2017/3/23 20:19:10 ******/
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
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	 DELETE FROM [dbo].[Customer]
	 WHERE [Id] = @Id

	 RETURN @@IDENTITY
END

GO

