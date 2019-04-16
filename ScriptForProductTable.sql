USE [Djole]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 4/6/2019 4:12:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[Manufacturer] [nvarchar](max) NULL,
	[Suplier] [nvarchar](max) NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


