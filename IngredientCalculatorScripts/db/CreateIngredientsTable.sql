USE [IngredientCalculator]
GO

/****** Object:  Table [dbo].[Ingredients]    Script Date: 6/29/2018 10:01:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ingredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IngredientName] [varchar](50) NULL,
	[TotalPackageCost] [money] NULL,
	[TotalPackageVolume] [float] NULL,
	[TotalPackageVolumeUnitId] [int] NULL,
	[CostPerUnit] [money] NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_Ingredients_Ingredients] FOREIGN KEY([Id])
REFERENCES [dbo].[Ingredients] ([Id])
GO

ALTER TABLE [dbo].[Ingredients] CHECK CONSTRAINT [FK_Ingredients_Ingredients]
GO

ALTER TABLE [dbo].[Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_Ingredients_Units] FOREIGN KEY([TotalPackageVolumeUnitId])
REFERENCES [dbo].[Units] ([Id])
GO

ALTER TABLE [dbo].[Ingredients] CHECK CONSTRAINT [FK_Ingredients_Units]
GO


