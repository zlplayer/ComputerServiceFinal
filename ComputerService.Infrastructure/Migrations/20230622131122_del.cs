using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class del : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "ComputerServices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "ComputerServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
