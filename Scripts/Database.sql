USE [ArticleApp]
GO
/****** Object:  Table [dbo].[ArticleComments]    Script Date: 19.01.2020 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleComments](
	[ArticleCommentId] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[AuthorFullName] [nvarchar](50) NOT NULL,
	[AuthorEmail] [nvarchar](100) NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsApproved] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleCommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 19.01.2020 22:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Summary] [nvarchar](1000) NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Thumbnail] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
