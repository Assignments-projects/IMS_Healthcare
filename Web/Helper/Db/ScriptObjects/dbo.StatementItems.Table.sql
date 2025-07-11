USE [IMS_DB]
GO
/****** Object:  Table [dbo].[StatementItems]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatementItems](
	[StatementItemId] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseId] [int] NOT NULL,
	[StatementId] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[TotalCost] [decimal](18, 2) NULL,
	[AddedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[AddedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_StatementItems] PRIMARY KEY CLUSTERED 
(
	[StatementItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[StatementItems] ON 

INSERT [dbo].[StatementItems] ([StatementItemId], [DiseaseId], [StatementId], [Description], [TotalCost], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (22, 1, 1, N'Panadol cost', CAST(100.00 AS Decimal(18, 2)), N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T22:56:46.1079789' AS DateTime2), CAST(N'2025-01-14T22:56:46.1080326' AS DateTime2), 0)
INSERT [dbo].[StatementItems] ([StatementItemId], [DiseaseId], [StatementId], [Description], [TotalCost], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (23, 1, 1, N'test', CAST(500.00 AS Decimal(18, 2)), N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-15T19:10:46.2048372' AS DateTime2), CAST(N'2025-01-15T19:10:46.2065177' AS DateTime2), 0)
INSERT [dbo].[StatementItems] ([StatementItemId], [DiseaseId], [StatementId], [Description], [TotalCost], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (24, 1, 1, N'Doctor fee', CAST(500.00 AS Decimal(18, 2)), N'89f5340c-9761-4c83-8887-640094af9450', N'89f5340c-9761-4c83-8887-640094af9450', CAST(N'2025-01-20T23:40:05.9767260' AS DateTime2), CAST(N'2025-01-20T23:40:05.9768214' AS DateTime2), 0)
INSERT [dbo].[StatementItems] ([StatementItemId], [DiseaseId], [StatementId], [Description], [TotalCost], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (1024, 4, 7, N'Penadol', CAST(100.00 AS Decimal(18, 2)), N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'f13bcfc4-0c91-459c-ab9c-274db6c73248', CAST(N'2025-04-21T19:24:23.8412709' AS DateTime2), CAST(N'2025-04-21T19:24:23.8413090' AS DateTime2), 0)
INSERT [dbo].[StatementItems] ([StatementItemId], [DiseaseId], [StatementId], [Description], [TotalCost], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (1025, 4, 7, N'Blood test', CAST(1500.00 AS Decimal(18, 2)), N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'f13bcfc4-0c91-459c-ab9c-274db6c73248', CAST(N'2025-04-21T19:25:09.2872329' AS DateTime2), CAST(N'2025-04-21T19:25:09.2872355' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[StatementItems] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StatementItems_AddedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_StatementItems_AddedById] ON [dbo].[StatementItems]
(
	[AddedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StatementItems_DiseaseId]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_StatementItems_DiseaseId] ON [dbo].[StatementItems]
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StatementItems_StatementId]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_StatementItems_StatementId] ON [dbo].[StatementItems]
(
	[StatementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StatementItems_UpdatedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_StatementItems_UpdatedById] ON [dbo].[StatementItems]
(
	[UpdatedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StatementItems]  WITH CHECK ADD  CONSTRAINT [FK_StatementItems_Diseases_DiseaseId] FOREIGN KEY([DiseaseId])
REFERENCES [dbo].[Diseases] ([DiseaseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StatementItems] CHECK CONSTRAINT [FK_StatementItems_Diseases_DiseaseId]
GO
ALTER TABLE [dbo].[StatementItems]  WITH CHECK ADD  CONSTRAINT [FK_StatementItems_Statements_StatementId] FOREIGN KEY([StatementId])
REFERENCES [dbo].[Statements] ([StatementId])
GO
ALTER TABLE [dbo].[StatementItems] CHECK CONSTRAINT [FK_StatementItems_Statements_StatementId]
GO
ALTER TABLE [dbo].[StatementItems]  WITH CHECK ADD  CONSTRAINT [FK_StatementItems_Users_AddedById] FOREIGN KEY([AddedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[StatementItems] CHECK CONSTRAINT [FK_StatementItems_Users_AddedById]
GO
ALTER TABLE [dbo].[StatementItems]  WITH CHECK ADD  CONSTRAINT [FK_StatementItems_Users_UpdatedById] FOREIGN KEY([UpdatedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[StatementItems] CHECK CONSTRAINT [FK_StatementItems_Users_UpdatedById]
GO
