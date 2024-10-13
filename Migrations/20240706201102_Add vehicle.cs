using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagement.Migrations
{
    /// <inheritdoc />
    public partial class Addvehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Ministry_MinistryId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_MinistryId",
                table: "Vehicle",
                newName: "IX_Vehicle_MinistryId");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Ministry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Ministry_MinistryId",
                table: "Vehicle",
                column: "MinistryId",
                principalTable: "Ministry",
                principalColumn: "MinistryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Ministry_MinistryId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Make",
                table: "Ministry");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_MinistryId",
                table: "Vehicles",
                newName: "IX_Vehicles_MinistryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Ministry_MinistryId",
                table: "Vehicles",
                column: "MinistryId",
                principalTable: "Ministry",
                principalColumn: "MinistryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
