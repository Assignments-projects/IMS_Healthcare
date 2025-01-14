using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class AuditTableFKChnaged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Statements_AddedById",
                table: "Statements");

            migrationBuilder.DropIndex(
                name: "IX_Statements_UpdatedById",
                table: "Statements");

            migrationBuilder.DropIndex(
                name: "IX_StatementItems_AddedById",
                table: "StatementItems");

            migrationBuilder.DropIndex(
                name: "IX_StatementItems_UpdatedById",
                table: "StatementItems");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_AddedById",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_UpdatedById",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AddedById",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_UpdatedById",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddedById",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UpdatedById",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_ImageTypes_AddedById",
                table: "ImageTypes");

            migrationBuilder.DropIndex(
                name: "IX_ImageTypes_UpdatedById",
                table: "ImageTypes");

            migrationBuilder.DropIndex(
                name: "IX_Images_AddedById",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UpdatedById",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_DiseaseTypes_AddedById",
                table: "DiseaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_DiseaseTypes_UpdatedById",
                table: "DiseaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_AddedById",
                table: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_UpdatedById",
                table: "Diseases");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_AddedById",
                table: "Statements",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_UpdatedById",
                table: "Statements",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StatementItems_AddedById",
                table: "StatementItems",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_StatementItems_UpdatedById",
                table: "StatementItems",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_AddedById",
                table: "Staffs",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UpdatedById",
                table: "Staffs",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AddedById",
                table: "Prescriptions",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_UpdatedById",
                table: "Prescriptions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddedById",
                table: "Patients",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UpdatedById",
                table: "Patients",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTypes_AddedById",
                table: "ImageTypes",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTypes_UpdatedById",
                table: "ImageTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AddedById",
                table: "Images",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UpdatedById",
                table: "Images",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseTypes_AddedById",
                table: "DiseaseTypes",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseTypes_UpdatedById",
                table: "DiseaseTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_AddedById",
                table: "Diseases",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_UpdatedById",
                table: "Diseases",
                column: "UpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Statements_AddedById",
                table: "Statements");

            migrationBuilder.DropIndex(
                name: "IX_Statements_UpdatedById",
                table: "Statements");

            migrationBuilder.DropIndex(
                name: "IX_StatementItems_AddedById",
                table: "StatementItems");

            migrationBuilder.DropIndex(
                name: "IX_StatementItems_UpdatedById",
                table: "StatementItems");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_AddedById",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_UpdatedById",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AddedById",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_UpdatedById",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AddedById",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UpdatedById",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_ImageTypes_AddedById",
                table: "ImageTypes");

            migrationBuilder.DropIndex(
                name: "IX_ImageTypes_UpdatedById",
                table: "ImageTypes");

            migrationBuilder.DropIndex(
                name: "IX_Images_AddedById",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UpdatedById",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_DiseaseTypes_AddedById",
                table: "DiseaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_DiseaseTypes_UpdatedById",
                table: "DiseaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_AddedById",
                table: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_Diseases_UpdatedById",
                table: "Diseases");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_AddedById",
                table: "Statements",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_UpdatedById",
                table: "Statements",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StatementItems_AddedById",
                table: "StatementItems",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StatementItems_UpdatedById",
                table: "StatementItems",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_AddedById",
                table: "Staffs",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UpdatedById",
                table: "Staffs",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AddedById",
                table: "Prescriptions",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_UpdatedById",
                table: "Prescriptions",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddedById",
                table: "Patients",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UpdatedById",
                table: "Patients",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTypes_AddedById",
                table: "ImageTypes",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTypes_UpdatedById",
                table: "ImageTypes",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AddedById",
                table: "Images",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UpdatedById",
                table: "Images",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseTypes_AddedById",
                table: "DiseaseTypes",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseTypes_UpdatedById",
                table: "DiseaseTypes",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_AddedById",
                table: "Diseases",
                column: "AddedById",
                unique: true,
                filter: "[AddedById] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_UpdatedById",
                table: "Diseases",
                column: "UpdatedById",
                unique: true,
                filter: "[UpdatedById] IS NOT NULL");
        }
    }
}
