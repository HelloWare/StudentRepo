USE [ECom]
GO

/****** Object:  StoredProcedure [dbo].[usp_Customer_Insert]    Script Date: 2017/3/23 20:19:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Shawn Shi
-- Create date: 02/09/2017
-- Description:	Insert a row into Customer
-- =============================================
CREATE PROCEDURE [dbo].[usp_Customer_Insert]
	@UserName VARCHAR(25),
	@FirstName VARCHAR(25),
	@LastName VARCHAR(25),
	@CreatedBy VARCHAR(25),
	@CreatedDate DATETIME,
	@LastModifiedBy VARCHAR(25),
	@LastModifiedDate DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	INSERT [dbo].[Customer] (UserName, FirstName, LastName, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
	VALUES (@UserName, @FirstName, @LastName, @CreatedBy, @CreatedDate, @LastModifiedBy, @LastModifiedDate)

	RETURN @@IDENTITY
   
END

GO
