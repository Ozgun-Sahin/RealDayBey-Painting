using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class WriterMessageColumnNamesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "WriterMessages",
                newName: "SenderUserName");

            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "WriterMessages",
                newName: "SenderFullName");

            migrationBuilder.RenameColumn(
                name: "RecieverName",
                table: "WriterMessages",
                newName: "RecieverUserName");

            migrationBuilder.RenameColumn(
                name: "Reciever",
                table: "WriterMessages",
                newName: "RecieverFullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderUserName",
                table: "WriterMessages",
                newName: "SenderName");

            migrationBuilder.RenameColumn(
                name: "SenderFullName",
                table: "WriterMessages",
                newName: "Sender");

            migrationBuilder.RenameColumn(
                name: "RecieverUserName",
                table: "WriterMessages",
                newName: "RecieverName");

            migrationBuilder.RenameColumn(
                name: "RecieverFullName",
                table: "WriterMessages",
                newName: "Reciever");
        }
    }
}
