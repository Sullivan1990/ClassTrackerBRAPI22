using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassTrackerBRAPI22.Migrations
{
    public partial class nullableForeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_TafeClasses_TafeClassId",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "TafeClassId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_TafeClasses_TafeClassId",
                table: "Units",
                column: "TafeClassId",
                principalTable: "TafeClasses",
                principalColumn: "TafeClassId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_TafeClasses_TafeClassId",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "TafeClassId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_TafeClasses_TafeClassId",
                table: "Units",
                column: "TafeClassId",
                principalTable: "TafeClasses",
                principalColumn: "TafeClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
