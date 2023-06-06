using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto_gamer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Login");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Login",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
