using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.MunicipalityId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPR = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNr = table.Column<long>(type: "bigint", nullable: false),
                    PassPortNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Room_Locations",
                columns: table => new
                {
                    Room_LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNr = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaxOccupants = table.Column<int>(type: "int", nullable: false),
                    AccessMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Locations", x => x.Room_LocationId);
                    table.ForeignKey(
                        name: "FK_Room_Locations_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "MunicipalityId");
                });

            migrationBuilder.CreateTable(
                name: "Societies",
                columns: table => new
                {
                    SocietyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVR = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedMemberPersonId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societies", x => x.SocietyId);
                    table.ForeignKey(
                        name: "FK_Societies_People_ApprovedMemberPersonId",
                        column: x => x.ApprovedMemberPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Property_Types",
                columns: table => new
                {
                    Property_TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Room_LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property_Types", x => x.Property_TypeId);
                    table.ForeignKey(
                        name: "FK_Property_Types_Room_Locations_Room_LocationId",
                        column: x => x.Room_LocationId,
                        principalTable: "Room_Locations",
                        principalColumn: "Room_LocationId");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedRoomsRoom_LocationId = table.Column<int>(type: "int", nullable: false),
                    BookingMembersPersonId = table.Column<int>(type: "int", nullable: false),
                    BookingSocietySocietyId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_People_BookingMembersPersonId",
                        column: x => x.BookingMembersPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Room_Locations_BookedRoomsRoom_LocationId",
                        column: x => x.BookedRoomsRoom_LocationId,
                        principalTable: "Room_Locations",
                        principalColumn: "Room_LocationId");
                    table.ForeignKey(
                        name: "FK_Reservations_Societies_BookingSocietySocietyId",
                        column: x => x.BookingSocietySocietyId,
                        principalTable: "Societies",
                        principalColumn: "SocietyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_CPR",
                table: "People",
                column: "CPR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_Types_Item",
                table: "Property_Types",
                column: "Item",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_Types_Room_LocationId",
                table: "Property_Types",
                column: "Room_LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookedRoomsRoom_LocationId",
                table: "Reservations",
                column: "BookedRoomsRoom_LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookingMembersPersonId",
                table: "Reservations",
                column: "BookingMembersPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookingSocietySocietyId",
                table: "Reservations",
                column: "BookingSocietySocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Locations_MunicipalityId",
                table: "Room_Locations",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Locations_RoomNr_Address",
                table: "Room_Locations",
                columns: new[] { "RoomNr", "Address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Societies_ApprovedMemberPersonId",
                table: "Societies",
                column: "ApprovedMemberPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property_Types");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Room_Locations");

            migrationBuilder.DropTable(
                name: "Societies");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
