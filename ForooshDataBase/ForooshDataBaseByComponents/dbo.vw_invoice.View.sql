USE [foroosh]
GO
/****** Object:  View [dbo].[vw_invoice]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_invoice]
AS
SELECT dbo.Invoice.InvoiceId, dbo.Invoice.InvoiceDate, dbo.Invoice.InvoicePrice, dbo.Invoice.InvoiceDescription, dbo.Invoice.CustomerId, dbo.Invoice.Userid, dbo.Invoice.InvoicePrice_purch, dbo.Users.UserName, dbo.Users.UserFamily, 
                  dbo.Customer.CustomerName, dbo.Customer.CustomerTell, dbo.Users.UserName + ' ' + dbo.Users.UserFamily AS FullName, dbo.Customer.CustomerAddress, dbo.Invoice.InvoiceType,
                      (SELECT CASE WHEN InvoiceType = 1 THEN 'فروش' WHEN InvoiceType = 2 THEN 'مرجوعی' END AS Expr1) AS InvoiceTypeFarsi
FROM     dbo.Invoice INNER JOIN
                  dbo.Customer ON dbo.Invoice.CustomerId = dbo.Customer.CustomerID INNER JOIN
                  dbo.Users ON dbo.Invoice.Userid = dbo.Users.UserID

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[49] 4[3] 2[3] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4[30] 2[40] 3) )"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2[66] 3) )"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4[50] 3) )"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1[75] 4) )"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2) )"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Invoice"
            Begin Extent = 
               Top = 5
               Left = 499
               Bottom = 315
               Right = 717
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Customer"
            Begin Extent = 
               Top = 215
               Left = 160
               Bottom = 378
               Right = 371
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 213
               Left = 836
               Bottom = 376
               Right = 1030
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 15
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_invoice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_invoice'
GO
