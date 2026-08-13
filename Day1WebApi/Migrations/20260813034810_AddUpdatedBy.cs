using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day1WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Kategori",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "aset",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Kategori");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "aset");
        }
    }
}
