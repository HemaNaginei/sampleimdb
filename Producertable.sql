USE [test1]
GO

/****** Object:  Table [dbo].[Producer]    Script Date: 07/23/2022 21:16:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Producer](
	[ProducerId] [int] NOT NULL,
	[ProducerName] [nvarchar](max) NOT NULL,
	[Bio] [nvarchar](max) NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Company] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeleteFlag] [bit] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED 
(
	[ProducerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


