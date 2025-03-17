using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitPoroject.Migrations
{
    /// <inheritdoc />
    public partial class addedImportedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Importe",
                table: "Voitures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importe",
                table: "Voitures");
        }
    }
}
