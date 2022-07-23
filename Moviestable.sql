USE [test1]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 07/23/2022 21:14:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies](
	[MovieId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[DateOfRelease] [datetime2](7) NOT NULL,
	[ActorId] [int] NOT NULL,
	[ProducerId] [int] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeleteFlag] [bit] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Actor_ActorId] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([ActorId])
GO

ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Actor_ActorId]
GO

ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Producer_ProducerId] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producer] ([ProducerId])
GO

ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Producer_ProducerId]
GO


