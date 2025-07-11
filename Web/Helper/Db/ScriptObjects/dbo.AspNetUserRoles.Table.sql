USE [IMS_DB]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bc9232a7-51f6-4b36-8806-f44077552542', N'36411069-21e1-49ea-b2ba-b4b190913bd7')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'01e90098-40ad-4890-9731-6c705ebbd782', N'5b7bd483-5a1e-4e6a-b04b-7ef6ebf6fc02')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'59ae8b50-43cc-45ce-840d-560f1eca1919', N'5b7bd483-5a1e-4e6a-b04b-7ef6ebf6fc02')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'970ff11f-2591-4d3e-9cd7-330c212cfc25', N'5b7bd483-5a1e-4e6a-b04b-7ef6ebf6fc02')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'89f5340c-9761-4c83-8887-640094af9450', N'62871a7b-3476-420a-b58f-9d18879a6485')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'62871a7b-3476-420a-b58f-9d18879a6485')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f2159a35-cae6-44e0-aee5-d948d3721580', N'c2d9d5e5-0a42-4004-9326-41de3dca7b92')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'd4c9b4b7-0362-43b3-acf2-814b5be71699')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'89f5340c-9761-4c83-8887-640094af9450', N'd4c9b4b7-0362-43b3-acf2-814b5be71699')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
