USE [IMS_DB]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserUuid] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[IsApproved] [bit] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[LockoutEnd] [datetime2](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ProfilePicPath] [nvarchar](max) NULL,
	[AddedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[EmailConfirmed] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (3, N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'Rifnaz', N'Hanifa', N'Colomboi, Sri Lanka', N'0717100072', 1, N'rifnaz', N'RIFNAZ', N'hanifarifnazz@gmail.com', N'HANIFARIFNAZZ@GMAIL.COM', NULL, 1, 0, N'/images/uploads/7d811fcc-0be8-41f6-b04c-3fcac06a6ac8.jpg', CAST(N'2025-01-06T15:49:27.5666667' AS DateTime2), CAST(N'2025-01-14T14:13:03.8366667' AS DateTime2), 0)
INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (4, N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'Tharushi', N'Dilshani', N'Trincomalee, SriLanka', N'0717100072', 1, N'tharu', N'THARU', N'tharushi@gmail.com', N'THARUSHI@GMAIL.COM', NULL, 1, 0, N'/images/uploads/87ade284-8f2d-4059-9cbd-3fc9da25c8c2.jpg', CAST(N'2025-01-06T15:49:27.5666667' AS DateTime2), CAST(N'2025-04-20T10:35:19.9100000' AS DateTime2), 0)
INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (5, N'970ff11f-2591-4d3e-9cd7-330c212cfc25', N'Samith', N'Mohammed', N'Kinniya, Sri Lanka', N'0712345675', 1, N'samith', N'SAMITH', N'samith@gmail.com', N'SAMITH@GMAIL.COM', NULL, 1, 0, NULL, CAST(N'2025-01-06T18:15:25.0566667' AS DateTime2), CAST(N'2025-01-12T10:18:08.0566667' AS DateTime2), 0)
INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (6, N'01e90098-40ad-4890-9731-6c705ebbd782', N'Mohammed ', N'Waseem', NULL, N'07122515464465', 1, N'waseem', N'WASEEM', N'waseem@gmail.com', N'WASEEM@GMAIL.COM', NULL, 1, 0, NULL, CAST(N'2025-01-14T15:42:41.2333333' AS DateTime2), NULL, 0)
INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (7, N'bc9232a7-51f6-4b36-8806-f44077552542', N'Mohammed', N'Hanifa', N'No.26/1, Peraru kanthale', N'0717100072', 1, N'hanifa', N'HANIFA', N'rifnazz@gmail.com', N'RIFNAZZ@GMAIL.COM', NULL, 1, 0, N'/images/uploads/a43ca997-84ec-4290-acc8-51fbf030e095.jpg', CAST(N'2025-01-14T22:04:57.0200000' AS DateTime2), CAST(N'2025-01-14T22:37:52.4133333' AS DateTime2), 0)
INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (8, N'c8677f20-4214-41f9-a8f1-9a802a6077cd', N'Rishidhan', N'Punniyamoorthi', NULL, N'0711234567', 1, N'rishi', N'RISHI', N'rishii@gamail.com', N'RISHII@GAMAIL.COM', NULL, 1, 0, NULL, CAST(N'2025-01-15T19:27:09.8966667' AS DateTime2), CAST(N'2025-03-06T00:38:27.7533333' AS DateTime2), 0)
INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (9, N'89f5340c-9761-4c83-8887-640094af9450', N'Shathusna', N'Inthirakumar', N'Jaffna, Sri Lanka', N'0712345678', 1, N'shathusna', N'SHATHUSNA', N'Shathusna@gmail.com', N'SHATHUSNA@GMAIL.COM', NULL, 1, 0, N'/images/uploads/c6874d46-5bc3-468c-b6b5-56815b11e083.webp', CAST(N'2025-01-20T23:09:21.1266667' AS DateTime2), CAST(N'2025-01-20T23:26:51.9800000' AS DateTime2), 0)
INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (10, N'f2159a35-cae6-44e0-aee5-d948d3721580', N'Keerthi', N'Suresh', N'Jaffna, Sri Lanka', N'0712345678', 1, N'keerthi', N'KEERTHI', N'keerthi@gmail.com', N'KEERTHI@GMAIL.COM', NULL, 1, 0, NULL, CAST(N'2025-01-20T23:20:37.0833333' AS DateTime2), CAST(N'2025-01-20T23:28:57.0400000' AS DateTime2), 0)
INSERT [dbo].[Users] ([Id], [UserUuid], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath], [AddedDate], [UpdatedDate], [EmailConfirmed]) VALUES (1009, N'59ae8b50-43cc-45ce-840d-560f1eca1919', N'testing', N'testuser', N'no. syvgds d', N'0515114944161', 0, N'test', N'TEST', N'Test@gmail.com', N'TEST@GMAIL.COM', NULL, 1, 0, NULL, CAST(N'2025-04-21T19:13:32.6233333' AS DateTime2), CAST(N'2025-04-21T19:46:23.7200000' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_Users_UserUuid]    Script Date: 6/28/2025 9:07:17 AM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [AK_Users_UserUuid] UNIQUE NONCLUSTERED 
(
	[UserUuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [EmailConfirmed]
GO
