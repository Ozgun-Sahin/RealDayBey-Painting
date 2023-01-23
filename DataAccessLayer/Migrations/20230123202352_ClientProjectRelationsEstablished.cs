using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ClientProjectRelationsEstablished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientUserID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientUserID",
                table: "Projects",
                column: "ClientUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ClientUserID",
                table: "Projects",
                column: "ClientUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ClientUserID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientUserID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientUserID",
                table: "Projects");
        }
    }
}
