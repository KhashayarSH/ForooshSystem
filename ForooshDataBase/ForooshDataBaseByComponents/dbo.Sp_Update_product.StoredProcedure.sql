USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_product]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_Update_product]
		
		@ProductId int,
		@ProductName varchar(150), 
		@ProductDesc varchar(1000),
		@ProductImage Image

As

	Update Product Set ProductName = @ProductName,
					   ProductDescription = @ProductDesc,
					   ProductImage = @ProductImage,
					   ProductActive = 1
	where ProductId = @ProductId


GO
