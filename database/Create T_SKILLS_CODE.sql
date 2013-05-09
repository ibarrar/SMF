USE [SMF]
GO

/****** Object:  Table [dbo].[T_SKILLS_CODE]    Script Date: 06/07/2012 16:39:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE TABLE [dbo].[T_SKILLS_CODE](
	[sSkillType] [nchar](20) NULL,
	[sSkill] [nchar](50) NULL,
	[sPriority] [numeric] (4,0) NULL,
	[sLastUpdateID] [nchar] (10) NULL,
	[sLastUpdate] [datetime] NULL

) ON [PRIMARY]

GO


