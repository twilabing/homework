USE [CE_Web]
GO

/****** Object:  Table [mvc].[classMaster]    Script Date: 5/3/2017 12:06:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [mvc].[classMaster](
	[classID] [int] IDENTITY(1,1) NOT NULL,
	[className] [varchar](100) NOT NULL,
	[classDescription] [varchar](200) NOT NULL,
	[classPrice] [smallmoney] NOT NULL,
	[classSessions] [int] NOT NULL,
 CONSTRAINT [pk_mvcclassmaster_classID] PRIMARY KEY CLUSTERED 
(
	[classID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [CE_Web]
GO

/****** Object:  Table [mvc].[userClasses]    Script Date: 5/3/2017 12:06:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [mvc].[userClasses](
	[userID] [int] NOT NULL,
	[classID] [int] NOT NULL,
 CONSTRAINT [pk_userClasses_composite] PRIMARY KEY CLUSTERED 
(
	[userID] ASC,
	[classID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [mvc].[userClasses]  WITH CHECK ADD  CONSTRAINT [fk_userClasses_classID] FOREIGN KEY([classID])
REFERENCES [mvc].[classMaster] ([classID])
GO

ALTER TABLE [mvc].[userClasses] CHECK CONSTRAINT [fk_userClasses_classID]
GO

ALTER TABLE [mvc].[userClasses]  WITH CHECK ADD  CONSTRAINT [fk_userClasses_userID] FOREIGN KEY([userID])
REFERENCES [mvc].[users] ([userID])
GO

ALTER TABLE [mvc].[userClasses] CHECK CONSTRAINT [fk_userClasses_userID]
GO


USE [CE_Web]
GO

/****** Object:  Table [mvc].[users]    Script Date: 5/3/2017 12:07:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [mvc].[users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](100) NOT NULL,
	[userPassword] [varchar](100) NOT NULL,
 CONSTRAINT [pk_mvcusers_userid] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [CE_Web]
GO

/****** Object:  StoredProcedure [mvc].[RetrieveClassesForStudent]    Script Date: 5/3/2017 12:07:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [mvc].[RetrieveClassesForStudent]
@userId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select uc.userID, userName,className, classDescription,classPrice, classSessions
	from UserClasses uc
	LEFT JOIN mvc.classMaster cm ON uc.classID = cm.classID
	LEFT JOIN mvc.users u on u.userID = uc.userID
	where uc.UserId = @UserId
END



GO


USE [CE_Web]
GO

/****** Object:  StoredProcedure [mvc].[SaveEnrollment]    Script Date: 5/3/2017 12:07:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [mvc].[SaveEnrollment]
@userId int,
@classID int
AS
BEGIN
INSERT INTO MVC.userClasses 
(userID, classID)
VALUES
(@userID,@classID)
END




GO


