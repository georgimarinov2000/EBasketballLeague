using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class fourthone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arenas_Locations_LocationId",
                table: "Arenas");

            migrationBuilder.DropIndex(
                name: "IX_Arenas_LocationId",
                table: "Arenas");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Arenas",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Arenas_LocationId",
                table: "Arenas",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Arenas_Locations_LocationId",
                table: "Arenas",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arenas_Locations_LocationId",
                table: "Arenas");

            migrationBuilder.DropIndex(
                name: "IX_Arenas_LocationId",
                table: "Arenas");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Arenas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Arenas_LocationId",
                table: "Arenas",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Arenas_Locations_LocationId",
                table: "Arenas",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
