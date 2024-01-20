using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schools2.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_County_CountyID",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_County_Country_CountryID",
                table: "County");

            migrationBuilder.DropForeignKey(
                name: "FK_School_City_CityID",
                table: "School");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "School",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "County",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountyID",
                table: "City",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_City_County_CountyID",
                table: "City",
                column: "CountyID",
                principalTable: "County",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_County_Country_CountryID",
                table: "County",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_School_City_CityID",
                table: "School",
                column: "CityID",
                principalTable: "City",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_County_CountyID",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_County_Country_CountryID",
                table: "County");

            migrationBuilder.DropForeignKey(
                name: "FK_School_City_CityID",
                table: "School");

            migrationBuilder.AlterColumn<int>(
                name: "CityID",
                table: "School",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "County",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountyID",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_City_County_CountyID",
                table: "City",
                column: "CountyID",
                principalTable: "County",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_County_Country_CountryID",
                table: "County",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_City_CityID",
                table: "School",
                column: "CityID",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
