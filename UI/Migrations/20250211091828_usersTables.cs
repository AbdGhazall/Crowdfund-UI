using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class usersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Address",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Block = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HouseOrBuildingNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Address", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "User_KYC_Employment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Employee = table.Column<bool>(type: "bit", nullable: false),
                    SelfEmployed = table.Column<bool>(type: "bit", nullable: false),
                    Unemployed = table.Column<bool>(type: "bit", nullable: false),
                    Retired = table.Column<bool>(type: "bit", nullable: false),
                    Student = table.Column<bool>(type: "bit", nullable: false),
                    Housewife = table.Column<bool>(type: "bit", nullable: false),
                    Others = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Employer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NatureOfBusiness = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_KYC_Employment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_KYC_FinancialInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetWorthRangeId = table.Column<int>(type: "int", nullable: false),
                    AnnualIncomeRangeId = table.Column<int>(type: "int", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_KYC_FinancialInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_KYC_FinancialInfo_KYC_AnnualIncomeRange_AnnualIncomeRangeId",
                        column: x => x.AnnualIncomeRangeId,
                        principalTable: "KYC_AnnualIncomeRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_KYC_FinancialInfo_KYC_NetWorthRange_NetWorthRangeId",
                        column: x => x.NetWorthRangeId,
                        principalTable: "KYC_NetWorthRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_KYC_PersonalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevelId = table.Column<int>(type: "int", nullable: false),
                    EmploymentStatusId = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmployeerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmployeerAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmployeerContactDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_KYC_PersonalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_KYC_PersonalInfo_KYC_EducationLevel_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "KYC_EducationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_KYC_PersonalInfo_KYC_EmploymentStatus_EmploymentStatusId",
                        column: x => x.EmploymentStatusId,
                        principalTable: "KYC_EmploymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_KYC_Individual",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientDetailsId = table.Column<int>(type: "int", nullable: true),
                    EmploymentDetailsId = table.Column<int>(type: "int", nullable: true),
                    IncomeAndInvestmentInformationId = table.Column<int>(type: "int", nullable: true),
                    AccountBeneficiariesAndControllersDetailsId = table.Column<int>(type: "int", nullable: true),
                    InsiderPersonsDetailsId = table.Column<int>(type: "int", nullable: true),
                    RelatedPartiesDetailsId = table.Column<int>(type: "int", nullable: true),
                    PoliticalPositionInformationId = table.Column<int>(type: "int", nullable: true),
                    BankAccountDetailsId = table.Column<int>(type: "int", nullable: true),
                    ClientClassificationId = table.Column<int>(type: "int", nullable: true),
                    DealWithFinancialInstitutionId = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_KYC_Individual", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_IndKYC_EmpDetails",
                        column: x => x.EmploymentDetailsId,
                        principalTable: "User_KYC_Employment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_KYC_FinancialInfo_AnnualIncomeRangeId",
                table: "User_KYC_FinancialInfo",
                column: "AnnualIncomeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_KYC_FinancialInfo_NetWorthRangeId",
                table: "User_KYC_FinancialInfo",
                column: "NetWorthRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_KYC_Individual_EmploymentDetailsId",
                table: "User_KYC_Individual",
                column: "EmploymentDetailsId",
                unique: true,
                filter: "[EmploymentDetailsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_KYC_PersonalInfo_EducationLevelId",
                table: "User_KYC_PersonalInfo",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_User_KYC_PersonalInfo_EmploymentStatusId",
                table: "User_KYC_PersonalInfo",
                column: "EmploymentStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Address");

            migrationBuilder.DropTable(
                name: "User_KYC_FinancialInfo");

            migrationBuilder.DropTable(
                name: "User_KYC_Individual");

            migrationBuilder.DropTable(
                name: "User_KYC_PersonalInfo");

            migrationBuilder.DropTable(
                name: "User_KYC_Employment");
        }
    }
}
