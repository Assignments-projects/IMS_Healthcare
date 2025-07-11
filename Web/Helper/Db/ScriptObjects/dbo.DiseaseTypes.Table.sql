USE [IMS_DB]
GO
/****** Object:  Table [dbo].[DiseaseTypes]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiseaseTypes](
	[DiseaseTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[AddedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[AddedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_DiseaseTypes] PRIMARY KEY CLUSTERED 
(
	[DiseaseTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DiseaseTypes] ON 

INSERT [dbo].[DiseaseTypes] ([DiseaseTypeId], [TypeName], [Description], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (1, N'Fever', N'test', N'ftt', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-10T18:01:06.1571060' AS DateTime2), CAST(N'2025-01-10T19:10:45.1716162' AS DateTime2), 0)
INSERT [dbo].[DiseaseTypes] ([DiseaseTypeId], [TypeName], [Description], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (2, N'Blood Cancer', N'test', NULL, N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T20:23:52.0264416' AS DateTime2), CAST(N'2025-01-14T20:23:52.0264726' AS DateTime2), 0)
INSERT [dbo].[DiseaseTypes] ([DiseaseTypeId], [TypeName], [Description], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (3, N'Brain Cancer', NULL, NULL, N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T22:19:52.3974752' AS DateTime2), CAST(N'2025-01-14T22:19:52.3984481' AS DateTime2), 0)
INSERT [dbo].[DiseaseTypes] ([DiseaseTypeId], [TypeName], [Description], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (5, N'Test Diseases Type', NULL, NULL, N'89f5340c-9761-4c83-8887-640094af9450', N'89f5340c-9761-4c83-8887-640094af9450', CAST(N'2025-01-20T23:32:33.3905737' AS DateTime2), CAST(N'2025-01-20T23:32:33.3906443' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[DiseaseTypes] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DiseaseTypes_AddedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_DiseaseTypes_AddedById] ON [dbo].[DiseaseTypes]
(
	[AddedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DiseaseTypes_UpdatedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_DiseaseTypes_UpdatedById] ON [dbo].[DiseaseTypes]
(
	[UpdatedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DiseaseTypes]  WITH CHECK ADD  CONSTRAINT [FK_DiseaseTypes_Users_AddedById] FOREIGN KEY([AddedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[DiseaseTypes] CHECK CONSTRAINT [FK_DiseaseTypes_Users_AddedById]
GO
ALTER TABLE [dbo].[DiseaseTypes]  WITH CHECK ADD  CONSTRAINT [FK_DiseaseTypes_Users_UpdatedById] FOREIGN KEY([UpdatedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[DiseaseTypes] CHECK CONSTRAINT [FK_DiseaseTypes_Users_UpdatedById]
GO
