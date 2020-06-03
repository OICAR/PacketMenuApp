using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleMapsService.Migrations
{
    public partial class GoogleData : Migration
    {
        protected override void Up(
            MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GoogleMap",
                columns: new[]
                {
                    "Id", "Address", "Lat", "Long", "Rating"
                },
                values: new object[]
                {
                    1, "Sredja skola", 43.736938000000002,
                    15.89859, 4
                });

            migrationBuilder.InsertData(
                table: "GoogleMap",
                columns: new[]
                {
                    "Id", "Address", "Lat", "Long", "Rating"
                },
                values: new object[]
                {
                    2, "Kuca", 43.750129999999999, 15.8872,
                    5
                });

            migrationBuilder.InsertData(
                table: "GoogleMap",
                columns: new[]
                {
                    "Id", "Address", "Lat", "Long", "Rating"
                },
                values: new object[]
                {
                    3, "Stan", 43.751060000000003, 15.88996,
                    4
                });
        }

        protected override void Down(
            MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GoogleMap",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GoogleMap",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GoogleMap",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}