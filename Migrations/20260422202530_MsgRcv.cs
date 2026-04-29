using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backender.Migrations
{
    /// <inheritdoc />
    public partial class MsgRcv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message_Receiver",
                table: "MessagesOfUsersChat",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message_Receiver",
                table: "MessagesOfUsersChat");
        }
    }
}
