using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleMapsService.Migrations
{
    public partial class GoogleMigration : Migration
    {
        protected override void Up(
            MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoogleMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity","1, 1"),
                    Rating =
                        table.Column<int>(nullable: true),
                    Address =
                        table.Column<string>(
                            nullable: true),
                    Lat = table.Column<double>(
                        nullable: false),
                    Long =
                        table.Column<double>(
                            nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleMap",
                        x => x.Id);
                });
        }

        protected override void Down(
            MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoogleMap");
        }
    }
}