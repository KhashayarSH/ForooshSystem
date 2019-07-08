USE [foroosh]
GO
/****** Object:  Table [dbo].[InvoiceItem]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceItem](
	[InvoiceItemId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceItemCount] [int] NULL,
	[Productid] [int] NULL,
	[InvoiceItemFeeSell] [bigint] NULL,
	[InvoiceItemPurchFee] [bigint] NULL,
	[Invoiceid] [int] NULL,
 CONSTRAINT [pk_invoice_item_id] PRIMARY KEY CLUSTERED 
(
	[InvoiceItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[InvoiceItem]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceID_invoiceitem] FOREIGN KEY([Invoiceid])
REFERENCES [dbo].[Invoice] ([InvoiceId])
GO
ALTER TABLE [dbo].[InvoiceItem] CHECK CONSTRAINT [FK_InvoiceID_invoiceitem]
GO
ALTER TABLE [dbo].[InvoiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ProuctID_invoiceitem] FOREIGN KEY([Productid])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[InvoiceItem] CHECK CONSTRAINT [FK_ProuctID_invoiceitem]
GO
