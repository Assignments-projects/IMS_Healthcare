USE [IMS_DB]
GO
/****** Object:  Table [dbo].[ImageTypes]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageTypes](
	[ImageTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[AddedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[AddedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ImageTypes] PRIMARY KEY CLUSTERED 
(
	[ImageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ImageTypes] ON 

INSERT [dbo].[ImageTypes] ([ImageTypeId], [TypeName], [Description], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (1, N'CTC', N'test ctc', N'add', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-10T19:10:27.3281997' AS DateTime2), CAST(N'2025-01-10T19:10:27.3300717' AS DateTime2), 1)
INSERT [dbo].[ImageTypes] ([ImageTypeId], [TypeName], [Description], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (2, N'X-RAY', N'xtray image ', NULL, N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T20:23:00.3088008' AS DateTime2), CAST(N'2025-01-14T20:23:00.3088309' AS DateTime2), 1)
INSERT [dbo].[ImageTypes] ([ImageTypeId], [TypeName], [Description], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (5, N'Test Image T', N'Test image t added for testing', NULL, N'89f5340c-9761-4c83-8887-640094af9450', N'89f5340c-9761-4c83-8887-640094af9450', CAST(N'2025-01-20T23:33:25.4708678' AS DateTime2), CAST(N'2025-01-20T23:33:25.4709387' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[ImageTypes] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ImageTypes_AddedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ImageTypes_AddedById] ON [dbo].[ImageTypes]
(
	[AddedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ImageTypes_UpdatedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ImageTypes_UpdatedById] ON [dbo].[ImageTypes]
(
	[UpdatedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ImageTypes]  WITH CHECK ADD  CONSTRAINT [FK_ImageTypes_Users_AddedById] FOREIGN KEY([AddedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[ImageTypes] CHECK CONSTRAINT [FK_ImageTypes_Users_AddedById]
GO
ALTER TABLE [dbo].[ImageTypes]  WITH CHECK ADD  CONSTRAINT [FK_ImageTypes_Users_UpdatedById] FOREIGN KEY([UpdatedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[ImageTypes] CHECK CONSTRAINT [FK_ImageTypes_Users_UpdatedById]
GO
