USE [foroosh]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserFamily] [varchar](100) NULL,
	[UserTel] [varchar](11) NULL,
	[UserUserName] [varchar](50) NULL,
	[UserPassword] [varchar](128) NULL,
	[UserAge] [tinyint] NULL,
	[UserGender] [tinyint] NULL,
	[UserActive] [tinyint] NULL,
	[UserStartDate] [varchar](20) NULL,
 CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
