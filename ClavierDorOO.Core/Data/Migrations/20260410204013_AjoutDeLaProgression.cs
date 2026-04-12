using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDeLaProgression : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joueurs_Role_roleId",
                table: "Joueurs");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Joueurs",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Joueurs_roleId",
                table: "Joueurs",
                newName: "IX_Joueurs_RoleId");

            migrationBuilder.AddColumn<int>(
                name: "ProgessionAlgo",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgessionAnglais",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgessionCultureG",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgessionLogique",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgessionMDI",
                table: "Parties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Joueurs_Role_RoleId",
                table: "Joueurs",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joueurs_Role_RoleId",
                table: "Joueurs");

            migrationBuilder.DropColumn(
                name: "ProgessionAlgo",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "ProgessionAnglais",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "ProgessionCultureG",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "ProgessionLogique",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "ProgessionMDI",
                table: "Parties");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Joueurs",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Joueurs_RoleId",
                table: "Joueurs",
                newName: "IX_Joueurs_roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Joueurs_Role_roleId",
                table: "Joueurs",
                column: "roleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
