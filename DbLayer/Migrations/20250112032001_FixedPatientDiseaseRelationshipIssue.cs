using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixedPatientDiseaseRelationshipIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diseases_PatientUuid",
                table: "Patients");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Diseases_PatientUuid",
                table: "Diseases");

            migrationBuilder.AlterColumn<string>(
                name: "PatientUuid",
                table: "Diseases",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_PatientUuid",
                table: "Diseases",
                column: "PatientUuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Patients_PatientUuid",
                table: "Diseases",
                column: "PatientUuid",
                principalTable: "Patients",
                principalColumn: "PatientUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Patients_PatientUuid",
                table: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_PatientUuid",
                table: "Diseases");

            migrationBuilder.AlterColumn<string>(
                name: "PatientUuid",
                table: "Diseases",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Diseases_PatientUuid",
                table: "Diseases",
                column: "PatientUuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diseases_PatientUuid",
                table: "Patients",
                column: "PatientUuid",
                principalTable: "Diseases",
                principalColumn: "PatientUuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
