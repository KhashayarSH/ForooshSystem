USE [foroosh]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_ExitDate]    Script Date: 7/8/2019 10:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Update_ExitDate]
	@UserId int,
	@ExitDate varchar (50)
	As
with Update_Userlog As(	
	select top 1 * from userlog where userid = @userId And exitdatetime is null  order by enterdatetime desc 
	)
update Update_UserLog set exitdatetime = @ExitDate 

GO
