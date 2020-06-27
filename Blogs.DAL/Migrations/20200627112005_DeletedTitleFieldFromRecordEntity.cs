using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogs.DAL.Migrations
{
    public partial class DeletedTitleFieldFromRecordEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Records_Title",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Records");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Records",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Records_Title",
                table: "Records",
                column: "Title");
        }
    }
}
