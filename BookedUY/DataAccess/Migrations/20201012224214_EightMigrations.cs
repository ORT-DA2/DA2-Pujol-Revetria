using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class EightMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristicSpotImage");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "TouristicSpots",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "TouristicSpots");

            migrationBuilder.CreateTable(
                name: "TouristicSpotImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TouristicSpotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristicSpotImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristicSpotImage_TouristicSpots_TouristicSpotId",
                        column: x => x.TouristicSpotId,
                        principalTable: "TouristicSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TouristicSpotImage_TouristicSpotId",
                table: "TouristicSpotImage",
                column: "TouristicSpotId",
                unique: true);
        }
    }
}
