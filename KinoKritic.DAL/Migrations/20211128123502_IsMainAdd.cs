using Microsoft.EntityFrameworkCore.Migrations;

namespace KinoKritic.DAL.Migrations
{
    public partial class IsMainAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "UserPhotos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "UserPhotos");
        }
    }
}
