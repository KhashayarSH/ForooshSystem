USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_product2]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Sp_Update_product2]
		
		@ProductId int,
		@ProductName varchar(150), 
		@ProductDesc varchar(1000)
	

As

	Update Product Set ProductName = @ProductName,
					   ProductDescription = @ProductDesc
					 

	where ProductId = @ProductId

GO
