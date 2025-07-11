USE [IMS_DB]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[IsApproved] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ProfilePicPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'01e90098-40ad-4890-9731-6c705ebbd782', N'Mohammed ', N'Waseem', NULL, N'07122515464465', 1, N'waseem', N'WASEEM', N'waseem@gmail.com', N'WASEEM@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELyJv+RopEdL/JnaLCRK3OPODh5kJh53WDCo8Hc7RlaC0fk3U/Co9VKa7ItVKanEtA==', N'6LETU2MH65CWVHZL55Q5ZFF463VTR5NR', N'b88edf45-09b7-4baf-8da7-f6187d85aaf4', NULL, 0, 0, NULL, 1, 0, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'4de5b1c9-85fa-45ac-bf0a-f609318b4d94', N'Rifnaz', N'Hanifa', N'Colomboi, Sri Lanka', N'0717100072', 1, N'rifnaz', N'RIFNAZ', N'hanifarifnazz@gmail.com', N'HANIFARIFNAZZ@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEL+R7guSa+hIeAkXvbOKaxNA0bV1rXuGmLVVZ1I2REg7a1p1+oQwOX/twClgs6fWwA==', N'7OXPIV5M63EW2AJKO5HWXUNJUWJBZ5WW', N'e9f8fb9c-dbb2-4212-975b-e836fc5a2893', N'0717100072', 0, 0, NULL, 1, 0, N'/images/uploads/7d811fcc-0be8-41f6-b04c-3fcac06a6ac8.jpg')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'59ae8b50-43cc-45ce-840d-560f1eca1919', N'testing', N'testuser', N'no. syvgds d', N'0515114944161', 0, N'test', N'TEST', N'Test@gmail.com', N'TEST@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEFhKUkFcFMhkr0QfCtgL88WK8saHuWMuyLNu9QgbvWSCRV2RrW6EA1V0zp0DI+WFxw==', N'DDKU5LRWDMMD2I4S7OBCATJQ27GRB7VI', N'a28f1703-3b3d-4995-893c-eebec4be6daf', NULL, 0, 0, NULL, 1, 0, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'89f5340c-9761-4c83-8887-640094af9450', N'Shathusna', N'Inthirakumar', N'Jaffna, Sri Lanka', N'0712345678', 1, N'shathusna', N'SHATHUSNA', N'Shathusna@gmail.com', N'SHATHUSNA@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEO2FkfYoXq+FX2p/56QxSdmOlEyD7TdV4W7wW6YV0dYDlduQjp59gis+MR3stK7I2Q==', N'NJOU4XPEGJMJY2WJUHOFCWCGNM2ULDDG', N'fbd1c1ed-ad4c-4db8-ba85-c88a7da5e0e1', NULL, 0, 0, NULL, 1, 0, N'/images/uploads/c6874d46-5bc3-468c-b6b5-56815b11e083.webp')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'970ff11f-2591-4d3e-9cd7-330c212cfc25', N'Samith', N'Mohammed', N'Kinniya, Sri Lanka', N'0712345675', 1, N'samith', N'SAMITH', N'samith@gmail.com', N'SAMITH@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEFoDdPRQYwgrnPBWDAN6BRNK+amcfCpxn9oDc+77ok8+qPf9JALLIqwS8ALCr8HsJQ==', N'VUDUD5ZNTGFD6JKMCNDAFMBJBUGRWFF2', N'0d6d86df-94e5-41a2-9dea-ce776c4022eb', NULL, 0, 0, NULL, 1, 0, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'bc9232a7-51f6-4b36-8806-f44077552542', N'Mohammed', N'Hanifa', N'No.26/1, Peraru kanthale', N'0717100072', 1, N'hanifa', N'HANIFA', N'rifnazz@gmail.com', N'RIFNAZZ@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEHdBTp94Ivw9DVkw2UMGQoAOYWk3pd6dYBpX0m4hTcuqJkXhQGrZN0foz6Fahd88AA==', N'CPGUQXC24G6VXWYW7X4BUQ6B3AJKMCZW', N'cb4b5cd0-07e6-40c9-80c1-d8115b385257', NULL, 0, 0, NULL, 1, 0, N'/images/uploads/a43ca997-84ec-4290-acc8-51fbf030e095.jpg')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'c8677f20-4214-41f9-a8f1-9a802a6077cd', N'Rishidhan', N'Punniyamoorthi', NULL, N'0711234567', 1, N'rishi', N'RISHI', N'rishii@gamail.com', N'RISHII@GAMAIL.COM', 0, N'AQAAAAIAAYagAAAAEP0Q3K8d+2KtzCA51wYfzW8S7jFehFBl9i1OZy9ExhpZLtOX424Ye305JNf438Rv6A==', N'2RM3OFHZA6RYIIMVRNNU46WGVMZ6LKK4', N'8d1343e6-e6cd-4b0a-a7c4-4b258c0c32e9', NULL, 0, 0, NULL, 1, 0, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'f13bcfc4-0c91-459c-ab9c-274db6c73248', N'Tharushi', N'Dilshani', N'Trincomalee, SriLanka', N'0717100072', 1, N'tharu', N'THARU', N'tharushi@gmail.com', N'THARUSHI@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEPQwzTiwMp9Uhp1xiFQq0qVef/aaKpd1tE6jyrCnqiRXDOanKggD/xtld/zYnpIMFg==', N'AHPMJV33SMAZSDW256SLUBL2SL6AR6EK', N'8d399cff-cde3-42fc-865b-edea76191909', NULL, 0, 0, NULL, 1, 0, N'/images/uploads/87ade284-8f2d-4059-9cbd-3fc9da25c8c2.jpg')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PhoneNo], [IsApproved], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ProfilePicPath]) VALUES (N'f2159a35-cae6-44e0-aee5-d948d3721580', N'Keerthi', N'Suresh', N'Jaffna, Sri Lanka', N'0712345678', 1, N'keerthi', N'KEERTHI', N'keerthi@gmail.com', N'KEERTHI@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEF7czXE7qLQ3oJWxGeGCfwC6sePcKS3ltzeD4TEWnHSdAoJfld03r7ytiDlkXi1DEg==', N'2KQFJCCF6MPJ4USQF4QAKKYUWTISQ4RU', N'2e86c19f-6160-4756-9a69-c82a13bcea3a', NULL, 0, 0, NULL, 1, 0, NULL)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 6/28/2025 9:07:17 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
