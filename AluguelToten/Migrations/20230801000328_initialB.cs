using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluguelToten.Migrations
{
    /// <inheritdoc />
    public partial class initialB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "senhaUsuario",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "CustomIdentityUserId",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CustomIdentityUserId",
                table: "Usuarios",
                column: "CustomIdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_AspNetUsers_CustomIdentityUserId",
                table: "Usuarios",
                column: "CustomIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_AspNetUsers_CustomIdentityUserId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CustomIdentityUserId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CustomIdentityUserId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "senhaUsuario",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
