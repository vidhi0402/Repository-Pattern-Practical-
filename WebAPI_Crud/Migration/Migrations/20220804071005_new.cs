using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "State",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
