using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefereeApp.Migrations
{
    public partial class AddedUserToCallendarEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CallendarEvents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CallendarEvents_UserId",
                table: "CallendarEvents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CallendarEvents_AspNetUsers_UserId",
                table: "CallendarEvents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallendarEvents_AspNetUsers_UserId",
                table: "CallendarEvents");

            migrationBuilder.DropIndex(
                name: "IX_CallendarEvents_UserId",
                table: "CallendarEvents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CallendarEvents");
        }
    }
}
