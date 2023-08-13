using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonStatisticsAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamePersonsToPacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Packs");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_UserId",
                table: "Packs",
                newName: "IX_Packs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packs",
                table: "Packs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packs_Users_UserId",
                table: "Packs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packs_Users_UserId",
                table: "Packs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packs",
                table: "Packs");

            migrationBuilder.RenameTable(
                name: "Packs",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_Packs_UserId",
                table: "Persons",
                newName: "IX_Persons_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserId",
                table: "Persons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
