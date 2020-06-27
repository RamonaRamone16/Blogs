using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blogs.DAL.Migrations
{
    public partial class CreatedThemeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_AspNetUsers_AuthorId",
                table: "Records");

            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "Records",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Content = table.Column<string>(maxLength: 2500, nullable: false),
                    PublishedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Themes_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_ThemeId",
                table: "Records",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_AuthorId",
                table: "Themes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_Title",
                table: "Themes",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_AspNetUsers_AuthorId",
                table: "Records",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Themes_ThemeId",
                table: "Records",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_AspNetUsers_AuthorId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Themes_ThemeId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Records_ThemeId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Records");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_AspNetUsers_AuthorId",
                table: "Records",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
