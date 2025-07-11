USE [IMS_DB]
GO
/****** Object:  Table [dbo].[OsSections]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OsSections](
	[SectionId] [int] IDENTITY(1,1) NOT NULL,
	[Section] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_OsSections] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OsSections] ON 

INSERT [dbo].[OsSections] ([SectionId], [Section], [Description], [IsActive]) VALUES (1, N'Statement', N'StatementRelated', 1)
SET IDENTITY_INSERT [dbo].[OsSections] OFF
GO
