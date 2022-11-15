using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreWebApplication1.Data.Migrations
{
    public partial class CreatePlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerAccountId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_Player_FK",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    User_Player_FK = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerAccountId",
                table: "AspNetUsers",
                column: "PlayerAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Players_PlayerAccountId",
                table: "AspNetUsers",
                column: "PlayerAccountId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Players_PlayerAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlayerAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlayerAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_Player_FK",
                table: "AspNetUsers");
        }
    }
}
