using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoPrep.Persistance.Migrations
{
    public partial class AddUnicornRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Unicorns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unicorns_OwnerId",
                table: "Unicorns",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unicorns_Owners_OwnerId",
                table: "Unicorns",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unicorns_Owners_OwnerId",
                table: "Unicorns");

            migrationBuilder.DropIndex(
                name: "IX_Unicorns_OwnerId",
                table: "Unicorns");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Unicorns");
        }
    }
}
