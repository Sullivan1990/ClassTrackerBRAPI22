using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassTrackerBRAPI22.Migrations
{
    public partial class MakingTafeClassFKnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TafeClasses_Teachers_TeacherId",
                table: "TafeClasses");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TafeClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TafeClasses_Teachers_TeacherId",
                table: "TafeClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TafeClasses_Teachers_TeacherId",
                table: "TafeClasses");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TafeClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TafeClasses_Teachers_TeacherId",
                table: "TafeClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
