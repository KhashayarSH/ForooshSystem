USE [foroosh]
GO
/****** Object:  Table [dbo].[Userlog]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Userlog](
	[UserLogId] [int] IDENTITY(1,1) NOT NULL,
	[ComputerName] [varchar](150) NULL,
	[IPAddress] [varchar](30) NULL,
	[EnterDateTime] [varchar](50) NULL,
	[ExitDateTime] [varchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [Pk_UserLogID] PRIMARY KEY CLUSTERED 
(
	[UserLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Userlog]  WITH CHECK ADD  CONSTRAINT [FK_UserLog_UserID] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Userlog] CHECK CONSTRAINT [FK_UserLog_UserID]
GO
