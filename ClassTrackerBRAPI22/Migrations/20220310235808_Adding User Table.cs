using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassTrackerBRAPI22.Migrations
{
    public partial class AddingUserTable : Migration
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserInfoID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserInfoID", "Password", "Username" },
                values: new object[] { 1, "abc_1234", "Shaun" });

            migrationBuilder.AddForeignKey(
                name: "FK_TafeClasses_Teachers_TeacherId",
                table: "TafeClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TafeClasses_Teachers_TeacherId",
                table: "TafeClasses");

            migrationBuilder.DropTable(
                name: "Users");

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
    }
}
