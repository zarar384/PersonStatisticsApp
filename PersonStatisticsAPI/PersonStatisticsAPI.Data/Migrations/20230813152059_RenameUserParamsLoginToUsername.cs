using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonStatisticsAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserParamsLoginToUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Login");
        }
    }
}
