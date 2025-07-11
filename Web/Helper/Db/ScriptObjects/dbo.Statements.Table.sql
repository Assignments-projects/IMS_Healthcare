USE [IMS_DB]
GO
/****** Object:  Table [dbo].[Statements]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statements](
	[StatementId] [int] IDENTITY(1,1) NOT NULL,
	[PatientUuid] [nvarchar](450) NULL,
	[StatusId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[TotalCost] [decimal](18, 2) NULL,
	[IsGenerated] [bit] NOT NULL,
	[IsSent] [bit] NOT NULL,
	[AddedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[AddedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Statements] PRIMARY KEY CLUSTERED 
(
	[StatementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Statements] ON 

INSERT [dbo].[Statements] ([StatementId], [PatientUuid], [StatusId], [Description], [TotalCost], [IsGenerated], [IsSent], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (1, N'970ff11f-2591-4d3e-9cd7-330c212cfc25', 11, N'Test', CAST(1100.00 AS Decimal(18, 2)), 0, 0, N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T13:03:56.7024896' AS DateTime2), CAST(N'2025-01-14T14:02:45.5837231' AS DateTime2), 0)
INSERT [dbo].[Statements] ([StatementId], [PatientUuid], [StatusId], [Description], [TotalCost], [IsGenerated], [IsSent], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (6, N'01e90098-40ad-4890-9731-6c705ebbd782', 10, N'test', NULL, 0, 0, N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T15:57:45.8872010' AS DateTime2), CAST(N'2025-01-14T15:57:45.8882183' AS DateTime2), 0)
INSERT [dbo].[Statements] ([StatementId], [PatientUuid], [StatusId], [Description], [TotalCost], [IsGenerated], [IsSent], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (7, N'59ae8b50-43cc-45ce-840d-560f1eca1919', 10, N'Consultant fee', CAST(1600.00 AS Decimal(18, 2)), 0, 0, N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'f13bcfc4-0c91-459c-ab9c-274db6c73248', CAST(N'2025-04-21T19:22:48.2374832' AS DateTime2), CAST(N'2025-04-21T19:22:48.2375116' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Statements] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Statements_AddedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Statements_AddedById] ON [dbo].[Statements]
(
	[AddedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Statements_PatientUuid]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Statements_PatientUuid] ON [dbo].[Statements]
(
	[PatientUuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Statements_StatusId]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Statements_StatusId] ON [dbo].[Statements]
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Statements_UpdatedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Statements_UpdatedById] ON [dbo].[Statements]
(
	[UpdatedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Statements]  WITH CHECK ADD  CONSTRAINT [FK_Statements_OsStatuss_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[OsStatuss] ([StatusId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Statements] CHECK CONSTRAINT [FK_Statements_OsStatuss_StatusId]
GO
ALTER TABLE [dbo].[Statements]  WITH CHECK ADD  CONSTRAINT [FK_Statements_Patients_PatientUuid] FOREIGN KEY([PatientUuid])
REFERENCES [dbo].[Patients] ([PatientUuid])
GO
ALTER TABLE [dbo].[Statements] CHECK CONSTRAINT [FK_Statements_Patients_PatientUuid]
GO
ALTER TABLE [dbo].[Statements]  WITH CHECK ADD  CONSTRAINT [FK_Statements_Users_AddedById] FOREIGN KEY([AddedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Statements] CHECK CONSTRAINT [FK_Statements_Users_AddedById]
GO
ALTER TABLE [dbo].[Statements]  WITH CHECK ADD  CONSTRAINT [FK_Statements_Users_UpdatedById] FOREIGN KEY([UpdatedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Statements] CHECK CONSTRAINT [FK_Statements_Users_UpdatedById]
GO
