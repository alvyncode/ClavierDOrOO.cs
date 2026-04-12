using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RolesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joueurs_Role_RoleId",
                table: "Joueurs");

            migrationBuilder.DropIndex(
                name: "IX_Joueurs_RoleId",
                table: "Joueurs");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Joueurs");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_RoleId",
                table: "Parties",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Role_RoleId",
                table: "Parties",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Role_RoleId",
                table: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Parties_RoleId",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Parties");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Joueurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Joueurs_RoleId",
                table: "Joueurs",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Joueurs_Role_RoleId",
                table: "Joueurs",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
