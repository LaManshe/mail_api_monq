using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mail_api_monq.DAL.Migrations
{
    public partial class Result : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFault",
                table: "Mails");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Mails",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Mails");

            migrationBuilder.AddColumn<bool>(
                name: "IsFault",
                table: "Mails",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
