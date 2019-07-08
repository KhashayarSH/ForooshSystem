USE [foroosh]
GO
/****** Object:  Table [dbo].[DataHistory]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataHistory](
	[DataHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](100) NULL,
	[Id] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[ActionType] [varchar](20) NULL,
 CONSTRAINT [PK_DataHistoryID] PRIMARY KEY CLUSTERED 
(
	[DataHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
