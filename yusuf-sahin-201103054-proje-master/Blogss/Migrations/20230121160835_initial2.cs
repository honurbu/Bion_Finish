using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogss.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Products_ProductId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_ProductId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ProductId",
                table: "Blogs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Products_ProductId",
                table: "Blogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
