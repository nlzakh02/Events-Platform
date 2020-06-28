using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Addresses_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventItems_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventorganizer_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventtype_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "venueshilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    address1 = table.Column<string>(maxLength: 50, nullable: false),
                    address2 = table.Column<string>(maxLength: 50, nullable: true, defaultValue: "None"),
                    address3 = table.Column<string>(maxLength: 50, nullable: true, defaultValue: "None"),
                    City = table.Column<string>(maxLength: 100, nullable: true, defaultValue: "None"),
                    County = table.Column<string>(maxLength: 100, nullable: true, defaultValue: "None"),
                    Region = table.Column<string>(nullable: true, defaultValue: "None"),
                    PostalCode = table.Column<string>(nullable: true, defaultValue: "None"),
                    Country = table.Column<string>(maxLength: 100, nullable: true, defaultValue: "US"),
                    Latitude = table.Column<decimal>(nullable: false, defaultValue: 900m),
                    Longitude = table.Column<decimal>(nullable: false, defaultValue: 900m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventOrganizers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueID = table.Column<int>(nullable: false),
                    VenueAddressId = table.Column<int>(nullable: false),
                    AgeRestriction = table.Column<int>(nullable: false, defaultValue: -1),
                    Capacity = table.Column<int>(nullable: false, defaultValue: -1),
                    VenueName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueID);
                    table.ForeignKey(
                        name: "FK_Venues_Addresses_VenueAddressId",
                        column: x => x.VenueAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureURL = table.Column<string>(nullable: false),
                    EventOrganizerId = table.Column<int>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: false),
                    EventAddressId = table.Column<int>(nullable: false),
                    EventVenueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventItems_Addresses_EventAddressId",
                        column: x => x.EventAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventItems_EventOrganizers_EventOrganizerId",
                        column: x => x.EventOrganizerId,
                        principalTable: "EventOrganizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventItems_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventItems_Venues_EventVenueId",
                        column: x => x.EventVenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventAddressId",
                table: "EventItems",
                column: "EventAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventOrganizerId",
                table: "EventItems",
                column: "EventOrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventTypeId",
                table: "EventItems",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventVenueId",
                table: "EventItems",
                column: "EventVenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenueAddressId",
                table: "Venues",
                column: "VenueAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventItems");

            migrationBuilder.DropTable(
                name: "EventOrganizers");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropSequence(
                name: "Addresses_hilo");

            migrationBuilder.DropSequence(
                name: "eventItems_hilo");

            migrationBuilder.DropSequence(
                name: "eventorganizer_hilo");

            migrationBuilder.DropSequence(
                name: "eventtype_hilo");

            migrationBuilder.DropSequence(
                name: "venueshilo");
        }
    }
}
