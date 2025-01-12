using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateedImageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Staffs_StaffUuid",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StaffUuid",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "StaffUuid",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StaffId",
                table: "Images",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Staffs_StaffId",
                table: "Images",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Staffs_StaffId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StaffId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "StaffUuid",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StaffUuid",
                table: "Images",
                column: "StaffUuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Staffs_StaffUuid",
                table: "Images",
                column: "StaffUuid",
                principalTable: "Staffs",
                principalColumn: "StaffUuid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
