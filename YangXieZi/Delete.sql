USE [ECom]
GO
/****** Object:  StoredProcedure [dbo].[usp_ECom_CustomerOrder_Delete]    Script Date: 2017/3/23 20:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Zhe,,Wang>
-- Create date: <3/12/2017,,>
-- Description:	<CustomerOrder Delete,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_ECom_CustomerOrder_Delete] 
  @Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DELETE [dbo].[CustomerOrder]
	WHERE Id = @Id

	RETURN @@ROWCOUNT
END
