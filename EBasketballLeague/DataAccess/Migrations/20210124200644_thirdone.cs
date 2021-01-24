using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class thirdone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Arenas_ArenaId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ArenaId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "ArenaId",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ArenaId",
                table: "Teams",
                column: "ArenaId",
                unique: true,
                filter: "[ArenaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Arenas_ArenaId",
                table: "Teams",
                column: "ArenaId",
                principalTable: "Arenas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Arenas_ArenaId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ArenaId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "ArenaId",
                table: "Teams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ArenaId",
                table: "Teams",
                column: "ArenaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Arenas_ArenaId",
                table: "Teams",
                column: "ArenaId",
                principalTable: "Arenas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
