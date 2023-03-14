using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.DAL.Migrations
{
    public partial class FirstInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_AspNetUsers_ClientId",
                table: "CheckIns");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_AspNetUsers_ClientId",
                table: "CheckIns",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_AspNetUsers_ClientId",
                table: "CheckIns");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_AspNetUsers_ClientId",
                table: "CheckIns",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
