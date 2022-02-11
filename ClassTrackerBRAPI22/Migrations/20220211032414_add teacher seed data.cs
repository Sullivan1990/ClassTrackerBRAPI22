using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassTrackerBRAPI22.Migrations
{
    public partial class addteacherseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Email", "Name", "Phone" },
                values: new object[] { 1, "Steve@email.com", "Steve", "1234123412" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Email", "Name", "Phone" },
                values: new object[] { 2, "Jennifer@email.com", "Jennifer", "5432234523" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);
        }
    }
}
