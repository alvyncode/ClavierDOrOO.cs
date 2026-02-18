using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBDDv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Options_OptionsProposeesId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_OptionsProposeesId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "OptionsProposeesId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Questions",
                newName: "TypeDeQuestion");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_QuestionId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "TypeDeQuestion",
                table: "Questions",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "OptionsProposeesId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_OptionsProposeesId",
                table: "Questions",
                column: "OptionsProposeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Options_OptionsProposeesId",
                table: "Questions",
                column: "OptionsProposeesId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
