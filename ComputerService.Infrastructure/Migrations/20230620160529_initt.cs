using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ComputerServices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComputerServices_CreatedById",
                table: "ComputerServices",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerServices_AspNetUsers_CreatedById",
                table: "ComputerServices",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerServices_AspNetUsers_CreatedById",
                table: "ComputerServices");

            migrationBuilder.DropIndex(
                name: "IX_ComputerServices_CreatedById",
                table: "ComputerServices");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ComputerServices");
        }
    }
}
