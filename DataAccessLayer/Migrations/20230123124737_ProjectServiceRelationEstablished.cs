using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ProjectServiceRelationEstablished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ServiceID",
                table: "Projects",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Services_ServiceID",
                table: "Projects",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Services_ServiceID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ServiceID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Projects");
        }
    }
}
