using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenithHealingCenter.Migrations
{
    /// <inheritdoc />
    public partial class inital3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalPackages_Cabinets_CabinetId",
                table: "MedicalPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalPackages_Doctors_DoctorId",
                table: "MedicalPackages");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "MedicalPackages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CabinetId",
                table: "MedicalPackages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalPackages_Cabinets_CabinetId",
                table: "MedicalPackages",
                column: "CabinetId",
                principalTable: "Cabinets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalPackages_Doctors_DoctorId",
                table: "MedicalPackages",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalPackages_Cabinets_CabinetId",
                table: "MedicalPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalPackages_Doctors_DoctorId",
                table: "MedicalPackages");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "MedicalPackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CabinetId",
                table: "MedicalPackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalPackages_Cabinets_CabinetId",
                table: "MedicalPackages",
                column: "CabinetId",
                principalTable: "Cabinets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalPackages_Doctors_DoctorId",
                table: "MedicalPackages",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
