using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace GamingClub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class NewReservationUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gamingstationentityreservationentity");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "reservation");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "reservation");

            migrationBuilder.CreateTable(
                name: "reservationunit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    GamingStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationunit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservationunit_gamingstation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "gamingstation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservationunit_reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_reservationunit_ReservationId",
                table: "reservationunit",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservationunit");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "reservation",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "reservation",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "gamingstationentityreservationentity",
                columns: table => new
                {
                    GameStationsId = table.Column<int>(type: "int", nullable: false),
                    ReservationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gamingstationentityreservationentity", x => new { x.GameStationsId, x.ReservationsId });
                    table.ForeignKey(
                        name: "FK_gamingstationentityreservationentity_gamingstation_GameStati~",
                        column: x => x.GameStationsId,
                        principalTable: "gamingstation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gamingstationentityreservationentity_reservation_Reservation~",
                        column: x => x.ReservationsId,
                        principalTable: "reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_gamingstationentityreservationentity_ReservationsId",
                table: "gamingstationentityreservationentity",
                column: "ReservationsId");
        }
    }
}
