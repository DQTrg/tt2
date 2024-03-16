using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TT2.Migrations
{
    /// <inheritdoc />
    public partial class update_2_16_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatStatusId",
                table: "Seats",
                column: "SeatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieTypeId",
                table: "Movies",
                column: "MovieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RateId",
                table: "Movies",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieTypes_MovieTypeId",
                table: "Movies",
                column: "MovieTypeId",
                principalTable: "MovieTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Rates_RateId",
                table: "Movies",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_SeatStatuses_SeatStatusId",
                table: "Seats",
                column: "SeatStatusId",
                principalTable: "SeatStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_SeatTypes_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId",
                principalTable: "SeatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieTypes_MovieTypeId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Rates_RateId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_SeatStatuses_SeatStatusId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_SeatTypes_SeatTypeId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_SeatStatusId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieTypeId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_RateId",
                table: "Movies");
        }
    }
}
