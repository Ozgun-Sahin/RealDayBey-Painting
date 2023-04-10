using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class WriterRoleNameChangedIntoUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ClientUserId",
                table: "AspNetUserRoles");

            migrationBuilder.RenameColumn(
                name: "ClientUserId",
                table: "AspNetUserRoles",
                newName: "CustomerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_ClientUserId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_CustomerUserId",
                table: "AspNetUserRoles",
                column: "CustomerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_CustomerUserId",
                table: "AspNetUserRoles");

            migrationBuilder.RenameColumn(
                name: "CustomerUserId",
                table: "AspNetUserRoles",
                newName: "ClientUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_CustomerUserId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_ClientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ClientUserId",
                table: "AspNetUserRoles",
                column: "ClientUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
