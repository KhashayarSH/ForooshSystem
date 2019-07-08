USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_CustomerForooshChart]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_CustomerForooshChart]

as

select CustomerName,SUM(InvoicePrice) as TotalPrice from vw_invoice where InvoiceType =1 group by CustomerName
GO
