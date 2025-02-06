using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class createMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_KYC_Country_PlaceOfBirthId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceOfBirthId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_KYC_Country_PlaceOfBirthId",
                table: "AspNetUsers",
                column: "PlaceOfBirthId",
                principalTable: "KYC_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_KYC_Country_PlaceOfBirthId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceOfBirthId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_KYC_Country_PlaceOfBirthId",
                table: "AspNetUsers",
                column: "PlaceOfBirthId",
                principalTable: "KYC_Country",
                principalColumn: "Id");
        }
    }
}