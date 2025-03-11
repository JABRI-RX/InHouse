using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitPoroject.Migrations
{
    /// <inheritdoc />
    public partial class AccessoriesAndTransmissionsColumnsToVoiture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accessories",
                table: "Voitures",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Voitures",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accessories",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Voitures");
        }
    }
}
