USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Customer_Update]    Script Date: 2017/3/26 12:54:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_Update] 
	-- Add the parameters for the stored procedure here
	@Id INT,
	@UserName VARCHAR(25),
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@CreatedBy VARCHAR(25),
	@CreatedDate DATETIME,
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Customer] 
	SET  UserName = @UserName, FirstName = @FirstName, LastName = @LastName, CreatedBy = @CreatedBy, CreatedDate = @CreatedDate, LastModifiedBy = @LastModifiedBy, LastModifiedDate = @LastModifiedDate
	WHERE Id = @Id
END


GO

