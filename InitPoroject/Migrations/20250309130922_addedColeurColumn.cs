using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitPoroject.Migrations
{
    /// <inheritdoc />
    public partial class addedColeurColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Couleur",
                table: "Voitures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Couleur",
                table: "Voitures");
        }
    }
}
