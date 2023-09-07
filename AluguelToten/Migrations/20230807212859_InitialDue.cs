using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluguelToten.Migrations
{
    /// <inheritdoc />
    public partial class InitialDue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Totens",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Totens",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Totens");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Totens");
        }
    }
}
