USE [IMS_DB]
GO
/****** Object:  Table [dbo].[OsStatuss]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OsStatuss](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_OsStatuss] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OsStatuss] ON 

INSERT [dbo].[OsStatuss] ([StatusId], [SectionId], [Status], [Description], [IsActive]) VALUES (10, 1, N'Pending', NULL, 1)
INSERT [dbo].[OsStatuss] ([StatusId], [SectionId], [Status], [Description], [IsActive]) VALUES (11, 1, N'Paid', NULL, 1)
SET IDENTITY_INSERT [dbo].[OsStatuss] OFF
GO
/****** Object:  Index [IX_OsStatuss_SectionId]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_OsStatuss_SectionId] ON [dbo].[OsStatuss]
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OsStatuss]  WITH CHECK ADD  CONSTRAINT [FK_OsStatuss_OsSections_SectionId] FOREIGN KEY([SectionId])
REFERENCES [dbo].[OsSections] ([SectionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OsStatuss] CHECK CONSTRAINT [FK_OsStatuss_OsSections_SectionId]
GO
