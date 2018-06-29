USE [IngredientCalculator]
GO

/****** Object:  Table [dbo].[Units]    Script Date: 6/29/2018 10:02:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Units](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [varchar](50) NULL,
	[UnitAbbreviation] [varchar](50) NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


