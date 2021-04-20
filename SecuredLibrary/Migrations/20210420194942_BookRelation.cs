using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class BookRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_ContactId",
                table: "Book",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Contact_ContactId",
                table: "Book",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Contact_ContactId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_ContactId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
