using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class SomeModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OsSections_Users_AddedById",
                table: "OsSections");

            migrationBuilder.DropForeignKey(
                name: "FK_OsSections_Users_UpdatedById",
                table: "OsSections");

            migrationBuilder.DropForeignKey(
                name: "FK_OsStatuss_Users_AddedById",
                table: "OsStatuss");

            migrationBuilder.DropForeignKey(
                name: "FK_OsStatuss_Users_UpdatedById",
                table: "OsStatuss");

            migrationBuilder.DropIndex(
                name: "IX_OsStatuss_AddedById",
                table: "OsStatuss");

            migrationBuilder.DropIndex(
                name: "IX_OsStatuss_UpdatedById",
                table: "OsStatuss");

            migrationBuilder.DropIndex(
                name: "IX_OsSections_AddedById",
                table: "OsSections");

            migrationBuilder.DropIndex(
                name: "IX_OsSections_UpdatedById",
                table: "OsSections");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "OsStatuss");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "OsStatuss");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "OsStatuss");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OsStatuss");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "OsSections");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "OsSections");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "OsSections");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OsSections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "OsStatuss",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "OsStatuss",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "OsStatuss",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OsStatuss",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "OsSections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "OsSections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "OsSections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OsSections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OsStatuss_AddedById",
                table: "OsStatuss",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OsStatuss_UpdatedById",
                table: "OsStatuss",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OsSections_AddedById",
                table: "OsSections",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OsSections_UpdatedById",
                table: "OsSections",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_OsSections_Users_AddedById",
                table: "OsSections",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "UserUuid");

            migrationBuilder.AddForeignKey(
                name: "FK_OsSections_Users_UpdatedById",
                table: "OsSections",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "UserUuid");

            migrationBuilder.AddForeignKey(
                name: "FK_OsStatuss_Users_AddedById",
                table: "OsStatuss",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "UserUuid");

            migrationBuilder.AddForeignKey(
                name: "FK_OsStatuss_Users_UpdatedById",
                table: "OsStatuss",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "UserUuid");
        }
    }
}
