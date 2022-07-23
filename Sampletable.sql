USE [test1]
GO

/****** Object:  Table [dbo].[Sample]    Script Date: 07/23/2022 21:16:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sample](
	[Id] [int] NOT NULL,
	[ActorId] [int] NOT NULL,
	[ProducerId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[MoviesMovieId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime2](7) NULL,
	[DeleteFlag] [bit] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Sample] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sample]  WITH CHECK ADD  CONSTRAINT [FK_Sample_Actor_ActorId] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([ActorId])
GO

ALTER TABLE [dbo].[Sample] CHECK CONSTRAINT [FK_Sample_Actor_ActorId]
GO

ALTER TABLE [dbo].[Sample]  WITH CHECK ADD  CONSTRAINT [FK_Sample_Movies_MoviesMovieId] FOREIGN KEY([MoviesMovieId])
REFERENCES [dbo].[Movies] ([MovieId])
GO

ALTER TABLE [dbo].[Sample] CHECK CONSTRAINT [FK_Sample_Movies_MoviesMovieId]
GO

ALTER TABLE [dbo].[Sample]  WITH CHECK ADD  CONSTRAINT [FK_Sample_Producer_ProducerId] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producer] ([ProducerId])
GO

ALTER TABLE [dbo].[Sample] CHECK CONSTRAINT [FK_Sample_Producer_ProducerId]
GO


