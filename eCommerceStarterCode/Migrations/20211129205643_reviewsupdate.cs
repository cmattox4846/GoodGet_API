using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceStarterCode.Migrations
{
    public partial class reviewsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviews_ReviewID",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewID",
                table: "Reviews",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewID",
                table: "Reviews",
                newName: "IX_Reviews_ReviewId");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ReviewId",
                table: "Reviews",
                column: "ReviewId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ReviewId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Reviews",
                newName: "ReviewID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewID");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviews_ReviewID",
                table: "Reviews",
                column: "ReviewID",
                principalTable: "Reviews",
                principalColumn: "Review",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
