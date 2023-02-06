using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class deneme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ClientUserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ClientUserId",
                table: "Projects",
                newName: "ClientUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ClientUserId",
                table: "Projects",
                newName: "IX_Projects_ClientUserID");

            migrationBuilder.AlterColumn<int>(
                name: "ClientUserID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.RenameColumn(
                name: "ClientUserID",
                table: "Projects",
                newName: "ClientUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ClientUserID",
                table: "Projects",
                newName: "IX_Projects_ClientUserId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientUserId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ClientUserId",
                table: "Projects",
                column: "ClientUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
