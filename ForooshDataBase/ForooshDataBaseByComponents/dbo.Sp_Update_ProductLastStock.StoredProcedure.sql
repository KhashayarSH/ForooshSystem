USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_ProductLastStock]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Update_ProductLastStock]

		@InventoryCount int,
		@productId int

as
 
 update Product set ProductLastSuply = ProductLastSuply + @InventoryCount

 where ProductId = @productId
GO
