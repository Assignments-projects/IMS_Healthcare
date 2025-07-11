USE [IMS_DB]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[StaffId] [int] IDENTITY(1,1) NOT NULL,
	[StaffUuid] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[IdentityNo] [nvarchar](max) NULL,
	[Educations] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[Salary] [decimal](18, 2) NULL,
	[AddedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,
	[AddedDate] [datetime2](7) NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[Designation] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([StaffId], [StaffUuid], [FirstName], [LastName], [Address], [PhoneNo], [Gender], [DateOfBirth], [IdentityNo], [Educations], [Comments], [Salary], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive], [Designation]) VALUES (1, N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'Tharushi', N'Dilshani', N'Trincomalee, SriLanka', N'0717100072', N'Female', CAST(N'2025-01-16T19:56:00.0000000' AS DateTime2), N'44654fsfs', N'MBBS', N'test', CAST(511212.00 AS Decimal(18, 2)), N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-11T19:56:39.8588420' AS DateTime2), CAST(N'2025-01-11T19:57:30.2246535' AS DateTime2), 0, N'Doctor')
INSERT [dbo].[Staffs] ([StaffId], [StaffUuid], [FirstName], [LastName], [Address], [PhoneNo], [Gender], [DateOfBirth], [IdentityNo], [Educations], [Comments], [Salary], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive], [Designation]) VALUES (2, N'bc9232a7-51f6-4b36-8806-f44077552542', N'Mohammed', N'Hanifa', N'No.26/1, Peraru kanthale', N'0717100072', N'Male', CAST(N'2024-12-31T22:32:00.0000000' AS DateTime2), N'vgxfgfgx5454', N'MBBS', N'Test', CAST(2000000.00 AS Decimal(18, 2)), N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', CAST(N'2025-01-14T22:32:44.8096210' AS DateTime2), CAST(N'2025-01-14T22:32:44.8096547' AS DateTime2), 0, N'Eye Surgeon')
INSERT [dbo].[Staffs] ([StaffId], [StaffUuid], [FirstName], [LastName], [Address], [PhoneNo], [Gender], [DateOfBirth], [IdentityNo], [Educations], [Comments], [Salary], [AddedById], [UpdatedById], [AddedDate], [UpdatedDate], [IsActive], [Designation]) VALUES (3, N'f2159a35-cae6-44e0-aee5-d948d3721580', N'Keerthi', N'Suresh', N'Jaffna, Sri Lanka', N'0712345678', N'Female', CAST(N'2000-02-09T23:29:00.0000000' AS DateTime2), N'127759459562322v', N'BSc Nursing', N'testin comments added', CAST(70000.00 AS Decimal(18, 2)), N'89f5340c-9761-4c83-8887-640094af9450', N'89f5340c-9761-4c83-8887-640094af9450', CAST(N'2025-01-20T23:30:32.9492198' AS DateTime2), CAST(N'2025-01-20T23:30:49.2557975' AS DateTime2), 0, N'Nurse Mid')
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_Staffs_StaffUuid]    Script Date: 6/28/2025 9:07:17 AM ******/
ALTER TABLE [dbo].[Staffs] ADD  CONSTRAINT [AK_Staffs_StaffUuid] UNIQUE NONCLUSTERED 
(
	[StaffUuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Staffs_AddedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Staffs_AddedById] ON [dbo].[Staffs]
(
	[AddedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Staffs_UpdatedById]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Staffs_UpdatedById] ON [dbo].[Staffs]
(
	[UpdatedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Staffs] ADD  DEFAULT (N'') FOR [Designation]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Users_AddedById] FOREIGN KEY([AddedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Users_AddedById]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Users_StaffUuid] FOREIGN KEY([StaffUuid])
REFERENCES [dbo].[Users] ([UserUuid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Users_StaffUuid]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Users_UpdatedById] FOREIGN KEY([UpdatedById])
REFERENCES [dbo].[Users] ([UserUuid])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Users_UpdatedById]
GO
