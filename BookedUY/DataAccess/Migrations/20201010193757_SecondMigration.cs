using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tourist_GuestId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTouristicSpot_Categories_CategoryId",
                table: "CategoryTouristicSpot");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTouristicSpot_TouristicSpots_TouristicSpotId",
                table: "CategoryTouristicSpot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tourist",
                table: "Tourist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTouristicSpot",
                table: "CategoryTouristicSpot");

            migrationBuilder.RenameTable(
                name: "Tourist",
                newName: "Tourists");

            migrationBuilder.RenameTable(
                name: "CategoryTouristicSpot",
                newName: "categoryTouristicSpots");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTouristicSpot_TouristicSpotId",
                table: "categoryTouristicSpots",
                newName: "IX_categoryTouristicSpots_TouristicSpotId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TouristicSpots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "TouristicSpots",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Multiplier",
                table: "Guest",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Administrators",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PricePerNight",
                table: "Accommodations",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accommodations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tourists",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TouristicSpots_Name",
                table: "TouristicSpots",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Administrators_Email",
                table: "Administrators",
                column: "Email");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Accommodations_Name",
                table: "Accommodations",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tourists_Email",
                table: "Tourists",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tourists",
                table: "Tourists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoryTouristicSpots",
                table: "categoryTouristicSpots",
                columns: new[] { "CategoryId", "TouristicSpotId" });

            migrationBuilder.CreateTable(
                name: "AccommodationImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(nullable: true),
                    AccommodationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccommodationImages_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImages_AccommodationId",
                table: "AccommodationImages",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tourists_GuestId",
                table: "Bookings",
                column: "GuestId",
                principalTable: "Tourists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categoryTouristicSpots_Categories_CategoryId",
                table: "categoryTouristicSpots",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categoryTouristicSpots_TouristicSpots_TouristicSpotId",
                table: "categoryTouristicSpots",
                column: "TouristicSpotId",
                principalTable: "TouristicSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tourists_GuestId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_categoryTouristicSpots_Categories_CategoryId",
                table: "categoryTouristicSpots");

            migrationBuilder.DropForeignKey(
                name: "FK_categoryTouristicSpots_TouristicSpots_TouristicSpotId",
                table: "categoryTouristicSpots");

            migrationBuilder.DropTable(
                name: "AccommodationImages");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TouristicSpots_Name",
                table: "TouristicSpots");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Administrators_Email",
                table: "Administrators");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Accommodations_Name",
                table: "Accommodations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tourists_Email",
                table: "Tourists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tourists",
                table: "Tourists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoryTouristicSpots",
                table: "categoryTouristicSpots");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "TouristicSpots");

            migrationBuilder.RenameTable(
                name: "Tourists",
                newName: "Tourist");

            migrationBuilder.RenameTable(
                name: "categoryTouristicSpots",
                newName: "CategoryTouristicSpot");

            migrationBuilder.RenameIndex(
                name: "IX_categoryTouristicSpots_TouristicSpotId",
                table: "CategoryTouristicSpot",
                newName: "IX_CategoryTouristicSpot_TouristicSpotId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TouristicSpots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<float>(
                name: "Multiplier",
                table: "Guest",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Bookings",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<float>(
                name: "PricePerNight",
                table: "Accommodations",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tourist",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tourist",
                table: "Tourist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTouristicSpot",
                table: "CategoryTouristicSpot",
                columns: new[] { "CategoryId", "TouristicSpotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tourist_GuestId",
                table: "Bookings",
                column: "GuestId",
                principalTable: "Tourist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTouristicSpot_Categories_CategoryId",
                table: "CategoryTouristicSpot",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTouristicSpot_TouristicSpots_TouristicSpotId",
                table: "CategoryTouristicSpot",
                column: "TouristicSpotId",
                principalTable: "TouristicSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
