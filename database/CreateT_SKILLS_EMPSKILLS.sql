USE [SMF]
GO

/****** Object:  Table [dbo].[T_SKILLS_EMPSKILLS]    Script Date: 06/07/2012 16:48:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_SKILLS_EMPSKILLS](
	[sEmpID] [nchar](10) NOT NULL,
	[sSkillType] [nchar](20) NOT NULL,
	[sSkill] [nchar](50) NULL,
	[sLevel] [numeric](2) NULL,
	[sDateLastUsed] [datetime] NULL,	
	[sYrExperience] [numeric](2) NULL,
	[sDate]			[datetime] NULL,
	[sLastUpdateID] [nchar] (20) NULL,
	[sLastUpdate] [datetime] NULL
) ON [PRIMARY]

GO


