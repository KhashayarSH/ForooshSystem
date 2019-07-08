USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ins_product]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_ins_product]

		@ProductName varchar(50),
		@ProductDesc text,
		@ProductImage image,
		@ProductStartDate varchar(20),
		@UserId int

As

		Insert Into Product
			(ProductName, ProductDescription, ProductLastFee, ProductLastSuply, ProductImage, ProductStartDate, UserId, ProductActive)
values
			(@ProductName,@ProductDesc,0,0,@ProductImage,@ProductStartDate,@UserId,1)
GO
