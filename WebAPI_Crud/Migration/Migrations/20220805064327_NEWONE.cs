using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class NEWONE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "State",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Country",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
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
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
