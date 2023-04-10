using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class writerMessagesTableNameChangedIntoMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WriterMessageID",
                table: "WriterMessages",
                newName: "MessageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "WriterMessages",
                newName: "WriterMessageID");
        }
    }
}
