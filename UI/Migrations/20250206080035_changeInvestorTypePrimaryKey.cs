using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class changeInvestorTypePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KYC_InvestorTypeSetup",
                table: "KYC_InvestorTypeSetup");

            migrationBuilder.DropColumn(
                name: "InvestorType",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "KYC_InvestorTypeSetup",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InvestorTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KYC_InvestorTypeSetup",
                table: "KYC_InvestorTypeSetup",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InvestorTypeId",
                table: "AspNetUsers",
                column: "InvestorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_KYC_InvestorTypeSetup_InvestorTypeId",
                table: "AspNetUsers",
                column: "InvestorTypeId",
                principalTable: "KYC_InvestorTypeSetup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_KYC_InvestorTypeSetup_InvestorTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KYC_InvestorTypeSetup",
                table: "KYC_InvestorTypeSetup");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InvestorTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "KYC_InvestorTypeSetup");

            migrationBuilder.DropColumn(
                name: "InvestorTypeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "InvestorType",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KYC_InvestorTypeSetup",
                table: "KYC_InvestorTypeSetup",
                column: "InvestorType");
        }
    }
}