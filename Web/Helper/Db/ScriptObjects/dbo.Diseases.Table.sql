USE [IMS_DB]
GO
/****** Object:  Table [dbo].[Diseases]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diseases](
	[DiseaseId] [int] IDENTITY(1,1) NOT NULL,
	[PatientUuid] [nvarchar](450) NULL,
	[DiseaseTypeId] [int] NOT NULL,
	[DoctorId] [nvarchar](450) NULL,
	[DiseaseSpec] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[AddedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[AddedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Diseases] PRIMARY KEY CLUSTERED 
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Diseases] ON 

INSERT [dbo].[Diseases] ([DiseaseId], [PatientUuid], [DiseaseTypeId], [DoctorId], [DiseaseSpec], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (1, N'970ff11f-2591-4d3e-9cd7-330c212cfc25', 1, N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'Cold fever', N'test dieases added', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-12T14:27:26.1026951' AS DateTime2), CAST(N'2025-01-14T22:44:06.3801201' AS DateTime2), 0)
INSERT [dbo].[Diseases] ([DiseaseId], [PatientUuid], [DiseaseTypeId], [DoctorId], [DiseaseSpec], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (2, N'01e90098-40ad-4890-9731-6c705ebbd782', 1, N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'testt', N'ewe', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T20:19:36.3137433' AS DateTime2), CAST(N'2025-01-14T20:19:36.3144884' AS DateTime2), 0)
INSERT [dbo].[Diseases] ([DiseaseId], [PatientUuid], [DiseaseTypeId], [DoctorId], [DiseaseSpec], [Comments], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive]) VALUES (4, N'59ae8b50-43cc-45ce-840d-560f1eca1919', 5, N'bc9232a7-51f6-4b36-8806-f44077552542', N'Test disease description', NULL, N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'f13bcfc4-0c91-459c-ab9c-274db6c73248', CAST(N'2025-04-21T19:21:20.3806504' AS DateTime2), CAST(N'2025-04-21T19:21:20.3806811' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Diseases] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Diseases_AddedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Diseases_AddedById] ON [dbo].[Diseases]
(
	[AddedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Diseases_DiseaseTypeId]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Diseases_DiseaseTypeId] ON [dbo].[Diseases]
(
	[DiseaseTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Diseases_DoctorId]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Diseases_DoctorId] ON [dbo].[Diseases]
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Diseases_PatientUuid]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Diseases_PatientUuid] ON [dbo].[Diseases]
(
	[PatientUuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Diseases_UpdatedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Diseases_UpdatedById] ON [dbo].[Diseases]
(
	[UpdatedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Diseases]  WITH CHECK ADD  CONSTRAINT [FK_Diseases_DiseaseTypes_DiseaseTypeId] FOREIGN KEY([DiseaseTypeId])
REFERENCES [dbo].[DiseaseTypes] ([DiseaseTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Diseases] CHECK CONSTRAINT [FK_Diseases_DiseaseTypes_DiseaseTypeId]
GO
ALTER TABLE [dbo].[Diseases]  WITH CHECK ADD  CONSTRAINT [FK_Diseases_Patients_PatientUuid] FOREIGN KEY([PatientUuid])
REFERENCES [dbo].[Patients] ([PatientUuid])
GO
ALTER TABLE [dbo].[Diseases] CHECK CONSTRAINT [FK_Diseases_Patients_PatientUuid]
GO
ALTER TABLE [dbo].[Diseases]  WITH CHECK ADD  CONSTRAINT [FK_Diseases_Staffs_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Staffs] ([StaffUuid])
GO
ALTER TABLE [dbo].[Diseases] CHECK CONSTRAINT [FK_Diseases_Staffs_DoctorId]
GO
ALTER TABLE [dbo].[Diseases]  WITH CHECK ADD  CONSTRAINT [FK_Diseases_Users_AddedById] FOREIGN KEY([AddedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Diseases] CHECK CONSTRAINT [FK_Diseases_Users_AddedById]
GO
ALTER TABLE [dbo].[Diseases]  WITH CHECK ADD  CONSTRAINT [FK_Diseases_Users_UpdatedById] FOREIGN KEY([UpdatedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Diseases] CHECK CONSTRAINT [FK_Diseases_Users_UpdatedById]
GO
