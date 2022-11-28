using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefereeApp.Migrations
{
    public partial class Teams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "street",
                table: "Stadiums",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "Stadiums",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Stadiums",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Stadiums",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Stadiums",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Stadiums",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Stadiums",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stadiums",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Stadiums",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stadiums",
                newName: "id");
        }
    }
}
