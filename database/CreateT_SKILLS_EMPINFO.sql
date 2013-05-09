USE [SMF]
GO

/****** Object:  Table [dbo].[T_SKILLS_EMPINFO]    Script Date: 06/05/2012 09:27:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_SKILLS_EMPINFO](
	[sLoginID] [nchar](7) NOT NULL,
	[sEmpID] [numeric](6,0) NOT NULL,
	[sEmpPswd] [nchar](100) NOT NULL,
	[sLastName] [nchar](125) NOT NULL,
	[sFirstName] [nchar](125) NOT NULL,
	[sEmpPosition] [nchar](256) NULL,
	[sSubTeam] [nchar](25) NULL,
	[sNavYYYY] [numeric](4,0) NULL,
	[sNavMMM] [nchar](3) NULL,
	[sNavDD] [numeric](2) NULL,
	[sNickName] [nchar](10) NULL,	
	[sGender] [nchar](1) NULL,	
	[sUGSchool] [nchar](25) NULL,	
	[sUGDegree] [nchar](25) NULL,
	[sUGYear] [numeric](4,0) NULL,	
	[sGSchool] [nchar](125) NULL,
	[sGSDegree] [nchar](256) NULL,
	[sGSYear] [numeric](4,0) NULL,	
	[sPassportNo] [nchar](15) NULL,
	[sPassportExp] [nchar](15) NULL,	
	[sValidVisa] [nchar] (20) NULL,	
	[sBdayYYYY] [numeric](4,0) NULL,
	[sBdayMMM] [nchar](3) NULL,
	[sBdayDD] [numeric](2,0) NULL,	
	[sCellNo] [nchar](15) NULL,
	[sHomeTel] [nchar](15) NULL,
	[sOtherEmail] [nchar](100) NULL,	
	[sAddressStreet] [nchar](125) NULL,
	[sAddressCity] [nchar](125) NULL,	
	[sEmpStat] [nchar](20) NULL,	
	[sEmpPermission] [nchar](10) NULL,
	[sOfc] [nchar](3) NULL,
	[sAddTechSkills] [nchar](125) NULL,
	[sAddProdKnowledge] [nchar](125) NULL,
	[sLastUpdateID] [nchar](10) NULL,
	[sLastUpdate] [datetime] NULL,

) ON [PRIMARY]

GO


