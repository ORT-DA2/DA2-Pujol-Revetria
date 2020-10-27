using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FirstMigrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.UniqueConstraint("AK_Administrators_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.UniqueConstraint("AK_Categories_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tourists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourists", x => x.Id);
                    table.UniqueConstraint("AK_Tourists_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "TouristicSpots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristicSpots", x => x.Id);
                    table.UniqueConstraint("AK_TouristicSpots_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_TouristicSpots_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpotId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Information = table.Column<string>(nullable: true),
                    PricePerNight = table.Column<double>(nullable: false),
                    Full = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.UniqueConstraint("AK_Accommodations_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Accommodations_TouristicSpots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "TouristicSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoryTouristicSpots",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    TouristicSpotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryTouristicSpots", x => new { x.CategoryId, x.TouristicSpotId });
                    table.ForeignKey(
                        name: "FK_categoryTouristicSpots_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryTouristicSpots_TouristicSpots_TouristicSpotId",
                        column: x => x.TouristicSpotId,
                        principalTable: "TouristicSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccommodationId = table.Column<int>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    GuestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Tourists_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministratorId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    AsociatedBookingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingStages_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingStages_Bookings_AsociatedBookingId",
                        column: x => x.AsociatedBookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Multiplier = table.Column<double>(nullable: false),
                    BookingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guest_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.UniqueConstraint("AK_Reviews_BookingId", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Reviews_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImages_AccommodationId",
                table: "AccommodationImages",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_SpotId",
                table: "Accommodations",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AccommodationId",
                table: "Bookings",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingStages_AdministratorId",
                table: "BookingStages",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingStages_AsociatedBookingId",
                table: "BookingStages",
                column: "AsociatedBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryTouristicSpots_TouristicSpotId",
                table: "categoryTouristicSpots",
                column: "TouristicSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_BookingId",
                table: "Guest",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TouristicSpots_RegionId",
                table: "TouristicSpots",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationImages");

            migrationBuilder.DropTable(
                name: "BookingStages");

            migrationBuilder.DropTable(
                name: "categoryTouristicSpots");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Tourists");

            migrationBuilder.DropTable(
                name: "TouristicSpots");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
