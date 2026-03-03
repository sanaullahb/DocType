using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocType.Migrations
{
    /// <inheritdoc />
    public partial class allrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocAvailabilities_Doc_DocId",
                table: "DocAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_DocTimeSlot_DocAvailabilities_AvailabilityId",
                table: "DocTimeSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_DocTimeSlot_Doc_DocId",
                table: "DocTimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_DocTimeSlot_DocId",
                table: "DocTimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_DocAvailabilities_DocId",
                table: "DocAvailabilities");

            migrationBuilder.DropColumn(
                name: "DocId",
                table: "DocTimeSlot");

            migrationBuilder.DropColumn(
                name: "DocId",
                table: "DocAvailabilities");

            migrationBuilder.CreateIndex(
                name: "IX_DocAvailabilities_DoctorId",
                table: "DocAvailabilities",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocAvailabilities_Doc_DoctorId",
                table: "DocAvailabilities",
                column: "DoctorId",
                principalTable: "Doc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocTimeSlot_DocAvailabilities_AvailabilityId",
                table: "DocTimeSlot",
                column: "AvailabilityId",
                principalTable: "DocAvailabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocTimeSlot_Doc_DoctorId",
                table: "DocTimeSlot",
                column: "DoctorId",
                principalTable: "Doc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocAvailabilities_Doc_DoctorId",
                table: "DocAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_DocTimeSlot_DocAvailabilities_AvailabilityId",
                table: "DocTimeSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_DocTimeSlot_Doc_DoctorId",
                table: "DocTimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_DocAvailabilities_DoctorId",
                table: "DocAvailabilities");

            migrationBuilder.AddColumn<string>(
                name: "DocId",
                table: "DocTimeSlot",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocId",
                table: "DocAvailabilities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DocTimeSlot_DocId",
                table: "DocTimeSlot",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_DocAvailabilities_DocId",
                table: "DocAvailabilities",
                column: "DocId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocAvailabilities_Doc_DocId",
                table: "DocAvailabilities",
                column: "DocId",
                principalTable: "Doc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocTimeSlot_DocAvailabilities_AvailabilityId",
                table: "DocTimeSlot",
                column: "AvailabilityId",
                principalTable: "DocAvailabilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocTimeSlot_Doc_DocId",
                table: "DocTimeSlot",
                column: "DocId",
                principalTable: "Doc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
