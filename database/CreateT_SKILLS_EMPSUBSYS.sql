USE [SMF]
GO

/****** Object:  Table [dbo].[T_SKILLS_EMPSUBSYS]    Script Date: 06/07/2012 17:38:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_SKILLS_EMPSUBSYS](
	[sEMPID] [numeric](10, 0) NULL,
	[sSkillType] [nchar](20) NULL,
	[sSkill] [nchar](50) NULL,
	[sLastUpdateID] [nchar](10) NULL,
	[sLastUpdate] [datetime] NULL
) ON [PRIMARY]

GO


