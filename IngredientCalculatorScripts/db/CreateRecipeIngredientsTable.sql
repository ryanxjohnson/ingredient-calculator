USE [IngredientCalculator]
GO

/****** Object:  Table [dbo].[RecipeIngredients]    Script Date: 6/29/2018 10:02:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RecipeIngredients](
	[RecipeId] [int] NULL,
	[IngredientId] [int] NULL,
	[IngredientAmount] [float] NULL,
	[IngredientUnitId] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Ingredients] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([Id])
GO

ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Ingredients]
GO

ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO

ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Recipes]
GO

ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Units] FOREIGN KEY([IngredientUnitId])
REFERENCES [dbo].[Units] ([Id])
GO

ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Units]
GO


