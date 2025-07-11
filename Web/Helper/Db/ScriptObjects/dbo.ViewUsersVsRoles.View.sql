USE [IMS_DB]
GO
/****** Object:  View [dbo].[ViewUsersVsRoles]    Script Date: 6/28/2025 9:07:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
                CREATE VIEW [dbo].[ViewUsersVsRoles] AS
                SELECT 
                    dbo.AspNetUserRoles.UserId, 
                    dbo.AspNetUserRoles.RoleId, 
                    dbo.AspNetUsers.FirstName, 
                    dbo.AspNetUsers.LastName, 
                    dbo.AspNetUsers.UserName, 
                    dbo.AspNetUsers.Email, 
                    dbo.AspNetUsers.IsApproved, 
                    dbo.AspNetRoles.Name AS RoleName, 
                    dbo.AspNetRoles.NormalizedName AS RoleNormalizedName
                FROM dbo.AspNetUserRoles
                INNER JOIN dbo.AspNetRoles ON dbo.AspNetUserRoles.RoleId = dbo.AspNetRoles.Id
                INNER JOIN dbo.AspNetUsers ON dbo.AspNetUserRoles.UserId = dbo.AspNetUsers.Id
GO
