USE [IMS_DB]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PateintId] [int] IDENTITY(1,1) NOT NULL,
	[PatientUuid] [nvarchar](450) NOT NULL,
	[InChargeuUud] [nvarchar](450) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[IdentityNo] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[TotalCost] [decimal](18, 2) NULL,
	[IsDischarged] [bit] NOT NULL,
	[AddedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[AddedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[WardNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PateintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([PateintId], [PatientUuid], [InChargeuUud], [FirstName], [LastName], [Address], [PhoneNo], [Gender], [DateOfBirth], [IdentityNo], [Comments], [TotalCost], [IsDischarged], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive], [WardNo]) VALUES (8, N'970ff11f-2591-4d3e-9cd7-330c212cfc25', N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'Samith', N'Mohammed', N'Kinniya, Sri Lanka', N'0712345675', N'Male', CAST(N'2025-01-07T09:20:00.0000000' AS DateTime2), N'555444545v', N'test', CAST(1100.00 AS Decimal(18, 2)), 0, N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-12T09:21:30.2338908' AS DateTime2), CAST(N'2025-01-12T10:18:56.9212146' AS DateTime2), 0, NULL)
INSERT [dbo].[Patients] ([PateintId], [PatientUuid], [InChargeuUud], [FirstName], [LastName], [Address], [PhoneNo], [Gender], [DateOfBirth], [IdentityNo], [Comments], [TotalCost], [IsDischarged], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive], [WardNo]) VALUES (12, N'01e90098-40ad-4890-9731-6c705ebbd782', N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'Mohammed ', N'Waseem', NULL, N'07122515464465', N'Male', CAST(N'2025-01-10T15:50:00.0000000' AS DateTime2), N'HHF', N'TRE', NULL, 0, N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T15:50:21.2070242' AS DateTime2), CAST(N'2025-01-14T15:50:21.2113945' AS DateTime2), 0, NULL)
INSERT [dbo].[Patients] ([PateintId], [PatientUuid], [InChargeuUud], [FirstName], [LastName], [Address], [PhoneNo], [Gender], [DateOfBirth], [IdentityNo], [Comments], [TotalCost], [IsDischarged], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive], [WardNo]) VALUES (13, N'59ae8b50-43cc-45ce-840d-560f1eca1919', N'f2159a35-cae6-44e0-aee5-d948d3721580', N'testing', N'testuser', N'no. syvgds d', N'0515114944161', N'Female', CAST(N'2025-04-09T19:18:00.0000000' AS DateTime2), N'4465454', NULL, CAST(1600.00 AS Decimal(18, 2)), 0, N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'f13bcfc4-0c91-459c-ab9c-274db6c73248', CAST(N'2025-04-21T19:18:31.8865901' AS DateTime2), CAST(N'2025-04-21T19:18:31.8874843' AS DateTime2), 0, NULL)
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_Patients_PatientUuid]    Script Date: 6/28/2025 9:07:17 AM ******/
ALTER TABLE [dbo].[Patients] ADD  CONSTRAINT [AK_Patients_PatientUuid] UNIQUE NONCLUSTERED 
(
	[PatientUuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Patients_AddedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Patients_AddedById] ON [dbo].[Patients]
(
	[AddedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Patients_InChargeuUud]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Patients_InChargeuUud] ON [dbo].[Patients]
(
	[InChargeuUud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Patients_UpdatedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Patients_UpdatedById] ON [dbo].[Patients]
(
	[UpdatedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Staffs_InChargeuUud] FOREIGN KEY([InChargeuUud])
REFERENCES [dbo].[Staffs] ([StaffUuid])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Staffs_InChargeuUud]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Users_AddedById] FOREIGN KEY([AddedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Users_AddedById]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Users_PatientUuid] FOREIGN KEY([PatientUuid])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Users_PatientUuid]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Users_UpdatedById] FOREIGN KEY([UpdatedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Users_UpdatedById]
GO
