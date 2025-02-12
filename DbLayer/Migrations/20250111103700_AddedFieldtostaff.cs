﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldtostaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Staffs");
        }
    }
}
