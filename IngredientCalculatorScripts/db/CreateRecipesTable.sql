USE [IngredientCalculator]
GO

/****** Object:  Table [dbo].[Recipes]    Script Date: 6/29/2018 10:02:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Recipes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeName] [varchar](50) NULL,
	[Servings] [int] NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


