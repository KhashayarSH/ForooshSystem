USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Foroosh_Chart]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Foroosh_Chart] 
as

select top 3 sum( InvoicePrice) as TotalPrice,InvoiceDate from vw_invoice where invoicetype=1 group by invoicedate order by InvoiceDate desc
GO
