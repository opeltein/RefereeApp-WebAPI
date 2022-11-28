using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefereeApp.Migrations
{
    public partial class AddedUserToFinances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Finances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Finances_UserId",
                table: "Finances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_AspNetUsers_UserId",
                table: "Finances",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finances_AspNetUsers_UserId",
                table: "Finances");

            migrationBuilder.DropIndex(
                name: "IX_Finances_UserId",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Finances");
        }
    }
}
