using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateAsetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nama = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    TanggalPerolehan = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Kategori = table.Column<string>(type: "TEXT", nullable: false),
                    nilai = table.Column<int>(type: "INTEGER", nullable: false),
                    FotoPath = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aset", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aset");
        }
    }
}
