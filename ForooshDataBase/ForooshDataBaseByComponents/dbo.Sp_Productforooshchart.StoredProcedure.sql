USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Productforooshchart]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Productforooshchart]
as

select II.ProductName,sum(II.InvoiceItemCount * II.InvoiceItemFeeSell ) as TotalPrice  from Vw_InvoiceItem II join vw_invoice I on II.Invoiceid = I.InvoiceId where I.InvoiceType =1 


group by II.ProductName
GO
