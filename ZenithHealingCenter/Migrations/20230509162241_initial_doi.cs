﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenithHealingCenter.Migrations
{
    /// <inheritdoc />
    public partial class initial_doi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Doctors");
        }
    }
}
