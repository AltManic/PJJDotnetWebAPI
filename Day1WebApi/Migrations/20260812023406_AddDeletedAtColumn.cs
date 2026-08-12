using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAtColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Pegawai",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Kategori",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "aset",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Pegawai");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Kategori");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "aset");
        }
    }
}
