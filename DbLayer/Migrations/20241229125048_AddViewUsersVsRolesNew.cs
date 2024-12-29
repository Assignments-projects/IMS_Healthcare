using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddViewUsersVsRolesNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
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
            ");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP VIEW [dbo].[ViewUsersVsRoles]");
		}
	}
}
