using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class WriterMessageClientUserIDColumnRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WriterMessages_AspNetUsers_ClientUserID",
                table: "WriterMessages");

            migrationBuilder.DropIndex(
                name: "IX_WriterMessages_ClientUserID",
                table: "WriterMessages");

            migrationBuilder.DropColumn(
                name: "ClientUserID",
                table: "WriterMessages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientUserID",
                table: "WriterMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WriterMessages_ClientUserID",
                table: "WriterMessages",
                column: "ClientUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_WriterMessages_AspNetUsers_ClientUserID",
                table: "WriterMessages",
                column: "ClientUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
