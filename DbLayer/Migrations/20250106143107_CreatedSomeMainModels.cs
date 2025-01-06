using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSomeMainModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserUuid",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserUuid",
                table: "Users",
                column: "UserUuid");

            migrationBuilder.CreateTable(
                name: "DiseaseType",
                columns: table => new
                {
                    DiseaseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseType", x => x.DiseaseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserUuid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Educations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AddedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.UniqueConstraint("AK_Staffs_UserUuid", x => x.UserUuid);
                    table.ForeignKey(
                        name: "FK_Staffs_Users_UserUuid",
                        column: x => x.UserUuid,
                        principalTable: "Users",
                        principalColumn: "UserUuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientUuid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiseaseTypeId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiseaseSpec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseId);
                    table.UniqueConstraint("AK_Diseases_PatientUuid", x => x.PatientUuid);
                    table.ForeignKey(
                        name: "FK_Diseases_DiseaseType_DiseaseTypeId",
                        column: x => x.DiseaseTypeId,
                        principalTable: "DiseaseType",
                        principalColumn: "DiseaseTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diseases_Staffs_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Staffs",
                        principalColumn: "UserUuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PateintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserUuid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InChargeuUud = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDischarged = table.Column<bool>(type: "bit", nullable: false),
                    AddedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PateintId);
                    table.ForeignKey(
                        name: "FK_Patients_Diseases_UserUuid",
                        column: x => x.UserUuid,
                        principalTable: "Diseases",
                        principalColumn: "PatientUuid");
                    table.ForeignKey(
                        name: "FK_Patients_Staffs_InChargeuUud",
                        column: x => x.InChargeuUud,
                        principalTable: "Staffs",
                        principalColumn: "UserUuid");
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserUuid",
                        column: x => x.UserUuid,
                        principalTable: "Users",
                        principalColumn: "UserUuid");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    Mediciense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_DiseaseTypeId",
                table: "Diseases",
                column: "DiseaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_DoctorId",
                table: "Diseases",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InChargeuUud",
                table: "Patients",
                column: "InChargeuUud");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserUuid",
                table: "Patients",
                column: "UserUuid",
                unique: true,
                filter: "[UserUuid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DiseaseId",
                table: "Prescriptions",
                column: "DiseaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "DiseaseType");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserUuid",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserUuid",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
