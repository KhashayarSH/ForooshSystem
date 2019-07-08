USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateFee_Product]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_UpdateFee_Product]

		@ProductId int,
		@ProductLastFee bigint,
		@ProductLastPurchFee bigint

		As

update Product
set	ProductLastFee = @ProductLastFee, LastPurchFee=@ProductLastPurchFee
where ProductId =@ProductId

GO
