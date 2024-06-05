using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ai_code_challenger.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSolved",
                table: "Challenge",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Challenge",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Challenge",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Challenge");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Challenge");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSolved",
                table: "Challenge",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
