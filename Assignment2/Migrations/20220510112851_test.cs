using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    CPR = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.CPR);
                });

            migrationBuilder.CreateTable(
                name: "Room_Locations",
                columns: table => new
                {
                    RoomNr = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaxOccupants = table.Column<int>(type: "int", nullable: false),
                    MunicipalityName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Locations", x => new { x.RoomNr, x.Address });
                    table.ForeignKey(
                        name: "FK_Room_Locations_Municipalities_MunicipalityName",
                        column: x => x.MunicipalityName,
                        principalTable: "Municipalities",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Societies",
                columns: table => new
                {
                    CVR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChairmanCPR = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societies", x => x.CVR);
                    table.ForeignKey(
                        name: "FK_Societies_People_ChairmanCPR",
                        column: x => x.ChairmanCPR,
                        principalTable: "People",
                        principalColumn: "CPR");
                });

            migrationBuilder.CreateTable(
                name: "DateTimeCostume",
                columns: table => new
                {
                    CosDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room_LocationAddress = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Room_LocationRoomNr = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateTimeCostume", x => x.CosDateTime);
                    table.ForeignKey(
                        name: "FK_DateTimeCostume_Room_Locations_Room_LocationRoomNr_Room_LocationAddress",
                        columns: x => new { x.Room_LocationRoomNr, x.Room_LocationAddress },
                        principalTable: "Room_Locations",
                        principalColumns: new[] { "RoomNr", "Address" });
                });

            migrationBuilder.CreateTable(
                name: "Property_Types",
                columns: table => new
                {
                    Item = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Room_LocationAddress = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Room_LocationRoomNr = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property_Types", x => x.Item);
                    table.ForeignKey(
                        name: "FK_Property_Types_Room_Locations_Room_LocationRoomNr_Room_LocationAddress",
                        columns: x => new { x.Room_LocationRoomNr, x.Room_LocationAddress },
                        principalTable: "Room_Locations",
                        principalColumns: new[] { "RoomNr", "Address" });
                });

            migrationBuilder.CreateTable(
                name: "PersonSociety",
                columns: table => new
                {
                    MembersCPR = table.Column<long>(type: "bigint", nullable: false),
                    SocietyCVR = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSociety", x => new { x.MembersCPR, x.SocietyCVR });
                    table.ForeignKey(
                        name: "FK_PersonSociety_People_MembersCPR",
                        column: x => x.MembersCPR,
                        principalTable: "People",
                        principalColumn: "CPR",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSociety_Societies_SocietyCVR",
                        column: x => x.SocietyCVR,
                        principalTable: "Societies",
                        principalColumn: "CVR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedRoomsRoomNr = table.Column<int>(type: "int", nullable: false),
                    BookedRoomsAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingMembersCPR = table.Column<long>(type: "bigint", nullable: false),
                    BookingSocietyCVR = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_People_BookingMembersCPR",
                        column: x => x.BookingMembersCPR,
                        principalTable: "People",
                        principalColumn: "CPR");
                    table.ForeignKey(
                        name: "FK_Reservations_Room_Locations_BookedRoomsRoomNr_BookedRoomsAddress",
                        columns: x => new { x.BookedRoomsRoomNr, x.BookedRoomsAddress },
                        principalTable: "Room_Locations",
                        principalColumns: new[] { "RoomNr", "Address" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Societies_BookingSocietyCVR",
                        column: x => x.BookingSocietyCVR,
                        principalTable: "Societies",
                        principalColumn: "CVR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateTimeCostume_Room_LocationRoomNr_Room_LocationAddress",
                table: "DateTimeCostume",
                columns: new[] { "Room_LocationRoomNr", "Room_LocationAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonSociety_SocietyCVR",
                table: "PersonSociety",
                column: "SocietyCVR");

            migrationBuilder.CreateIndex(
                name: "IX_Property_Types_Room_LocationRoomNr_Room_LocationAddress",
                table: "Property_Types",
                columns: new[] { "Room_LocationRoomNr", "Room_LocationAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookedRoomsRoomNr_BookedRoomsAddress",
                table: "Reservations",
                columns: new[] { "BookedRoomsRoomNr", "BookedRoomsAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookingMembersCPR",
                table: "Reservations",
                column: "BookingMembersCPR");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookingSocietyCVR",
                table: "Reservations",
                column: "BookingSocietyCVR");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Locations_MunicipalityName",
                table: "Room_Locations",
                column: "MunicipalityName");

            migrationBuilder.CreateIndex(
                name: "IX_Societies_ChairmanCPR",
                table: "Societies",
                column: "ChairmanCPR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateTimeCostume");

            migrationBuilder.DropTable(
                name: "PersonSociety");

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
