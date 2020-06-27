using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogs.DAL.Migrations
{
    public partial class AddLikesFieldToRecordEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Records",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Records");
        }
    }
}
